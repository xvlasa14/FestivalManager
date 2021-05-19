using System;
using System.Collections.Generic;
using FestivalManager.BL.Models;

namespace FestivalManager.BL.Repositories
{
    public interface IBandRepository
    {
        IEnumerable<BandListModel> GetAll();
        BandDetailModel GetById(Guid id);
        BandDetailModel Create(BandDetailModel model);
        void Update(BandDetailModel model);
        void Delete(Guid id);
    }
}
