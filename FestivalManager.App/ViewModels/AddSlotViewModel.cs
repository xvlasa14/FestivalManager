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
    public class AddSlotViewModel : ViewModelBase, IAddSlotViewModel
    {
        public SlotWrapper Model { get; set; }
        public ICommand AddSlotCommand { get; }
        public ICommand CancelCommand { get; }
        private readonly ISlotRepository _slotRepository;
        private readonly IStageRepository _stageRepository;
        private readonly IBandRepository _bandRepository;
        private readonly IMediator _mediator;
        public ObservableCollection<StageListModel> Stages { get; } = new();
        public ObservableCollection<BandListModel> Bands { get; } = new();
        public StageListModel SelectedStage { get; set; }
        public BandListModel SelectedBand { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }

        public AddSlotViewModel(IMediator mediator, ISlotRepository slotRepository, IStageRepository stageRepository, IBandRepository bandRepository)
        {
            _mediator = mediator;
            _slotRepository = slotRepository;
            _stageRepository = stageRepository;
            _bandRepository = bandRepository;

            AddSlotCommand = new RelayCommand(AddSlot);
            CancelCommand = new RelayCommand(Cancel);

            Model = new SlotDetailModel();
            StartDay = DateTime.Now;
            EndDay = DateTime.Now;

            Load();
        }

        private void AddSlot()
        {
            if (new object[] { SelectedStage, SelectedBand}.Any(o => o == null))
            {
                MessageBox.Show("Band and Stage must be selected.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            Model.StageId = SelectedStage.Id;
            Model.BandId = SelectedBand.Id;
            Model.StartTime = StartDay.Date + Model.StartTime.TimeOfDay;
            Model.EndTime = EndDay.Date + Model.EndTime.TimeOfDay;
            try
            {
                Model = _slotRepository.Create(Model.Model);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid slot time. Check for a collision.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            _mediator.Send(new AddMessage<SlotWrapper>());
            _mediator.Send(new ChangeViewMessage<SlotWrapper>());
        }

        private void Cancel() => _mediator.Send(new ChangeViewMessage<SlotWrapper>());

        public void Load()
        {
            Stages.Clear();
            var stages = _stageRepository.GetAll();
            Stages.AddRange(stages);

            Bands.Clear();
            var bands = _bandRepository.GetAll();
            Bands.AddRange(bands);
        }
    }


}
