using System.Collections.ObjectModel;
using System.Linq;
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
    public class ProgramViewModel : ViewModelBase, IProgramViewModel
    {
        public ICommand SlotSelectedCommand { get; }
        public ICommand AddSlotCommand { get; }
        private readonly ISlotRepository _slotRepository;
        private readonly IStageRepository _stageRepository;
        private readonly IMediator _mediator;
        public ObservableCollection<SlotDetailModel> Slots { get; set; } = new ();
        public ObservableCollection<StageListModel> Stages { get; set; } = new ();

        private StageListModel _selectedStage;
        public StageListModel SelectedStage
        {
            get => _selectedStage;
            set
            {
                _selectedStage = value;
                GetSlotsForSelectedStage();
            }
        }

        public ProgramViewModel(IMediator mediator, ISlotRepository slotRepository, IStageRepository stageRepository)
        {
            _mediator = mediator;
            _slotRepository = slotRepository;
            _stageRepository = stageRepository;

            AddSlotCommand = new RelayCommand(AddSlot);
            SlotSelectedCommand = new RelayCommand<SlotDetailModel>(SlotSelected);

            _mediator.Register<AddMessage<SlotWrapper>>(AddSlot);
            _mediator.Register<DeleteMessage<SlotWrapper>>(RemoveSlot);
            _mediator.Register<UpdateMessage<SlotWrapper>>(EditSlot);

            Load();
        }

        private void EditSlot(UpdateMessage<SlotWrapper> obj)
        {
            _selectedStage = null;
            Load();
            Slots.Clear();
        }

        private void RemoveSlot(DeleteMessage<SlotWrapper> obj)
        {
            _selectedStage = null;
            Load();
            Slots.Clear();
        }

        private void SlotSelected(SlotDetailModel slot)
        {
            _mediator.Send(new SelectedMessage<SlotWrapper>());
            _mediator.Send(new DetailViewMessage<SlotWrapper>{ Id = slot.Id });
        }

        private void AddSlot() => _mediator.Send(new ChangeViewAddMessage<SlotWrapper>());

        private void AddSlot(AddMessage<SlotWrapper> _) => Load();

        public void Load()
        {
            Stages.Clear();
            var stages = _stageRepository.GetAll();
            Stages.AddRange(stages);
        }

        private void GetSlotsForSelectedStage()
        {
            Slots.Clear();
            var slots = _slotRepository.GetAllByStageId(SelectedStage.Id)
                .OrderBy(s=>s.StartTime);
            Slots.AddRange(slots);
        }
    }
}
