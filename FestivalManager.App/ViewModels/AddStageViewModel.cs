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
    public class AddStageViewModel : ViewModelBase, IAddStageViewModel
    {
        public StageWrapper Model { get; set; }
        public ICommand AddStageCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        private readonly IStageRepository _stageRepository;
        private readonly IMediator _mediator;

        public AddStageViewModel(IMediator mediator, IStageRepository stageRepository)
        {
            _mediator = mediator;
            _stageRepository = stageRepository;

            AddStageCommand = new RelayCommand(AddStage);
            CancelCommand = new RelayCommand(Cancel);

            Model = new StageDetailModel();
        }

        private void AddStage()
        {
            if (new object[] { Model.Name, Model.Info}.Any(o => o is null or ""))
            {
                MessageBox.Show("Name and Description must be selected.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            Model = _stageRepository.Create(Model.Model);
            _mediator.Send(new AddMessage<StageWrapper>());
            _mediator.Send(new ChangeViewMessage<StageWrapper>());
        }

        private void Cancel() => _mediator.Send(new ChangeViewMessage<StageWrapper>());
    }
}
