using System;
using SwagApp2.ViewModels;
using Xamarin.Forms;

namespace SwagApp2.Views
{
    public partial class ListPageView : ContentPage
    {
        public ListPageView()
        {
            InitializeComponent();
        }

        private void ListNamesList_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var vm = BindingContext as ListPageViewModel;
            var adjust = - vm.ListNameCollection.Count + 1;
            ListNamesList.HeightRequest = (vm.ListNameCollection.Count * ListNamesList.RowHeight) - adjust;
        }
    }
}
