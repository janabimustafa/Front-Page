using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Front_Page.Views
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Splash : UserControl
    {
        public Splash(SplashScreen splashScreen)
        {
            InitializeComponent();

            Action resize = () =>
            {
                if (splashScreen.ImageLocation.Top == 0)
                {
                    MyImage.Visibility = Visibility.Collapsed;
                    return;
                }
                MyCanvas.Background = null;
                MyImage.Visibility = Visibility.Visible;
                MyImage.Height = splashScreen.ImageLocation.Height;
                MyImage.Width = splashScreen.ImageLocation.Width;
                MyImage.SetValue(Canvas.TopProperty, splashScreen.ImageLocation.Top);
                MyImage.SetValue(Canvas.LeftProperty, splashScreen.ImageLocation.Left);
                ProgressTransform.TranslateY = MyImage.Height/2;
            };
            Window.Current.SizeChanged += (s, e) => resize();
            resize();
        }
    }
}