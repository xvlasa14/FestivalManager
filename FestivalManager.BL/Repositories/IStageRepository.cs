using System;
using System.Collections.Generic;
using FestivalManager.BL.Models;

namespace FestivalManager.BL.Repositories
{
    public interface IStageRepository
    {
        IEnumerable<StageListModel> GetAll();
        StageDetailModel GetById(Guid id);
        StageDetailModel Create (StageDetailModel model);
        void Update(StageDetailModel model);
        void Delete(Guid id);
    }
}
