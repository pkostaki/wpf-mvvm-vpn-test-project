using System.Collections.Generic;

namespace WebSolutionsTestProject.Services
{
    /// <summary>
    /// Settings provider interface
    /// </summary>
    public interface ISettingsProvider
    {
        List<VPNSetting> Countries { get; }
    }
}