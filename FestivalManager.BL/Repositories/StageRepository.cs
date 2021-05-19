using System;
using System.Collections.Generic;
using System.Linq;
using FestivalManager.BL.Mapper;
using FestivalManager.BL.Models;
using FestivalManager.DAL;
using Microsoft.EntityFrameworkCore;

namespace FestivalManager.BL.Repositories
{
    public class StageRepository : IStageRepository
    {
        private readonly IDbContextFactory<FestivalManagerDbContext> _dbContextFactory;

        public StageRepository(IDbContextFactory<FestivalManagerDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<StageListModel> GetAll()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Stages
                .Include(s=> s.Slots)
                .ThenInclude(s=> s.Band)
                .Select(s => StageMapper.MapStageEntityToListModel(s))
                .ToList();
        }

        public StageDetailModel GetById(Guid id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entity = dbContext.Stages
                .Include(s => s.Slots)
                .ThenInclude(s => s.Band)
                .First(s => s.Id == id);
            return StageMapper.MapStageEntityToDetailModel(entity);
        }

        public StageDetailModel Create(StageDetailModel model)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entity = StageMapper.MapStageDetailModelToEntity(model);
            dbContext.Stages.Add(entity);
            dbContext.SaveChanges();
            return StageMapper.MapStageEntityToDetailModel(entity);
        }

        public void Update(StageDetailModel model)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entity = StageMapper.MapStageDetailModelToEntity(model);
            dbContext.Stages.Update(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var slotRepository = new SlotRepository(_dbContextFactory);
            slotRepository.DeleteByStageId(id);
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entity = dbContext.Stages.First(s => s.Id == id);
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
