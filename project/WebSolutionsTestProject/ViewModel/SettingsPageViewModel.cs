using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using VPNNetWorkLibrary;
using WebSolutionsTestProject.Services;
using WebSolutionsTestProject.ViewModel.Base;

namespace WebSolutionsTestProject.ViewModel
{
    public class SettingsPageViewModel: BaseViewModel
    {
        private readonly ApplicationSession _applicationSession;
        private readonly ISettingsProvider _settingsProvider;
        private readonly INetWork _netWork;

        /// <summary>
        /// Select settings from list
        /// </summary>
        public VPNSettingViewModel Selected { get; set; }
        /// <summary>
        /// List of available settings
        /// </summary>
        public List<VPNSettingViewModel> Settings { get; }
        /// <summary>
        /// Choose setting button command
        /// </summary>
        public ICommand SelectSettingCommand { get; }

        public SettingsPageViewModel(ApplicationSession applicationSession, ISettingsProvider settingsProvider, INetWork netWork)
        {
            _applicationSession = applicationSession;
            _settingsProvider = settingsProvider;
            _netWork = netWork;

            //create settings viewmodels from provider
            Settings = _settingsProvider.Countries.Select(s => new VPNSettingViewModel
            {
                Country = s.Country,
                Icon = new Uri($"pack://application:,,,/Assets/{s.CountryShortName}.png"),
                Setting = s
            }).ToList();

            SelectSettingCommand = new RelayCommand((_) =>
            {
                // 1. update application vpn setting
                // 2. reset connection
                // 3. navigate to StartPage

                _applicationSession.VpnSetting = Selected.Setting;
                _netWork.Disconnect();
                ((NavigationWindow)Application.Current.MainWindow).Navigate(new Uri("View/StartPage.xaml", UriKind.Relative));
            }, (_)=>Selected!=null);
        }
    }

    public class VPNSettingViewModel
    {
        public string Country { get; set; }
        public Uri Icon { get; set; }
        public VPNSetting Setting { get; set; }
    }
}
