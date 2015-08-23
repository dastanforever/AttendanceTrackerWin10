using SQLite;
using SQLite.Net;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AttendanceTracker.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class testdb : Page
    {
        public testdb()
        {
            this.InitializeComponent();

            makeavail();

        }

        public void makeavail()
        {
            Model.Userdata userd = new Model.Userdata();

            var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "App.db");

            var db = new SQLiteConnection( new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            var result = db.Get<Model.Userdata>(1);

            test.Text = "Hello" + result.getName();

        }

    }
}
