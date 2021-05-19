using System.Linq;
using System.Windows;
using System.Windows.Input;
using FestivalManager.App.Commands;
using FestivalManager.App.Messages;
using FestivalManager.App.Services;
using FestivalManager.App.ViewModels.Interfaces;
using FestivalManager.App.Wrappers;
using FestivalManager.BL.Models;
using FestivalManager.BL.Repositories;

namespace FestivalManager.App.ViewModels
{
    public class AddBandViewModel : ViewModelBase, IAddBandViewModel
    {
        public BandWrapper Model { get; set; }
        public ICommand AddBandCommand { get; }
        public ICommand CancelCommand { get; }
        private readonly IBandRepository _bandRepository;
        private readonly IMediator _mediator;

        public AddBandViewModel(IMediator mediator, IBandRepository bandRepository)
        {
            _mediator = mediator;
            _bandRepository = bandRepository;

            AddBandCommand = new RelayCommand(AddBand);
            CancelCommand = new RelayCommand(Cancel);

            Model = new BandDetailModel();
        }

        private void AddBand()
        {
            if (new object [] {Model.Name, Model.Country, Model.Genre, Model.ShortDescription}.Any(o => o is null or ""))
            {
                MessageBox.Show("Name, Genre, Country and Short description must be selected.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            Model = _bandRepository.Create(Model.Model);
            _mediator.Send(new AddMessage<BandWrapper>{Model = Model});
            _mediator.Send(new ChangeViewMessage<BandWrapper>());
        }

        private void Cancel() => _mediator.Send(new ChangeViewMessage<BandWrapper>());
    }
}
