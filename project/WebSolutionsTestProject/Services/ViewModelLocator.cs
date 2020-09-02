using WebSolutionsTestProject.ViewModel;

namespace WebSolutionsTestProject.Services
{
    /// <summary>
    /// Locator for view models
    /// </summary>
    public class ViewModelLocator
    {
        private readonly ServiceLocator _service = new ServiceLocator();

        public StartPageViewModel MainWindowViewModel => new StartPageViewModel(_service.ApplicationSession, _service.VPNNetwork, _service.Analytics);
        public SettingsPageViewModel SettingsPageViewModel => new SettingsPageViewModel(_service.ApplicationSession, _service.SettingsProvider, _service.VPNNetwork);
    }
}
