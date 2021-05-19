using System.Linq;
using FestivalManager.BL.Models;
using FestivalManager.DAL.Entities;

namespace FestivalManager.BL.Mapper
{
    public static class StageMapper
    {
        public static StageListModel MapStageEntityToListModel(Stage entity) =>
            entity == null
                ? null
                : new StageListModel()
                {
                    Id = entity.Id,
                    Name = entity.Name
                };

        public static StageDetailModel MapStageEntityToDetailModel(Stage entity)
        {
            return new StageDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Image = entity.Image,
                Info = entity.Info,
                Slots = entity.Slots.Select(SlotMapper.MapSlotEntityToDetailModel).ToList()
            };
        }

        public static Stage MapStageDetailModelToEntity(StageDetailModel model)
        {
            return new Stage
            {
                Id = model.Id,
                Name = model.Name,
                Image = model.Image,
                Info = model.Info
            };
        }

    }
}
