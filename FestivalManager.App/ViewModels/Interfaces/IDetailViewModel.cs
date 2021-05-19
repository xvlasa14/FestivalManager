using System;

namespace FestivalManager.App.ViewModels.Interfaces
{
    public interface IDetailViewModel<TDetail> : IViewModel
    {
        TDetail Model { get; set; }

        void Load(Guid id);
    }
}
