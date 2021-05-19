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
    public class StageDetailViewModel : ViewModelBase, IStageDetailViewModel
    {
        public StageWrapper Model { get; set; }
        public ICommand EditStageCommand { get; }
        public ICommand RemoveStageCommand { get; }
        public ICommand RevertCommand { get; }
        private readonly IStageRepository _stageRepository;
        private readonly ISlotRepository _slotRepository;
        private readonly IMediator _mediator;
        public ObservableCollection<BandListModel> Bands { get; set; } = new();

        public StageDetailViewModel(IMediator mediator, IStageRepository stageRepository, ISlotRepository slotRepository)
        {
            _mediator = mediator;
            _stageRepository = stageRepository;
            _slotRepository = slotRepository;

            EditStageCommand = new RelayCommand(EditStage);
            RemoveStageCommand = new RelayCommand(RemoveStage);
            RevertCommand = new RelayCommand(Revert);

            _mediator.Register<DetailViewMessage<StageWrapper>>(StageLoad);
        }

        private void Revert() => _mediator.Send(new ChangeViewMessage<StageWrapper>());

        private void RemoveStage()
        {
            _stageRepository.Delete(Model.Id);
            _mediator.Send(new ChangeViewMessage<StageWrapper>());
            _mediator.Send(new DeleteMessage<StageWrapper>());
        }

        private void EditStage()
        {
            if (new object[] { Model.Name, Model.Info }.Any(o => o is null or ""))
            {
                MessageBox.Show("Name and Description must be selected.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            _stageRepository.Update(Model.Model);
            _mediator.Send(new ChangeViewMessage<StageWrapper>());
            _mediator.Send(new UpdateMessage<StageWrapper>());
        }

        private void StageLoad(DetailViewMessage<StageWrapper> message) => Load(message.Id);
        public void Load(Guid id)
        {
            Model = _stageRepository.GetById(id);

            Bands.Clear();
            var bands = _slotRepository.GetAllByStageId(Model.Id)
                .Select(s => s.Band)
                .Distinct()
                .OrderBy(b=>b.Name);
            Bands.AddRange(bands);
        }
    }
}
