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
    public sealed partial class World2 : Page
    {
        public World2()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            if (MySplitView.IsPaneOpen == false)
            {
                MySplitView.IsPaneOpen = true;
            }
            else
            {
                MySplitView.IsPaneOpen = false;
            }
            
        }

        private async void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = false;
            await AddSubjectDialog.ShowAsync();
        }

        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TermsOfUseContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            for (int i = 0; i < 50; i++)
            {
                AttendList.Items.Add(i);
                HeldList.Items.Add(i);
            }

            for (int i = 0; i < 100; i++)
            {
                PercentReq.Items.Add(i);
            }
        }

        private void AddSubjectDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ///// Validate Data.


            ///// Make Object.

            Model.Subject subject = new Model.Subject();
            subject.Name = SubName.Text;
            subject.attended = (int)AttendList.SelectedItem;
            subject.held = (int)HeldList.SelectedItem;
            subject.minreq = (int)PercentReq.SelectedItem;
            subject.updateNow();


            ///// Add into Database.

            try
            {
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "App.db");

                var db = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

                db.CreateTable<Model.Subject>();

                db.Insert(subject);

                RefreshView();

            }
            catch (Exception)
            {
                throw;
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshView();
        }

        public void RefreshView()
        {
            /////// Read the data from the database.

            GridViewOfSubjects.Items.Clear();

            var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "App.db");

            var db = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            var query = db.Table<Model.Subject>();

            var result = query.ToList<Model.Subject>();

            /////// Then refresh view

            foreach (var item in result)
            {
                GridViewOfSubjects.Items.Add(item);
            }

        }

        private void GridViewOfSubjects_ItemClick(object sender, ItemClickEventArgs e)
        {
            int index = GridViewOfSubjects.SelectedIndex;

            ////// Open a flyout.

            displaySubjectFlyout();


            ////// 

        }

        public void displaySubjectFlyout()
        {



        }

        private void AddAttendance_Click(object sender, RoutedEventArgs e)
        {
            /////////// New Content Dialog to be shown.
        }

        private void DeleteSubject_Click(object sender, RoutedEventArgs e)
        {
            /////////// New Content Dialog to delete.
        }
    }
}
