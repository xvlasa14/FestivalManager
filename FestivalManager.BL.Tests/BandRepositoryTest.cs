using FestivalManager.BL.Repositories;
using System;
using System.Linq;
using Xunit;
using FestivalManager.BL.Models;
using FestivalManager.BL.Mapper;
using FestivalManager.DAL;
using FestivalManager.DAL.Entities;
using FestivalManager.DAL.Factories;
using Microsoft.EntityFrameworkCore;

namespace FestivalManager.BL.Tests
{
    [Collection("Sequential")]
    public sealed class BandRepositoryTest: IDisposable
    {
        private readonly BandRepository _bandRepository;
        private readonly SlotRepository _slotRepository;
        private readonly StageRepository _stageRepository;

        private readonly BandDetailModel _bandModelTemplate;

        public BandRepositoryTest()
        {
            IDbContextFactory<FestivalManagerDbContext> dbContextFactory = new DbContextInMemoryFactory(nameof(BandRepositoryTest));
            using FestivalManagerDbContext dbx = dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();
            _bandRepository = new BandRepository(dbContextFactory);
            _slotRepository = new SlotRepository(dbContextFactory);
            _stageRepository = new StageRepository(dbContextFactory);

            _bandModelTemplate = new BandDetailModel()
            {
                Id = Guid.Empty,
                Name = "TestBand",
                Image = "imageurl.jpg",
                Genre = "TestGenre",
                LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                ShortDescription = "Lorem ipsum dolor sit amet.",
                Country = "TestCountry"
            };
        }

        public BandDetailModel CreateTestRecord()
        {
            var newBandModel = _bandModelTemplate;
            newBandModel.Id = Guid.NewGuid();
            var testBandModel = _bandRepository.Create(newBandModel);

            return testBandModel;
        }

        [Fact]
        public void CreateBandTest()
        {
            // Arrange
            var newBandModel = _bandModelTemplate;
            newBandModel.Id = Guid.NewGuid();

            // Act
            var testBandModel = _bandRepository.Create(newBandModel);

            // Assert
            Assert.NotNull(testBandModel);
            Assert.Equal(BandMapper.MapBandDetailModelToEntity(testBandModel), BandMapper.MapBandDetailModelToEntity(newBandModel), Band.BandComparer);

            _bandRepository.Delete(testBandModel.Id);
        }

        [Fact]
        public void GetBandByIdTest()
        {
            // Arrange
            var firstBandModel = _bandModelTemplate;
            firstBandModel.Id = Guid.NewGuid();
            var firstTestBandModel = _bandRepository.Create(firstBandModel);

            var secondBandModel = _bandModelTemplate;
            secondBandModel.Id = Guid.NewGuid();
            var secondTestBandModel = _bandRepository.Create(secondBandModel);

            // Act
            var getTestFirst = _bandRepository.GetById(firstBandModel.Id);
            var getTestSecond = _bandRepository.GetById(secondBandModel.Id);

            // Assert
            Assert.Equal(firstBandModel.Id, getTestFirst.Id);
            Assert.Equal(secondBandModel.Id, getTestSecond.Id);

            _bandRepository.Delete(firstTestBandModel.Id);
            _bandRepository.Delete(secondTestBandModel.Id);

        }
        
        [Fact]
        public void GetAllBandsTest()
        {
            // Arrange
            var firstBandDetail = CreateTestRecord();
            var secondBandDetail = CreateTestRecord();
            var thirdBandDetail = CreateTestRecord();

            // Act
            var getAllTest = _bandRepository.GetAll();

            // Assert
            Assert.NotNull(getAllTest);
            Assert.Equal(3, getAllTest.Count());

            _bandRepository.Delete(firstBandDetail.Id);
            _bandRepository.Delete(secondBandDetail.Id);
            _bandRepository.Delete(thirdBandDetail.Id);
        }
        
        [Fact]
        public void GetSlotsForBandTest()
        {
            // Arrange
            var testBandModel = CreateTestRecord();

            var testStageModel = new StageDetailModel()
            {
                Name = "sdafsdfasdf"
            };

            testStageModel = _stageRepository.Create(testStageModel);

            var testSlotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),
                BandId = testBandModel.Id,
                StageId = testStageModel.Id
            };
            
            var newSlotModel = _slotRepository.Create(testSlotModel);

            // Act
            var testGetBand = _bandRepository.GetById(testBandModel.Id);

            // Assert
            Assert.NotNull(newSlotModel);
            Assert.Equal(testBandModel.Id, testGetBand.Id);
            Assert.Equal(testGetBand.Slots.First().Id, newSlotModel.Id);

            _bandRepository.Delete(testBandModel.Id);
            _stageRepository.Delete(testStageModel.Id);
        }

        [Fact]
        public void GetStageForBandTest()
        {
            // Arrange
            var testBandModel = CreateTestRecord();

            var testStageModel = new StageDetailModel()
            {
                Name = "sdafsdfasdf"
            };

            testStageModel = _stageRepository.Create(testStageModel);

            var testSlotModel = new SlotDetailModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),
                BandId = testBandModel.Id,
                StageId = testStageModel.Id
            };

            var newSlotModel = _slotRepository.Create(testSlotModel);

            // Act
            var testGetBand = _bandRepository.GetById(testBandModel.Id);

            // Assert
            Assert.NotNull(newSlotModel);
            Assert.Equal(testBandModel.Id, testGetBand.Id);
            Assert.Equal(testGetBand.Slots.First().Stage.Id, testStageModel.Id);

            _bandRepository.Delete(testBandModel.Id);
            _stageRepository.Delete(testStageModel.Id);
        }
       
        [Fact]
        public void UpdateBandTest()
        {
            // Arrange
            var testBandModel = CreateTestRecord();

            // Act
            testBandModel.Country = "Updated country";
            _bandRepository.Update(testBandModel);

            // Assert
            Assert.Equal("Updated country", testBandModel.Country);

            _bandRepository.Delete(testBandModel.Id);
        }
       
        public void Dispose()
        {
        }
    }
}

