using System;
using Windows.UI.Xaml;
using Front_Page.Views;
using Template10.Common;

namespace Front_Page.Services.SettingsServices
{
    public partial class SettingsService
    {
        public void ApplyUseShellBackButton(bool value)
        {
            BootStrapper.Current.NavigationService.Dispatcher.Dispatch(() =>
            {
                BootStrapper.Current.ShowShellBackButton = value;
                BootStrapper.Current.UpdateShellBackButton();
                BootStrapper.Current.NavigationService.Refresh();
            });
        }

        public void ApplyAppTheme(ApplicationTheme value)
        {
            BootStrapper.Current.NavigationService.Dispatcher.Dispatch(() =>
            {
                switch (value)
                {
                    case ApplicationTheme.Light:
                        Shell.Instance.RequestedTheme = ElementTheme.Light;
                        break;
                    case ApplicationTheme.Dark:
                        Shell.Instance.RequestedTheme = ElementTheme.Dark;
                        break;
                    default:
                        Shell.Instance.RequestedTheme = ElementTheme.Default;
                        break;
                }
                BootStrapper.Current.NavigationService.Refresh();
            });
        }

        private void ApplyCacheMaxDuration(TimeSpan value)
        {
            BootStrapper.Current.CacheMaxDuration = value;
        }
    }
}