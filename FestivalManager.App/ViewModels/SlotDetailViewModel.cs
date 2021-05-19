using System;
using System.Windows;
using System.Windows.Input;
using FestivalManager.App.Commands;
using FestivalManager.App.Messages;
using FestivalManager.App.Services;
using FestivalManager.App.ViewModels.Interfaces;
using FestivalManager.App.Wrappers;
using FestivalManager.BL.Repositories;

namespace FestivalManager.App.ViewModels
{
    public class SlotDetailViewModel : ViewModelBase, ISlotDetailViewModel
    {
        public SlotWrapper Model { get; set; }
        public ICommand EditSlotCommand { get; }
        public ICommand RemoveSlotCommand { get; }
        public ICommand RevertCommand { get; }
        private readonly IMediator _mediator;
        private readonly ISlotRepository _slotRepository;
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }

        public SlotDetailViewModel(IMediator mediator, ISlotRepository slotRepository)
        {
            _mediator = mediator;
            _slotRepository = slotRepository;

            EditSlotCommand = new RelayCommand(EditSlot);
            RemoveSlotCommand = new RelayCommand(RemoveSlot);
            RevertCommand = new RelayCommand(Revert);

            _mediator.Register<DetailViewMessage<SlotWrapper>>(SlotLoad);
        }

        private void Revert() => _mediator.Send(new ChangeViewMessage<SlotWrapper>());

        private void RemoveSlot()
        {
            _slotRepository.Delete(Model.Id);
            _mediator.Send(new ChangeViewMessage<SlotWrapper>());
            _mediator.Send(new DeleteMessage<SlotWrapper>());
        }

        private void EditSlot()
        {
            Model.StartTime = StartDay.Date + Model.StartTime.TimeOfDay;
            Model.EndTime = EndDay.Date + Model.EndTime.TimeOfDay;
            try
            {
                _slotRepository.Update(Model.Model);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid slot time. Check for a collision.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            _mediator.Send(new UpdateMessage<SlotWrapper>());
            _mediator.Send(new ChangeViewMessage<SlotWrapper>());
        }

        private void SlotLoad(DetailViewMessage<SlotWrapper> message) => Load(message.Id);

        public void Load(Guid id)
        {
            Model = _slotRepository.GetById(id);
            StartDay = Model.StartTime.Date;
            EndDay = Model.EndTime.Date;
        }
    }
}
