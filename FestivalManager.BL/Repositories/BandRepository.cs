using System;
using System.Collections.Generic;
using System.Linq;
using FestivalManager.BL.Mapper;
using FestivalManager.BL.Models;
using FestivalManager.DAL;
using Microsoft.EntityFrameworkCore;

namespace FestivalManager.BL.Repositories
{
    public class BandRepository : IBandRepository
    {
        private readonly IDbContextFactory<FestivalManagerDbContext> _dbContextFactory;

        public BandRepository(IDbContextFactory<FestivalManagerDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<BandListModel> GetAll()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Bands
                .Include(b=> b.Slots)
                .ThenInclude(s=> s.Stage)
                .Select(b => BandMapper.MapBandEntityToListModel(b))
                .ToList();
        }

        public BandDetailModel GetById(Guid id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entity = dbContext.Bands
                .Include(b=> b.Slots)
                .ThenInclude(s=> s.Stage)
                .First(b => b.Id == id);
            return BandMapper.MapBandEntityToDetailModel(entity);
        }

        public BandDetailModel Create(BandDetailModel model)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entity = BandMapper.MapBandDetailModelToEntity(model);
            dbContext.Bands.Add(entity);
            dbContext.SaveChanges();
            return BandMapper.MapBandEntityToDetailModel(entity);
        }

        public void Update(BandDetailModel model)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entity = BandMapper.MapBandDetailModelToEntity(model);
            dbContext.Bands.Update(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var slotRepository = new SlotRepository(_dbContextFactory);
            slotRepository.DeleteByBandId(id);
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entity = dbContext.Bands.First(b => b.Id == id);
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}