using System.Collections.Generic;
using VPNNetWorkLibrary;

namespace WebSolutionsTestProject.Services
{
    public class SettingsProvider : ISettingsProvider
    {
        /// <summary>
        /// Settings by countries.
        /// Created explicit as it test project
        /// </summary>
        public List<VPNSetting> Countries { get; } = new List<VPNSetting>
           {
               new VPNSetting{Country = "Russia", CountryShortName="Ru", VpnSetting = new VpnSpecialSetting("ru: vpn setting")},
               new VPNSetting{Country = "Usa", CountryShortName="Us", VpnSetting = new VpnSpecialSetting("us: vpn setting")},
               new VPNSetting{Country = "Germany", CountryShortName="Ge", VpnSetting = new VpnSpecialSetting("ge: vpn setting")} ,

               new VPNSetting{Country = "Russia.1 ", CountryShortName="Ru", VpnSetting = new VpnSpecialSetting("ru: vpn setting")},
               new VPNSetting{Country = "Usa.1", CountryShortName="Us", VpnSetting = new VpnSpecialSetting("us: vpn setting")},
               new VPNSetting{Country = "Germany.1", CountryShortName="Ge", VpnSetting = new VpnSpecialSetting("ge: vpn setting")},

               new VPNSetting{Country = "Russia.2 ", CountryShortName="Ru", VpnSetting = new VpnSpecialSetting("ru: vpn setting")},
               new VPNSetting{Country = "Usa.2", CountryShortName="Us", VpnSetting = new VpnSpecialSetting("us: vpn setting")},
               new VPNSetting{Country = "Germany.2", CountryShortName="Ge", VpnSetting = new VpnSpecialSetting("ge: vpn setting")},

               new VPNSetting{Country = "Russia.3 ", CountryShortName="Ru", VpnSetting = new VpnSpecialSetting("ru: vpn setting")},
               new VPNSetting{Country = "Usa.3", CountryShortName="Us", VpnSetting = new VpnSpecialSetting("us: vpn setting")},
               new VPNSetting{Country = "Germany.3", CountryShortName="Ge", VpnSetting = new VpnSpecialSetting("ge: vpn setting")}
           };
    }
    /// <summary>
    /// vpn setting
    /// </summary>
    public class VPNSetting: ISetting
    {
        public string Country { get; set; }
        public string CountryShortName { get; set; }
        public VpnSpecialSetting VpnSetting { get; set; }
    }
}
