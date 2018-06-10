using System;
using System.Collections.Generic;
using System.Text;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace SwagApp2.Views.CustomDialog
{
    public class CustomDialogBase : PopupPage
    {
        public CustomDialogBase()
        {
        }

        protected override async void OnAppearingAnimationEnd()
        {
            await Content.FadeTo(1);
        }

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        protected override async void OnDisappearingAnimationBegin()
        {
            await Content.FadeTo(1);
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent back button pressed action on android
            return true;
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Prevent background clicked action
            return false;
        }
    }
}
