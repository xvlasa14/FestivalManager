using FestivalManager.BL.Models;
using FestivalManager.DAL.Entities;

namespace FestivalManager.BL.Mapper
{
    public static class SlotMapper
    {
        public static SlotDetailModel MapSlotEntityToDetailModel(Slot entity)
        {
            return new SlotDetailModel
            {
                Id = entity.Id,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                StageId = entity.StageId,
                Stage = StageMapper.MapStageEntityToListModel(entity.Stage),
                BandId = entity.BandId,
                Band = BandMapper.MapBandEntityToListModel(entity.Band)
            };
        }

        public static Slot MapSlotDetailModelToEntity(SlotDetailModel model)
        {
            return new Slot
            {
                Id = model.Id,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                StageId = model.StageId,
                BandId = model.BandId
            };
        }
    }
}
