using Unity;
using Prism.Events;
using Prism.Logging;
using Prism.Regions;
using PrismMahAppsSample.Infrastructure.Base;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.Infrastructure.Events;
using PrismMahAppsSample.Infrastructure.Interfaces;
using PrismMahAppsSample.Shell.Views;

namespace PrismMahAppsSample.Shell.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowViewModel()
        {
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
