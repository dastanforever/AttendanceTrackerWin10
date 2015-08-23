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
    public sealed partial class ManageUserData : Page
    {
        public ManageUserData()
        {
            this.InitializeComponent();

            for (int i = 0; i < 50; i++)
            {
                AgeList.Items.Add(i + 10);
            }

        }

        private void Proceed_Click(object sender, RoutedEventArgs e)
        {
            Model.Userdata userData = new Model.Userdata();

            userData.addData(name.Text, (int)AgeList.SelectedItem, 0);

            // Create a Database.

            // Add to database.

            try
            {
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "App.db");

                var db = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT() ,path);

                db.CreateTable<Model.Userdata>();
                db.CreateTable<Model.Subject>();

                db.Insert(userData);

                this.Frame.Navigate(typeof(World2));

            }
            catch (Exception)
            {
                throw;
            }
            

            // redirecting to 

        }
    }
}
