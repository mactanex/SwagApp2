using System;
using Prism;
using Prism.Ioc;
using SwagApp2.ViewModels;
using SwagApp2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
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
            await NavigationService.NavigateAsync("MasterDetailPageView/BaseNavigationView/ListPageView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MasterDetailPageView, MasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterPageView, MasterPageViewModel>();
            containerRegistry.RegisterForNavigation<BaseNavigationView, BaseNavigationViewModel>();
            containerRegistry.RegisterForNavigation<ListPageView, ListPageViewModel>();
            containerRegistry.RegisterSingleton<IListStore, FakeListStore>();
        }
    }
}
