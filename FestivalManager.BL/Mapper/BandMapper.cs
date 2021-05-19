using System.Linq;
using FestivalManager.BL.Models;
using FestivalManager.DAL.Entities;

namespace FestivalManager.BL.Mapper
{
    public static class BandMapper
    {
        public static BandListModel MapBandEntityToListModel(Band entity) =>
            entity == null
                ? null
                : new BandListModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Genre = entity.Genre,
                    Info = entity.ShortDescription
                };

        public static BandDetailModel MapBandEntityToDetailModel(Band entity)
        {
            return new BandDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Image = entity.Image,
                Genre = entity.Genre,
                LongDescription = entity.LongDescription,
                ShortDescription = entity.ShortDescription,
                Country = entity.Country,
                Slots = entity.Slots.Select(SlotMapper.MapSlotEntityToDetailModel).ToList()
            };
        }

        public static Band MapBandDetailModelToEntity(BandDetailModel model)
        {
            return new Band
            {
                Id = model.Id,
                Name = model.Name,
                Image = model.Image,
                Genre = model.Genre,
                LongDescription = model.LongDescription,
                ShortDescription = model.ShortDescription,
                Country = model.Country
            };
        }

    }
}
