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

        private INavigationService _navigationService;
        public CustomDialogService(INavigationService navigationService)
        {
            _navigationService = navigationService;
            PageClosedTaskCompletionSource = new TaskCompletionSource<bool>();
        }
        public async Task<bool> ShowErrorDialog(string title, string message, string btnText)
        {
            var navParams = new NavigationParameters();
            navParams.Add("Title", title);
            navParams.Add("Message", message);
            navParams.Add("BtnText", btnText);
            navParams.Add("Sender", this);

            // Push the page to Navigation Stack
            return await Navigate(navParams, "CustomErrorDialog");
        }

        /// <summary>
        /// Handle popup page Navigation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="popup"></param>
        /// <returns></returns>
        private async Task<bool> Navigate(INavigationParameters navParams, string uri)
        {
            await Reset();

            bool ret = false;
            var runTask = Task.Run(() =>
            {
                // await for the user to enter the text input
                ret = PageClosedTask.Result;
                // Pop the page from Navigation Stack
            });

            // Push the page to Navigation Stack
            await _navigationService.NavigateAsync(new Uri(uri, UriKind.Relative), navParams);
            await runTask;
            await _navigationService.GoBackAsync();

            return ret;
        }

        private async Task Reset()
        {
            PageClosedTaskCompletionSource = new System.Threading.Tasks.TaskCompletionSource<bool>();
            await _navigationService.ClearPopupStackAsync();
        }
    }
}