using System;
using System.Collections.Generic;
using System.Linq;
using FestivalManager.BL.Mapper;
using FestivalManager.BL.Models;
using FestivalManager.BL.Logic;
using FestivalManager.DAL;
using Microsoft.EntityFrameworkCore;

namespace FestivalManager.BL.Repositories
{
    public class SlotRepository : ISlotRepository
    {
        private readonly IDbContextFactory<FestivalManagerDbContext> _dbContextFactory;

        public SlotRepository(IDbContextFactory<FestivalManagerDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<SlotDetailModel> GetAll()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Slots
                .Include(s => s.Band)
                .Include(s => s.Stage)
                .Select(s => SlotMapper.MapSlotEntityToDetailModel(s))
                .ToList();
        }

        public SlotDetailModel GetById(Guid id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entity = dbContext.Slots
                .Include(s => s.Band)
                .Include(s => s.Stage)
                .First(s => s.Id == id);
            return SlotMapper.MapSlotEntityToDetailModel(entity);
        }

        public SlotDetailModel Create(SlotDetailModel model)
        {
            if (SlotTimeComparer.IsNotTimeCollision(model, this))         
            {
                using var dbContext = _dbContextFactory.CreateDbContext();
                var entity = SlotMapper.MapSlotDetailModelToEntity(model);
                dbContext.Slots.Add(entity);
                dbContext.SaveChanges();
                return SlotMapper.MapSlotEntityToDetailModel(entity);
            }
            throw new FormatException();
        }

        public void Update(SlotDetailModel model)
        {
            if (SlotTimeComparer.IsNotTimeCollision(model, this, true))
            {
                using var dbContext = _dbContextFactory.CreateDbContext();
                var entity = SlotMapper.MapSlotDetailModelToEntity(model);
                dbContext.Slots.Update(entity);
                dbContext.SaveChanges();
            }
            else
            {
                throw new FormatException();
            }
        }

        public IEnumerable<SlotDetailModel> GetAllByBandId(Guid id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Slots
                .Include(s => s.Band)
                .Include(s => s.Stage)
                .Where(s => s.BandId == id)
                .Select(s => SlotMapper.MapSlotEntityToDetailModel(s))
                .ToList();
        }

        public IEnumerable<SlotDetailModel> GetAllByStageId(Guid id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Slots.Where(s => s.StageId == id)
                .Include(s => s.Band)
                .Include(s => s.Stage)
                .Select(s => SlotMapper.MapSlotEntityToDetailModel(s))
                .ToList();
        }

        public void DeleteByStageId(Guid id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entities = dbContext.Slots.Where(s => s.StageId == id);
            dbContext.RemoveRange(entities);
            dbContext.SaveChanges();
        }

        public void DeleteByBandId(Guid id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entities = dbContext.Slots.Where(s => s.BandId == id);
            dbContext.RemoveRange(entities);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entity = dbContext.Slots.First(s => s.Id == id);
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
