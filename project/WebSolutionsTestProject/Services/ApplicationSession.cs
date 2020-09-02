using System.Linq;

namespace WebSolutionsTestProject.Services
{
    /// <summary>
    /// Class manage application's session state
    /// </summary>
    public class ApplicationSession
    {
        private ISettingsProvider _settingsProvider;

        public ApplicationSession(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
            VpnSetting = _settingsProvider.Countries.FirstOrDefault();
        }
        /// <summary>
        /// Current vpn setting
        /// </summary>
        public VPNSetting VpnSetting { get; set; }
    }
}
