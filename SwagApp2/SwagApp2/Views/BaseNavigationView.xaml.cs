using Prism.Navigation;
using Xamarin.Forms;

namespace SwagApp2.Views
{
    public partial class BaseNavigationView : NavigationPage, INavigationPageOptions
    {
        public BaseNavigationView()
        {
            InitializeComponent();
        }

        public bool ClearNavigationStackOnNavigation => true;
    }
}
