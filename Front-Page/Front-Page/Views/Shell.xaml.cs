using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Services.NavigationService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Front_Page.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Page
    {

        private static Shell Instance { get; set; }

        public Shell(NavigationService navigationService)
        {
            Instance = this;
            this.InitializeComponent();
            MyHamburgerMenu.NavigationService = navigationService;
        }

        public static void SetBusyIndicator(bool busy, string text = null)
        {
            Instance.BusyIndicator.Visibility = (busy)
                ? Visibility.Visible : Visibility.Collapsed;
            Instance.BusyRing.IsActive = busy;
            Instance.BusyText.Text = text ?? string.Empty;
        }
    }
}
