using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using FestivalManager.App.Commands;
using FestivalManager.App.Extensions;
using FestivalManager.App.Messages;
using FestivalManager.App.Services;
using FestivalManager.App.ViewModels.Interfaces;
using FestivalManager.App.Wrappers;
using FestivalManager.BL.Models;
using FestivalManager.BL.Repositories;

namespace FestivalManager.App.ViewModels
{
    public class BandDetailViewModel : ViewModelBase, IBandDetailViewModel
    {
        public BandWrapper Model { get; set; }
        public ICommand EditBandCommand { get;}
        public ICommand RemoveBandCommand { get;}
        public ICommand RevertCommand { get;}
        private readonly IBandRepository _bandRepository;
        private readonly ISlotRepository _slotRepository;
        private readonly IMediator _mediator;
        public ObservableCollection<SlotDetailModel> Slots { get; set; } = new();


        public BandDetailViewModel(IMediator mediator, IBandRepository bandRepository, ISlotRepository slotRepository)
        {
            _mediator = mediator;
            _bandRepository = bandRepository;
            _slotRepository = slotRepository;

            EditBandCommand = new RelayCommand(EditBand);
            RemoveBandCommand = new RelayCommand(RemoveBand);
            RevertCommand = new RelayCommand(Revert);

            _mediator.Register<DetailViewMessage<BandWrapper>>(BandLoad);
        }

        private void Revert() => _mediator.Send(new ChangeViewMessage<BandWrapper>());

        private void RemoveBand()
        {
            _bandRepository.Delete(Model.Id);
            _mediator.Send(new ChangeViewMessage<BandWrapper>());
            _mediator.Send(new DeleteMessage<BandWrapper>());
        }

        private void EditBand()
        {
            if (new object[] { Model.Name, Model.Country, Model.Genre, Model.ShortDescription}.Any(o => o is null or ""))
            {
                MessageBox.Show("Name, Genre, Country and Short description must be selected.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            _bandRepository.Update(Model.Model);
            _mediator.Send(new ChangeViewMessage<BandWrapper>());
            _mediator.Send(new UpdateMessage<BandWrapper>());
        }

        private void BandLoad(DetailViewMessage<BandWrapper> message) => Load(message.Id);

        public void Load(Guid id)
        {
            Model = _bandRepository.GetById(id);

            Slots.Clear();
            var slots = _slotRepository.GetAllByBandId(Model.Id)
                .OrderBy(s=>s.StartTime);
            Slots.AddRange(slots);
        }
    }
}
