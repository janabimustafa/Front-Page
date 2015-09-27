using System;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Front_Page.Services.SettingsServices;
using Front_Page.Views;
using Template10.Mvvm;

namespace Front_Page.ViewModel
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }

    public class SettingsPartViewModel : ViewModelBase
    {
        private readonly SettingsService _settings;
        private string _BusyText = "Please wait...";

        public SettingsPartViewModel()
        {
            if (!DesignMode.DesignModeEnabled)
                _settings = SettingsService.Instance;
        }

        public bool UseShellBackButton
        {
            get { return _settings.UseShellBackButton; }
            set
            {
                _settings.UseShellBackButton = value;
                RaisePropertyChanged();
            }
        }

        public bool UseLightThemeButton
        {
            get { return _settings.AppTheme.Equals(ApplicationTheme.Light); }
            set
            {
                _settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark;
                RaisePropertyChanged();
            }
        }

        public string BusyText
        {
            get { return _BusyText; }
            set { Set(ref _BusyText, value); }
        }

        public void ShowBusy()
        {
            Shell.SetBusyVisibility(Visibility.Visible, _BusyText);
        }

        public void HideBusy()
        {
            Shell.SetBusyVisibility(Visibility.Collapsed);
        }
    }

    public class AboutPartViewModel : ViewModelBase
    {
        public Uri Logo
        {
            get { return Package.Current.Logo; }
        }

        public string DisplayName
        {
            get { return Package.Current.DisplayName; }
        }

        public string Publisher
        {
            get { return Package.Current.PublisherDisplayName; }
        }

        public string Version
        {
            get
            {
                var ver = Package.Current.Id.Version;
                return ver.Major + "." + ver.Minor + "." + ver.Build + "." +
                       ver.Revision;
            }
        }

        public Uri RateMe
        {
            get { return new Uri("http://bing.com"); //TODO }
            }
        }
    }
}