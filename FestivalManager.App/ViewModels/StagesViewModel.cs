using System.Collections.ObjectModel;
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
    public class StagesViewModel : ViewModelBase, IStagesViewModel
    {
        public ICommand AddStageCommand { get;}
        public ICommand StageSelectedCommand { get;}
        private readonly IMediator _mediator;
        private readonly IStageRepository _stageRepository;
        public ObservableCollection<StageListModel> Stages { get; set; } = new ();

        public StagesViewModel(IMediator mediator, IStageRepository stageRepository)
        {
            _mediator = mediator;
            _stageRepository = stageRepository;

            AddStageCommand = new RelayCommand(AddStage);
            StageSelectedCommand = new RelayCommand<StageListModel>(StageSelected);

            _mediator.Register<AddMessage<StageWrapper>>(AddStage);
            _mediator.Register<DeleteMessage<StageWrapper>>(RemoveStage);
            _mediator.Register<UpdateMessage<StageWrapper>>(EditStage);

            Load();
        }

        private void EditStage(UpdateMessage<StageWrapper> _) => Load();
        private void RemoveStage(DeleteMessage<StageWrapper> _) => Load();
        private void AddStage(AddMessage<StageWrapper> _) => Load();
        public void AddStage() => _mediator.Send(new ChangeViewAddMessage<StageWrapper>());
        public void StageSelected(StageListModel stage)
        {
            _mediator.Send(new SelectedMessage<StageWrapper>());
            _mediator.Send(new DetailViewMessage<StageWrapper>() { Id = stage.Id });
        }

        public void Load()
        {
            Stages.Clear();
            var stages = _stageRepository.GetAll();
            Stages.AddRange(stages);
        }
    }
}
