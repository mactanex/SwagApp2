using System;
using Prism;
using Prism.Ioc;
using SwagApp2.ViewModels;
using SwagApp2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Prism.Navigation;
using Prism.Common;
using Prism.Plugin.Popups;
using SwagApp2.DataStores;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SwagApp2
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            await NavigationService.NavigateAsync("MasterDetailPageView/NavigationPage/ListPageView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Popups
            containerRegistry.RegisterPopupNavigationService();

            // Services
            containerRegistry.RegisterSingleton<IListStore, FakeListStore>();

            // Views and viewmodels
            containerRegistry.RegisterForNavigation<MasterDetailPageView, MasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterPageView, MasterPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ListPageView, ListPageViewModel>();

            containerRegistry.RegisterForNavigation<NewListPageModal, NewListPageModalViewModel>();
        }
    }
}
