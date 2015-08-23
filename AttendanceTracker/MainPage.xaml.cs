using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AttendanceTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            /////////////////// Check Local Settings. ////////////
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            if(localSettings.Values.ContainsKey("FirstUser"))
            {
                Loaded += Page_Loaded;
            }
            else
            {
                localSettings.Values["FirstUser"] = 1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //// Add user data.
            Frame.Navigate(typeof(Views.ManageUserData));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.World2));
        }

    }
}
