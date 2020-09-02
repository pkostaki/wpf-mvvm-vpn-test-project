using VPNNetWorkLibrary;

namespace WebSolutionsTestProject.Services
{
    /// <summary>
    /// Class initialize services.
    /// Note: using an IOC Containers such as Unity,MVVM Light’s SimpleIoc, ect. is the best way to initialize services. Test project less such approach
    /// </summary>
    public class ServiceLocator
    {
        public ServiceLocator()
        {
            VPNNetwork = new VPNNetWork();
            SettingsProvider = new SettingsProvider();
            Analytics = new AnalyticsService();
            ApplicationSession = new ApplicationSession(SettingsProvider);
        }


        public ApplicationSession ApplicationSession { get; } 

        public INetWork VPNNetwork { get; }
        
        public ISettingsProvider SettingsProvider { get; }
        public IAnalytics Analytics { get; }
    }
}
