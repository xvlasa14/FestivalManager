using System;
using System.Linq;
using FestivalManager.BL.Mapper;
using FestivalManager.BL.Models;
using FestivalManager.BL.Repositories;
using FestivalManager.DAL;
using FestivalManager.DAL.Entities;
using FestivalManager.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FestivalManager.BL.Tests
{
    [Collection("Sequential")]
    public class StageRepositoryTest: IDisposable
    {
        private readonly StageRepository _stageRepository;
        private readonly BandRepository _bandRepository;
        private readonly SlotRepository _slotRepository;

        public StageRepositoryTest()
        {
            IDbContextFactory<FestivalManagerDbContext> dbContextFactory = new DbContextInMemoryFactory(nameof(BandRepositoryTest));
            using FestivalManagerDbContext dbx = dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();
            _bandRepository = new BandRepository(dbContextFactory);
            _slotRepository = new SlotRepository(dbContextFactory);
            _stageRepository = new StageRepository(dbContextFactory);
        }

        [Fact]
        public void CreateStageTest()
        {
            //Arrange
            var model = new StageDetailModel()
            {
                Name = "Novohradska",
                Image = "Some URL",
                Info = "Na jizni strane arealu"
            };

            //Act
            var returnedModel = _stageRepository.Create(model);

            //Assert
            Assert.NotNull(returnedModel);

            _stageRepository.Delete(returnedModel.Id);
        }


        [Fact]
        public void UpdateStageTest()
        {
            //Arrange
            var model = new StageDetailModel()
            {
                Name = "Novohradska",
                Image = "Some URL",
                Info = "Na jizni strane arealu"
            };
            var returnedModel = _stageRepository.Create(model);
            
            //Act
            returnedModel.Name = "Star Trek";
            _stageRepository.Update(returnedModel);
            var returnedModel1 = _stageRepository.GetById(returnedModel.Id);

            //Assert
            Assert.NotNull(returnedModel1);
            Assert.NotNull(returnedModel);
            Assert.Equal(StageMapper.MapStageDetailModelToEntity(returnedModel1), StageMapper.MapStageDetailModelToEntity(returnedModel), Stage.StageComparer);

            _stageRepository.Delete(returnedModel.Id);
        }

        [Fact]
        public void GetAllStagesTest()
        {
            //Arrange
            var model = new StageDetailModel()
            {
                Name = "Novohradska",
                Image = "Some URL",
                Info = "Na jizni strane arealu"
            };

            var model1 = new StageDetailModel()
            {
                Name = "Krasna Olomouc ",
                Image = "Some1 URL",
                Info = "Nekde na Morave"
            };
            var returnedModel = _stageRepository.Create(model);
            var returnedModel1 = _stageRepository.Create(model1);

            //Act
            var result = _stageRepository.GetAll();

            //Assert
            Assert.NotNull(returnedModel);
            Assert.NotNull(returnedModel1);
            Assert.Equal(2,result.Count());

            _stageRepository.Delete(returnedModel.Id);
            _stageRepository.Delete(returnedModel1.Id);
        }

        [Fact]
        public void GetStageByIdTest()
        {
            //Arrange
            var model = new StageDetailModel()
            {
                Name = "Novohradska",
                Image = "Some URL",
                Info = "Na jizni strane arealu"
            };

            var model1 = new StageDetailModel()
            {
                Name = "Krasna Olomouc ",
                Image = "Some1 URL",
                Info = "Nekde na Morave"
            };
            var returnedModel = _stageRepository.Create(model);
            var returnedModel1 = _stageRepository.Create(model1);

            //Act
            var result = _stageRepository.GetById(returnedModel.Id);
            var result1 = _stageRepository.GetById(returnedModel1.Id);

            //Assert
            Assert.NotNull(returnedModel);
            Assert.NotNull(returnedModel1);
            Assert.Equal(StageMapper.MapStageDetailModelToEntity(returnedModel), StageMapper.MapStageDetailModelToEntity(result), Stage.StageComparer);
            Assert.Equal(StageMapper.MapStageDetailModelToEntity(returnedModel1), StageMapper.MapStageDetailModelToEntity(result1), Stage.StageComparer);

            _stageRepository.Delete(returnedModel.Id);
            _stageRepository.Delete(returnedModel1.Id);
        }

        [Fact]
        public void GetSlotsForStageTest()
        {
            //Arrange
            var stageModel = new StageDetailModel()
            {
                Name = "Novohradska",
                Image = "Some URL",
                Info = "Na jizni strane arealu"
            };
            var bandModel = new BandDetailModel()
            {
                Name = "Jmeno",
                Country = "Ceska Republika",
                LongDescription = "Snad je Ceska Republika s velkym C a R",
                Genre = "Rock",
                Image = "URL",
                ShortDescription = "Some text"
            };
            var returnedStageModel = _stageRepository.Create(stageModel);
            var returnedBandModel = _bandRepository.Create(bandModel);

            var slotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                BandId = returnedBandModel.Id,
                StageId = returnedStageModel.Id
            };
            var returnedSlotModel = _slotRepository.Create(slotModel);

            //Act
            var result = _stageRepository.GetById(returnedStageModel.Id);

            //Assert
            Assert.NotNull(returnedStageModel);
            Assert.NotNull(returnedSlotModel);
            Assert.NotNull(returnedBandModel);
            Assert.Equal(SlotMapper.MapSlotDetailModelToEntity(returnedSlotModel),
                SlotMapper.MapSlotDetailModelToEntity(result.Slots.First()), Slot.SlotComparer);

            _slotRepository.Delete(returnedSlotModel.Id);
            _stageRepository.Delete(returnedStageModel.Id);
            _bandRepository.Delete(returnedBandModel.Id);
        }

        [Fact]
        public void GetBandsForStageTest()
        {
            //Arrange
            var stageModel = new StageDetailModel()
            {
                Name = "Novohradska",
                Image = "Some URL",
                Info = "Na jizni strane arealu"
            };

            var bandModel = new BandDetailModel()
            {
                Name = "Jmeno",
                Country = "Ceska Republika",
                LongDescription = "Snad je Ceska Republika s velkym C a R",
                Genre = "Rock",
                Image = "URL",
                ShortDescription = "Some text"
            };
            var returnedStageModel = _stageRepository.Create(stageModel);
            var returnedBandModel = _bandRepository.Create(bandModel);

            var slotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                BandId = returnedBandModel.Id,
                StageId = returnedStageModel.Id
            };
            var returnedSlotModel = _slotRepository.Create(slotModel);

            //Act
            var result = _stageRepository.GetById(returnedStageModel.Id);

            //Assert
            Assert.NotNull(returnedStageModel);
            Assert.NotNull(returnedSlotModel);
            Assert.NotNull(returnedBandModel);

            Assert.Equal(returnedBandModel.Id,result.Slots.First().Band.Id);

            _slotRepository.Delete(returnedSlotModel.Id);
            _stageRepository.Delete(returnedStageModel.Id);
            _bandRepository.Delete(returnedBandModel.Id);
        }


        public void Dispose()
        {
        }
    }


}
