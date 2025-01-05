using Unity;
using Prism.Events;
using Prism.Logging;
using Prism.Regions;
using PrismMahAppsSample.Infrastructure.Base;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.Infrastructure.Events;
using PrismMahAppsSample.Infrastructure.Interfaces;
using PrismMahAppsSample.Shell.Views;
using Prism.Commands;
using System.Windows.Input;

namespace PrismMahAppsSample.Shell.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand DeployCupCakesCommand { get; private set; }
        public ICommand LaunchGitHubSiteCommand { get; private set; }
        
        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowViewModel()
        {
            this.DeployCupCakesCommand = new DelegateCommand(this.OnDeployCupCakes);
            this.LaunchGitHubSiteCommand = new DelegateCommand(this.OnLaunchGitHubSite);
            // Register to events
            EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Subscribe(OnStatusBarMessageUpdateEvent);

            Container.Resolve<ILoggerFacade>().Log("MainViewModel created", Category.Info, Priority.None);

            // Add right windows commands
            RegionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(RightTitlebarCommands));
            // Add flyouts
            RegionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(ShellSettingsFlyout));
            // Add tiles to MainRegion
            RegionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(HomeTiles));

        }

        #region Event-Handler
        private void OnDeployCupCakes()
        {
            this.StatusBarMessage = "OnDeployCupCakes";
        }
        private void OnLaunchGitHubSite()
        {
            this.StatusBarMessage = "OnLaunchGitHubSite";
        }

        /// <summary>
        /// EventHandler for the update status bar event
        /// </summary>
        /// <param name="statusBarMessage"></param>
        private void OnStatusBarMessageUpdateEvent(string statusBarMessage)
        {
            this.StatusBarMessage = statusBarMessage;
        }

        #endregion Event-Handler

        #region Properties

        private string statusBarMessage;

        /// <summary>
        /// Status-Bar message
        /// </summary>
        public string StatusBarMessage
        {
            get { return statusBarMessage; }
            set { this.SetProperty<string>(ref this.statusBarMessage, value); }
        }

        #endregion Properties
    }
}
