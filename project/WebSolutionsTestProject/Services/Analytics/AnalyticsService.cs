using System.Diagnostics;

namespace WebSolutionsTestProject.Services
{
    /// <summary>
    /// Analytics track approach
    /// Can be represented as seperate project to integrate at each functionality
    /// </summary>
    public class AnalyticsService:IAnalytics
    {
        public void Track(AnalyticsEntry entry)
        {
            // track analytics according to entry
            Debug.WriteLine($"Analytics.Track: {entry.EventId}");
        }
    }


}
