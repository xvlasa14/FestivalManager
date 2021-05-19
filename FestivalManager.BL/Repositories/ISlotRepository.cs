using System;
using System.Collections.Generic;
using FestivalManager.BL.Models;

namespace FestivalManager.BL.Repositories
{
    public interface ISlotRepository
    {
        IEnumerable<SlotDetailModel> GetAll();
        SlotDetailModel GetById(Guid id);
        SlotDetailModel Create(SlotDetailModel model);
        void Update(SlotDetailModel model);
        IEnumerable<SlotDetailModel> GetAllByBandId(Guid id);
        IEnumerable<SlotDetailModel> GetAllByStageId(Guid id);
        void DeleteByStageId(Guid id);
        void DeleteByBandId(Guid id);
        void Delete(Guid id);
    }
}
