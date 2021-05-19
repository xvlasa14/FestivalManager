using System;
using System.Linq;
using FestivalManager.BL.Models;
using FestivalManager.BL.Repositories;
using FestivalManager.BL.Mapper;
using FestivalManager.DAL;
using FestivalManager.DAL.Entities;
using FestivalManager.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FestivalManager.BL.Tests
{
    [Collection("Sequential")]
    public class SlotRepositoryTest: IDisposable
    {
        private readonly SlotRepository _slotRepository;
        private readonly BandRepository _bandRepository;
        private readonly StageRepository _stageRepository;

        public SlotRepositoryTest()
        {
            IDbContextFactory<FestivalManagerDbContext> dbContextFactory = new DbContextInMemoryFactory(nameof(BandRepositoryTest));
            using FestivalManagerDbContext dbx = dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();
            _bandRepository = new BandRepository(dbContextFactory);
            _slotRepository = new SlotRepository(dbContextFactory);
            _stageRepository = new StageRepository(dbContextFactory);
        }

        [Fact]
        public void CreateSlotTest()
        {
            //Arrange
            var newSlotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),
                BandId = Guid.NewGuid(),
                StageId = Guid.NewGuid()
            };
            
            //Act
            var insertedSlotModel = _slotRepository.Create(newSlotModel);

            //Assert
            Assert.NotNull(insertedSlotModel);

            _slotRepository.Delete(insertedSlotModel.Id);
        }

        [Fact]
        public void CreateInvalidTimeSlotTest()
        {
            //Arrange
            var newSlotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now,
                BandId = Guid.NewGuid(),
                StageId = Guid.NewGuid()
            };

            //Assert
            Assert.Throws<FormatException>(() => _slotRepository.Create(newSlotModel)) ;
        }

        [Fact]
        public void CreateNoCollisionSlotTest()
        {
            //Arrange
            var band = new Band()
            {
                Id = Guid.NewGuid()
            };

            var stage = new Stage()
            {
                Id = Guid.NewGuid()
            };

            var newSlotModel1 = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),
                BandId = band.Id,
                StageId = stage.Id
            };
            var newSlotModel2 = new SlotDetailModel()
            {
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3),
                BandId = band.Id,
                StageId = stage.Id
            };

            //Act
            var insertedSlotModel1 = _slotRepository.Create(newSlotModel1);
            var insertedSlotModel2 = _slotRepository.Create(newSlotModel2);

            //Assert
            Assert.NotNull(insertedSlotModel1);
            Assert.NotNull(insertedSlotModel2);

            _slotRepository.Delete(insertedSlotModel1.Id);
            _slotRepository.Delete(insertedSlotModel2.Id);
        }

        [Fact]
        public void CreateCollisionBandSlotTest()
        {
            //Arrange
            var band = new BandDetailModel()
            {
                Name = "Nejaky nazev"
            };
            var stage = new StageDetailModel()
            {
                Name = "Nejaka stage"
            }; var stage1 = new StageDetailModel()
            {
                Name = "Nejaka stage dalsi"
            };
            var stage2 = new StageDetailModel()
            {
                Name = "Nejaka stage dalsi dalsi"
            };
            band = _bandRepository.Create(band);
            stage = _stageRepository.Create(stage);
            stage1 = _stageRepository.Create(stage1);
            stage2 = _stageRepository.Create(stage2);
            
            var newSlotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),
                BandId = band.Id,
                StageId = stage.Id
            };
            var newSlotModelCollisionRight = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(3),
                BandId = band.Id,
                StageId = stage1.Id
            };
            var newSlotModelCollisionLeft = new SlotDetailModel()
            {
                StartTime = DateTime.Now.AddHours(-2),
                EndTime = DateTime.Now,
                BandId = band.Id,
                StageId = stage2.Id
            };

            //Act
            var insertedSlotModel = _slotRepository.Create(newSlotModel);

            //Assert
            Assert.NotNull(insertedSlotModel);
            Assert.Throws<FormatException>(() => _slotRepository.Create(newSlotModelCollisionRight));
            Assert.Throws<FormatException>(() => _slotRepository.Create(newSlotModelCollisionLeft));

            _slotRepository.Delete(insertedSlotModel.Id);
            _stageRepository.Delete(stage.Id);
            _stageRepository.Delete(stage1.Id);
            _stageRepository.Delete(stage2.Id);
            _bandRepository.Delete(band.Id);

        }

        [Fact]
        public void CreateCollisionStageSlotTest()
        {
            //Arrange
            var band = new BandDetailModel()
            {
                Name = "Nejaky nazev"
            };
            var band1 = new BandDetailModel()
            {
                Name = "Nejaky nazev dalsi"
            };
            var band2 = new BandDetailModel()
            {
                Name = "Nejaky nazev dalsi dalsi"
            };
            var stage = new StageDetailModel()
            {
                Name = "Nejaka stage"
            };
            band = _bandRepository.Create(band);
            band1 = _bandRepository.Create(band1);
            band2 = _bandRepository.Create(band2);
            stage = _stageRepository.Create(stage);

            var newSlotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),
                BandId = band.Id,
                StageId = stage.Id
            };
            var newSlotModelCollisionRight = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(3),
                BandId = band1.Id,
                StageId = stage.Id
            };
            var newSlotModelCollisionLeft = new SlotDetailModel()
            {
                StartTime = DateTime.Now.AddHours(-2),
                EndTime = DateTime.Now,
                BandId = band2.Id,
                StageId = stage.Id
            };

            //Act
            var insertedSlotModel = _slotRepository.Create(newSlotModel);

            //Assert
            Assert.NotNull(insertedSlotModel);
            Assert.Throws<FormatException>(() => _slotRepository.Create(newSlotModelCollisionRight));
            Assert.Throws<FormatException>(() => _slotRepository.Create(newSlotModelCollisionLeft));

            _slotRepository.Delete(insertedSlotModel.Id);
            _stageRepository.Delete(stage.Id);
            _bandRepository.Delete(band.Id);
            _bandRepository.Delete(band1.Id);
            _bandRepository.Delete(band2.Id);
        }

        [Fact]
        public void GetSlotByIdTest()
        {
            //Arrange
            var newBandDetailModel = new BandDetailModel()
            {
                Name = "nevim"
            };

            var newStageDetailModel = new StageDetailModel()
            {
                Name = "nevimdsfasd"
            };
            newBandDetailModel = _bandRepository.Create(newBandDetailModel);
            newStageDetailModel = _stageRepository.Create(newStageDetailModel);

            var newSlotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),
                BandId = newBandDetailModel.Id,
                StageId = newStageDetailModel.Id
            };
            var insertedSlotModel = _slotRepository.Create(newSlotModel);

            //Act
            var result = _slotRepository.GetById(insertedSlotModel.Id);

            //Assert
            Assert.NotNull(insertedSlotModel);
            Assert.NotNull(result);
            Assert.Equal(SlotMapper.MapSlotDetailModelToEntity(insertedSlotModel), SlotMapper.MapSlotDetailModelToEntity(result), Slot.SlotComparer);

            _slotRepository.Delete(insertedSlotModel.Id);
            _stageRepository.Delete(newStageDetailModel.Id);
            _bandRepository.Delete(newBandDetailModel.Id);
        }

        [Fact]
        public void GetAllSlotsTest()
        {
            //Arrange
            var newBandDetailModel = new BandDetailModel()
            {
                Name = "nevim"
            };

            var newStageDetailModel = new StageDetailModel()
            {
                Name = "nevimdsfasd"
            };
            newBandDetailModel = _bandRepository.Create(newBandDetailModel);
            newStageDetailModel = _stageRepository.Create(newStageDetailModel);

            var firstNewSlot = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                BandId = newBandDetailModel.Id,
                StageId = newStageDetailModel.Id
            };
            var secondNewSlot = new SlotDetailModel()
            {
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3),
                BandId = newBandDetailModel.Id,
                StageId = newStageDetailModel.Id
            };
            var firstInsertedSlotModel = _slotRepository.Create(firstNewSlot);
            var secondInsertedSlotModel = _slotRepository.Create(secondNewSlot);

            //Act
            var result = _slotRepository.GetAll().ToList();

            //Assert
            Assert.NotNull(firstInsertedSlotModel);
            Assert.NotNull(secondInsertedSlotModel);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(SlotMapper.MapSlotDetailModelToEntity(firstInsertedSlotModel), 
                        SlotMapper.MapSlotDetailModelToEntity(result.FirstOrDefault(s => s.Id == firstInsertedSlotModel.Id)), 
                        Slot.SlotComparer);
            Assert.Equal(SlotMapper.MapSlotDetailModelToEntity(secondInsertedSlotModel), 
                        SlotMapper.MapSlotDetailModelToEntity(result.FirstOrDefault(s => s.Id == secondInsertedSlotModel.Id)), 
                        Slot.SlotComparer);

            _slotRepository.Delete(firstInsertedSlotModel.Id);
            _slotRepository.Delete(secondInsertedSlotModel.Id);
            _stageRepository.Delete(newStageDetailModel.Id);
            _bandRepository.Delete(newBandDetailModel.Id);
        }

        [Fact]
        public void UpdateSlotTest()
        {
            //Arrange
            var newBandDetailModel = new BandDetailModel()
            {
                Name = "nevim"
            };

            var newStageDetailModel = new StageDetailModel()
            {
                Name = "nevimdsfasd"
            };
            newBandDetailModel = _bandRepository.Create(newBandDetailModel);
            newStageDetailModel = _stageRepository.Create(newStageDetailModel);

            var newSlotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),
                BandId = newBandDetailModel.Id,
                StageId = newStageDetailModel.Id
            };

            var insertedSlotModel = _slotRepository.Create(newSlotModel);

            //Act
            insertedSlotModel.EndTime = DateTime.Now;
            _slotRepository.Update(insertedSlotModel);
            var result = _slotRepository.GetById(insertedSlotModel.Id);

            //Assert
            Assert.NotNull(insertedSlotModel);
            Assert.NotNull(result);
            Assert.Equal(SlotMapper.MapSlotDetailModelToEntity(insertedSlotModel), SlotMapper.MapSlotDetailModelToEntity(result), Slot.SlotComparer);

            _slotRepository.Delete(result.Id);
            _stageRepository.Delete(newStageDetailModel.Id);
            _bandRepository.Delete(newBandDetailModel.Id);
        }
        [Fact]
        public void UpdateCollisionSlotTest()
        {
            //Arrange
            var band = new BandDetailModel()
            {
                Name = "Nejaky nazev"
            };
            var stage = new StageDetailModel()
            {
                Name = "Nejaka stage"
            };
            band = _bandRepository.Create(band);
            stage = _stageRepository.Create(stage);

            var newSlotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                BandId = band.Id,
                StageId = stage.Id
            };
            var updateSlotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now.AddHours(1),
                EndTime = DateTime.Now.AddHours(2),
                BandId = band.Id,
                StageId = stage.Id
            };

            //Act
            var insertedSlotModel = _slotRepository.Create(newSlotModel);
            var insertedUpdateSlotModel = _slotRepository.Create(updateSlotModel);
            insertedUpdateSlotModel.StartTime = DateTime.Now;

            //Assert
            Assert.NotNull(insertedSlotModel);
            Assert.NotNull(insertedUpdateSlotModel);
            Assert.Throws<FormatException>(() => _slotRepository.Update(insertedUpdateSlotModel));

            _slotRepository.Delete(insertedSlotModel.Id);
            _slotRepository.Delete(insertedUpdateSlotModel.Id);
            _stageRepository.Delete(stage.Id);
            _bandRepository.Delete(band.Id);
        }

        [Fact]
        public void GetAllSlotsByBandIdTest()
        {
            //Arrange
            var band = new BandDetailModel()
            {
                Name = "Nejaky nazev"
            };
            var stage = new StageDetailModel()
            {
                Name = "Nejaka stage"
            };
            band = _bandRepository.Create(band);
            stage = _stageRepository.Create(stage);

            var firstNewSlot = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                BandId = band.Id,
                StageId = stage.Id
            };
            var secondNewSlot = new SlotDetailModel()
            {
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3),
                BandId = band.Id,
                StageId = stage.Id
            };
            var firstInsertedSlotModel = _slotRepository.Create(firstNewSlot);
            var secondInsertedSlotModel = _slotRepository.Create(secondNewSlot);

            //Act
            var result = _slotRepository.GetAllByBandId(band.Id).ToList();
            var resultEmpty = _slotRepository.GetAllByBandId(Guid.NewGuid());

            //Assert
            Assert.NotNull(firstInsertedSlotModel);
            Assert.NotNull(secondInsertedSlotModel);
            Assert.NotNull(result);
            Assert.NotNull(resultEmpty);
            Assert.Empty(resultEmpty);
            Assert.Equal(2, result.Count);
            Assert.Equal(SlotMapper.MapSlotDetailModelToEntity(firstInsertedSlotModel), 
                        SlotMapper.MapSlotDetailModelToEntity(result.FirstOrDefault(s => s.Id == firstInsertedSlotModel.Id)), 
                        Slot.SlotComparer);
            Assert.Equal(SlotMapper.MapSlotDetailModelToEntity(secondInsertedSlotModel), 
                        SlotMapper.MapSlotDetailModelToEntity(result.FirstOrDefault(s => s.Id == secondInsertedSlotModel.Id)), 
                            Slot.SlotComparer);
            
            _slotRepository.Delete(firstInsertedSlotModel.Id);
            _slotRepository.Delete(secondInsertedSlotModel.Id);
            _stageRepository.Delete(stage.Id);
            _bandRepository.Delete(band.Id);
        }

        [Fact]
        public void GetAllSlotsByStageIdTest()
        {
            //Arrange
            var band = new BandDetailModel()
            {
                Name = "Nejaky nazev"
            };
            var stage = new StageDetailModel()
            {
                Name = "Nejaka stage"
            };
            band = _bandRepository.Create(band);
            stage = _stageRepository.Create(stage);

            var firstNewSlot = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                BandId = band.Id,
                StageId = stage.Id
            };
            var secondNewSlot = new SlotDetailModel()
            {
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3),
                BandId = band.Id,
                StageId = stage.Id
            };
            var firstInsertedSlotModel = _slotRepository.Create(firstNewSlot);
            var secondInsertedSlotModel = _slotRepository.Create(secondNewSlot);

            //Act
            var result = _slotRepository.GetAllByStageId(stage.Id).ToList();
            var resultEmpty = _slotRepository.GetAllByStageId(Guid.NewGuid());

            //Assert
            Assert.NotNull(firstInsertedSlotModel);
            Assert.NotNull(secondInsertedSlotModel);
            Assert.NotNull(result);
            Assert.NotNull(resultEmpty);
            Assert.Empty(resultEmpty);
            Assert.Equal(2, result.Count);
            Assert.Equal(SlotMapper.MapSlotDetailModelToEntity(firstInsertedSlotModel),
                        SlotMapper.MapSlotDetailModelToEntity(result.FirstOrDefault(s => s.Id == firstInsertedSlotModel.Id)),
                        Slot.SlotComparer);
            Assert.Equal(SlotMapper.MapSlotDetailModelToEntity(secondInsertedSlotModel),
                        SlotMapper.MapSlotDetailModelToEntity(result.FirstOrDefault(s => s.Id == secondInsertedSlotModel.Id)),
                        Slot.SlotComparer);

            _slotRepository.Delete(firstInsertedSlotModel.Id);
            _slotRepository.Delete(secondInsertedSlotModel.Id);
            _stageRepository.Delete(stage.Id);
            _bandRepository.Delete(band.Id);
        }

        [Fact]
        public void DeleteSlotsByBandIdTest()
        {
            //Arrange
            var band = new BandDetailModel()
            {
                Id = Guid.NewGuid()
            };

            var firstNewSlot = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                BandId = band.Id,
                StageId = Guid.NewGuid()
            };
            var secondNewSlot = new SlotDetailModel()
            {
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3),
                BandId = band.Id,
                StageId = Guid.NewGuid()
            };
            var firstInsertedSlotModel = _slotRepository.Create(firstNewSlot);
            var secondInsertedSlotModel = _slotRepository.Create(secondNewSlot);

            //Act
            _slotRepository.DeleteByBandId(band.Id);
            var resultEmpty = _slotRepository.GetAllByBandId(band.Id);

            //Assert
            Assert.NotNull(firstInsertedSlotModel);
            Assert.NotNull(secondInsertedSlotModel);
            Assert.NotNull(resultEmpty);
            Assert.Empty(resultEmpty);
        }

        [Fact]
        public void DeleteSlotsByStageIdTest()
        {
            //Arrange
            var stage = new BandDetailModel()
            {
                Id = Guid.NewGuid()
            };

            var firstNewSlot = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                BandId = Guid.NewGuid(),
                StageId = stage.Id
            };
            var secondNewSlot = new SlotDetailModel()
            {
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3),
                BandId = Guid.NewGuid(),
                StageId = stage.Id
            };
            var firstInsertedSlotModel = _slotRepository.Create(firstNewSlot);
            var secondInsertedSlotModel = _slotRepository.Create(secondNewSlot);

            //Act
            _slotRepository.DeleteByStageId(stage.Id);
            var resultEmpty = _slotRepository.GetAllByStageId(stage.Id);

            //Assert
            Assert.NotNull(firstInsertedSlotModel);
            Assert.NotNull(secondInsertedSlotModel);
            Assert.NotNull(resultEmpty);
            Assert.Empty(resultEmpty);
        }

        public void Dispose()
        {
        }
    }
}
