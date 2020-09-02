using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using VPNNetWorkLibrary;
using WebSolutionsTestProject.Services;
using WebSolutionsTestProject.ViewModel.Base;

namespace WebSolutionsTestProject.ViewModel
{

    public class StartPageViewModel : BaseViewModel
    {
        private ConnectionStatus _status;
        public ConnectionStatus Status { get => _status; set { SetProperty(ref _status, value); } }

        private readonly ApplicationSession _applicationSession;
        private INetWork _vpnNetwork;
        private readonly IAnalytics _analytics;

        public ICommand AboutCommand { get; }
        public ICommand ConnectCommand { get; }
        public VPNSettingViewModel VPNSettingViewModel { get; }
        public StartPageViewModel(ApplicationSession applicationSession, INetWork vPNNetwork, IAnalytics analytics)
        {
            _applicationSession = applicationSession;
            _vpnNetwork = vPNNetwork;
            _analytics = analytics;
            _vpnNetwork.StatusChanged += OnVpnNetworkStatusChanged;
            Status = _vpnNetwork.Status;


            // create current setting viewmodel
            VPNSettingViewModel = new VPNSettingViewModel
            {
                Country = _applicationSession.VpnSetting.Country,
                Icon = new Uri($"pack://application:,,,/Assets/{_applicationSession.VpnSetting.CountryShortName}.png"),
                Setting = _applicationSession.VpnSetting
            };

            ConnectCommand = new RelayCommand((_) =>
            {
                _analytics.Track(new AnalyticsEntry { EventId="ConnectionButtonClicked" });
                _vpnNetwork.Setting = _applicationSession.VpnSetting;
                _vpnNetwork.Connect();
            }, (_) => _vpnNetwork.Status == ConnectionStatus.Disconnected);

            AboutCommand = new RelayCommand((_) =>
            {
                _analytics.Track(new AnalyticsEntry { EventId = "AboutButtonClicked" });
                ((NavigationWindow)Application.Current.MainWindow).Navigate(new Uri("View/SettingsPage.xaml", UriKind.Relative));
            }, (_) => _vpnNetwork.Status != ConnectionStatus.Connecting);
        }

        

        private void OnVpnNetworkStatusChanged(object sender, ConnectionStatus status)
        {
            Status = status;
        }

        public override void CleanUp()
        {
            _vpnNetwork.StatusChanged -= OnVpnNetworkStatusChanged;
        }
    }

    
}
