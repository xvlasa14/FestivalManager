using FestivalManager.App.Commands;
using FestivalManager.App.Extensions;
using FestivalManager.App.Messages;
using FestivalManager.App.Services;
using FestivalManager.App.ViewModels.Interfaces;
using FestivalManager.App.Wrappers;
using FestivalManager.BL.Models;
using FestivalManager.BL.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FestivalManager.App.ViewModels
{
    public class BandsViewModel : ViewModelBase, IBandsViewModel
    {
        public ICommand AddBandCommand { get; }
        public ICommand BandSelectedCommand { get; }
        private readonly IBandRepository _bandRepository;
        private readonly IMediator _mediator;
        public ObservableCollection<BandListModel> Bands { get; set; } = new ();

        public BandsViewModel(IMediator mediator, IBandRepository bandRepository)
        {
            _mediator = mediator;
            _bandRepository = bandRepository;

            AddBandCommand = new RelayCommand(AddBand);
            BandSelectedCommand = new RelayCommand<BandListModel>(BandSelected);

            _mediator.Register<AddMessage<BandWrapper>>(AddBand);
            _mediator.Register<DeleteMessage<BandWrapper>>(RemoveBand);
            _mediator.Register<UpdateMessage<BandWrapper>>(EditBand);

            Load();
        }

        private void EditBand(UpdateMessage<BandWrapper> _) => Load();
        private void RemoveBand(DeleteMessage<BandWrapper> _) => Load();
        private void AddBand(AddMessage<BandWrapper> _) => Load();
        public void AddBand() => _mediator.Send(new ChangeViewAddMessage<BandWrapper>());
        public void BandSelected(BandListModel band) 
        {
            _mediator.Send(new SelectedMessage<BandWrapper>());
            _mediator.Send(new DetailViewMessage<BandWrapper>() { Id = band.Id });
        } 

        public void Load()
        {
            Bands.Clear();
            var bands = _bandRepository.GetAll();
            Bands.AddRange(bands);
        }
    }
}
