using System;
using Xunit;
using System.Collections.Generic;
using FestivalManager.DAL.Entities;
using System.Text;
using System.Linq;
using FestivalManager.DAL.Factories;
using Microsoft.EntityFrameworkCore;

namespace FestivalManager.DAL.Tests
{


    public class DbContextTests : IDisposable
    {
        private readonly DbContextInMemoryFactory _dbContextFactory;

        private readonly FestivalManagerDbContext _dbContextTestSut;

        public DbContextTests()
        {
            _dbContextFactory = new DbContextInMemoryFactory(nameof(DbContextTests));
            _dbContextTestSut = _dbContextFactory.CreateDbContext();
            _dbContextTestSut.Database.EnsureCreated();

        }
        
        [Fact]
        public void EntityBandTest()
        {
            //Arrange
            var bandExpected = new Band()
            {
                Name = "Jmeno kapely",
                Image = "Obrazek kapely",
                Genre = "Rock",
                LongDescription = "Detailni popis",
                ShortDescription = "Kratky popis",
                Country = "Czechia",
                Slots = { new Slot()
                {
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(90),
                }}
            };

            //Act
            _dbContextTestSut.Bands.Add(bandExpected);
            _dbContextTestSut.SaveChanges();

            //Assert
            using var dbx = _dbContextFactory.CreateDbContext();
            var bandFromDb = dbx.Bands.Include(b => b.Slots).FirstOrDefault(b => b.Id == bandExpected.Id);

            Assert.Equal(bandExpected, bandFromDb, Band.BandComparer);
        }

        [Fact]
        public void EntityStageTest()
        {
            //Arrange
            var stageExpected = new Stage()
            {
                Name = "Stage VUT",
                Info = "Stage se nachazi v Brne",
                Image = "Obrazek stage",
                Slots = { new Slot()
                {
                    StartTime = DateTime.Today,
                    EndTime = DateTime.Today.AddDays(1)
                }}
            };

            //Act
            _dbContextTestSut.Stages.Add(stageExpected);
            _dbContextTestSut.SaveChanges();

            //Assert
            using var dbx = _dbContextFactory.CreateDbContext();
            var stageFromDb = dbx.Stages.Include(s => s.Slots).FirstOrDefault(s => s.Id == stageExpected.Id);

            Assert.Equal(stageExpected, stageFromDb, Stage.StageComparer);
        }

        [Fact]
        public void EntitySlotTest()
        {
            //Arrange
            var slotExpected = new Slot()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(90),
                Band = new Band()
                {
                    Name = "Jmeno kapely",
                    Image = "Obrazek kapely",
                    Genre = "Rock",
                    LongDescription = "Detailni popis",
                    ShortDescription = "Kratky popis",
                    Country = "Czechia",
                },
                Stage = new Stage()
                {
                    Name = "Stage VUT",
                    Info = "Stage se nachazi v Brne",
                    Image = "Obrazek stage",
                }
            };

            //Act
            _dbContextTestSut.Slots.Add(slotExpected);
            _dbContextTestSut.SaveChanges();

            //Assert
            using var dbx = _dbContextFactory.CreateDbContext();
            var slotFromDb = dbx.Slots.Include(s => s.Band).Include(s => s.Stage).First(s => s.Id == slotExpected.Id);

            Assert.Equal(slotExpected, slotFromDb, Slot.SlotComparer);
        }

        [Fact]
        public void EntityBandIncludeSlotTest()
        {
            //Arrange
            var band = new Band()
            {
                Name = "Jmeno kapely",
                Image = "Obrazek kapely",
                Genre = "Rock",
                LongDescription = "Detailni popis",
                ShortDescription = "Kratky popis",
                Country = "Czechia",
                Slots =
                {
                    new Slot()
                    {
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddMinutes(90),
                        Stage = new Stage()
                        {
                            Name = "Stage VUT",
                            Info = "Stage se nachazi v Brne",
                            Image = "Obrazek stage",
                        }
                    }
                }
            };

            var slotExpected = band.Slots.First();
            //Act
            _dbContextTestSut.Bands.Add(band);
            _dbContextTestSut.SaveChanges();

            //Assert
            using var dbx = _dbContextFactory.CreateDbContext();
            var bandFromDb = dbx.Bands.Include(b => b.Slots).ThenInclude(s => s.Stage).Single(b => b.Id == band.Id);

            Assert.Equal(slotExpected, bandFromDb.Slots.First(), Slot.SlotComparer);

        }

        [Fact]
        public void EntityStageIncludeSlotTest()
        {
            var stage = new Stage()
            {
                Name = "Stage VUT",
                Info = "Stage se nachazi v Brne",
                Image = "Obrazek stage",
                Slots =
                {
                    new Slot()
                    {

                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddMinutes(90),
                        Band = new Band()
                        {
                            Name = "Jmeno kapely",
                            Image = "Obrazek kapely",
                            Genre = "Rock",
                            LongDescription = "Detailni popis",
                            ShortDescription = "Kratky popis",
                            Country = "Czechia",
                        }
                    }
                }
            };

            var slotExpected = stage.Slots.First();
            //Act
            _dbContextTestSut.Stages.Add(stage);
            _dbContextTestSut.SaveChanges();

            //Assert
            using var dbx = _dbContextFactory.CreateDbContext();
            var stageFromDbNext =
                dbx.Stages.Include(s => s.Slots).ThenInclude(s => s.Band).Single(s => s.Id == stage.Id);

            Assert.Equal(slotExpected, stageFromDbNext.Slots.First(), Slot.SlotComparer);
        }

        public void Dispose()
        {
            _dbContextTestSut.Dispose();
        }
    }
}
