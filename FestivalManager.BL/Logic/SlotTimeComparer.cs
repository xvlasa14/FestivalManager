using System;
using System.Collections.Generic;
using System.Linq;
using FestivalManager.BL.Models;
using FestivalManager.BL.Repositories;

namespace FestivalManager.BL.Logic
{
    public static class SlotTimeComparer
    {
        public static bool IsNotTimeCollision(SlotDetailModel model, SlotRepository repository, bool update = false)
        {
            if (DateTime.Compare(model.StartTime, model.EndTime) >= 0) return false;

            var allBands = repository.GetAllByBandId(model.BandId);
            var allStages = repository.GetAllByStageId(model.StageId);
            if (update)
            {
                allBands = allBands.Where(s => s.Id != model.Id);
                allStages = allStages.Where(s => s.Id != model.Id);
            }

            return NotCollisionWithList(model, allBands) 
                   && NotCollisionWithList(model, allStages);
        }

        private static bool NotCollisionWithList(SlotDetailModel model, IEnumerable<SlotDetailModel> allSlots)
        {
            foreach (var slot in allSlots)
            {
                if (DateTime.Compare(slot.StartTime, model.EndTime) <= 0 &&
                    DateTime.Compare(slot.EndTime, model.StartTime) >= 0)
                    return false;
            }
            return true;
        }
    }
}
