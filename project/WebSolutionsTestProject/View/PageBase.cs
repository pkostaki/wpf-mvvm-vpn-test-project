using System.Windows.Controls;
using WebSolutionsTestProject.ViewModel.Base;

namespace WebSolutionsTestProject.View
{
    public partial class PageBase : Page
    {
        public PageBase()
        {
            Unloaded += PageBase_Unloaded;
        }

        private void PageBase_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Unloaded -= PageBase_Unloaded;

            var vm = DataContext as BaseViewModel;
            vm?.CleanUp();
        }
    }
}
