using System.Threading.Tasks;
using SwagApp2.Views.CustomDialog;
using Rg.Plugins.Popup.Services;
using Prism.Navigation;
using System;
using Rg.Plugins.Popup.Pages;

namespace SwagApp2.DialogService
{
    public class CustomDialogService : ICustomDialogService
    {
        public Task<bool> PageClosedTask { get { return PageClosedTaskCompletionSource.Task; } }
        // the task completion source
        public TaskCompletionSource<bool> PageClosedTaskCompletionSource { get; set; }

        private readonly INavigationService _navigationService;
        public CustomDialogService(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public async Task<bool> ShowErrorDialog(string title, string message, string btnText)
        {
            var navParams = new NavigationParameters();
            navParams.Add("Title", title);
            navParams.Add("Message", message);
            navParams.Add("BtnText", btnText);
            navParams.Add("Sender", this);

            // Navigate
            return await Navigate(navParams, "CustomErrorDialog");
        }

        /// <summary>
        /// Handle popup page Navigation
        /// </summary>
        /// <returns></returns>
        private async Task<bool> Navigate(INavigationParameters navParams, string uri)
        {
            await Reset();

            // Push the page to Navigation Stack
            await _navigationService.NavigateAsync(new Uri(uri, UriKind.Relative), navParams);
            // Wait for result
            var ret = await PageClosedTask;
            // Go back
            await _navigationService.GoBackAsync();

            return ret;
        }

        private async Task Reset()
        {
            PageClosedTaskCompletionSource = new TaskCompletionSource<bool>();
            await _navigationService.ClearPopupStackAsync();
        }
    }
}