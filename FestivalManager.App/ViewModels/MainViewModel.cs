using FestivalManager.App.Commands;
using System.Windows;
using System.Windows.Input;
using FestivalManager.App.Factory;
using FestivalManager.App.Messages;
using FestivalManager.App.Services;
using FestivalManager.App.ViewModels.Interfaces;
using FestivalManager.App.Wrappers;

namespace FestivalManager.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public bool IsMax;
        public ICommand HomeViewCommand { get; }
        public ICommand StagesViewCommand { get; }
        public ICommand ProgramViewCommand { get; }
        public ICommand BandsViewCommand { get; }
        public ICommand MinimizeCommand { get; }
        public ICommand MaximizeCommand { get; }
        public ICommand CloseWindowCommand { get; }
        public IHomeViewModel Home { get; set; }
        public IBandsViewModel Bands { get; set; }
        public IStagesViewModel Stages { get; set; }
        public IProgramViewModel Program { get; set; }
        private readonly IFactory<IBandDetailViewModel> _bandDetailViewModelFactory;
        private readonly IFactory<IAddBandViewModel> _addBandViewModelFactory;
        private readonly IFactory<IStageDetailViewModel> _stageDetailViewModelFactory;
        private readonly IFactory<IAddStageViewModel> _addStageViewModelFactory;
        private readonly IFactory<ISlotDetailViewModel> _slotDetailViewModelFactory;
        private readonly IFactory<IAddSlotViewModel> _addSlotViewModelFactory;
        private readonly IMediator _mediator;

        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        private WindowState _currentWindowState;
        public WindowState CurrentWindowState
        {
            get => _currentWindowState;
            set
            {
                _currentWindowState = value;
                OnPropertyChanged();
            }
        }
        private string _iconMaxMin;
        public string IconMaxMin
        {
            get => _iconMaxMin;
            set
            {
                _iconMaxMin = value;
                OnPropertyChanged();
            }
        }
        
        public MainViewModel(
            IHomeViewModel homeViewModel,
            IBandsViewModel bandsViewModel,
            IStagesViewModel stagesViewModel,
            IProgramViewModel programViewModel,
            IMediator mediator,
            IFactory<IBandDetailViewModel> bandDetailViewModelFactory,
            IFactory<IAddBandViewModel> addBandViewModelFactory,
            IFactory<IStageDetailViewModel> stageDetailViewModelFactory,
            IFactory<IAddStageViewModel> addStageViewModelFactory,
            IFactory<ISlotDetailViewModel> slotDetailViewModelFactory,
            IFactory<IAddSlotViewModel> addSlotViewModelFactory)
        {
            Home = homeViewModel;
            Bands = bandsViewModel;
            Stages = stagesViewModel;
            Program = programViewModel;

            HomeViewCommand = new RelayCommand(SetHomeView);
            BandsViewCommand = new RelayCommand(SetBandsView);
            StagesViewCommand = new RelayCommand(SetStagesView);
            ProgramViewCommand = new RelayCommand(SetProgramView);

            MinimizeCommand = new RelayCommand(Minimize);
            MaximizeCommand = new RelayCommand(Maximize);
            CloseWindowCommand = new RelayCommand(CloseWindow);
            IconMaxMin = "WindowMaximize";

            _mediator = mediator;
            _mediator.Register<ChangeViewAddMessage<BandWrapper>>(AddBandView);
            _mediator.Register<SelectedMessage<BandWrapper>>(BandDetailView);
            _mediator.Register<ChangeViewMessage<BandWrapper>>(SetBandsView);
            _mediator.Register<ChangeViewAddMessage<StageWrapper>>(AddStageView);
            _mediator.Register<SelectedMessage<StageWrapper>>(StageDetailView);
            _mediator.Register<ChangeViewMessage<StageWrapper>>(SetStagesView);
            _mediator.Register<ChangeViewAddMessage<SlotWrapper>>(AddSlotView);
            _mediator.Register<ChangeViewMessage<SlotWrapper>>(SetProgramView);
            _mediator.Register<SelectedMessage<SlotWrapper>>(SlotDetailView);
            
            _bandDetailViewModelFactory = bandDetailViewModelFactory;
            _addBandViewModelFactory = addBandViewModelFactory;
            _stageDetailViewModelFactory = stageDetailViewModelFactory;
            _addStageViewModelFactory = addStageViewModelFactory;
            _slotDetailViewModelFactory = slotDetailViewModelFactory;
            _addSlotViewModelFactory = addSlotViewModelFactory;

            CurrentView = Home;
        }

        private void AddBandView(ChangeViewAddMessage<BandWrapper> _) => CurrentView = _addBandViewModelFactory.Create();
        private void BandDetailView(SelectedMessage<BandWrapper> _) => CurrentView = _bandDetailViewModelFactory.Create();
        private void AddStageView(ChangeViewAddMessage<StageWrapper> _) => CurrentView = _addStageViewModelFactory.Create();
        private void StageDetailView(SelectedMessage<StageWrapper> _) => CurrentView = _stageDetailViewModelFactory.Create();
        private void AddSlotView(ChangeViewAddMessage<SlotWrapper> _) => CurrentView = _addSlotViewModelFactory.Create();
        private void SlotDetailView(SelectedMessage<SlotWrapper> _) => CurrentView = _slotDetailViewModelFactory.Create();

        private void SetHomeView() => CurrentView = Home;
        private void SetBandsView(object _) => CurrentView = Bands;
        private void SetStagesView(object _) => CurrentView = Stages;
        private void SetProgramView(object _)
        {
            CurrentView = Program;
            _mediator.Send(new UpdateMessage<SlotWrapper>());
        }

        private void Minimize() => CurrentWindowState = WindowState.Minimized;
        private void CloseWindow() => Application.Current.Shutdown(0);
        private void Maximize()
        {
            if (IsMax)
            {
                CurrentWindowState = WindowState.Normal;
                IconMaxMin = "WindowMaximize";
            }
            else
            {
                CurrentWindowState = WindowState.Maximized;
                IconMaxMin = "DockWindow";
            }
            IsMax = !IsMax;
        }
    }
}
