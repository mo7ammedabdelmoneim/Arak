using Mapping.Entities;
using Intrface.Students;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Intrface.Teachers
{
    public partial class TeachersWindow : Window
    {
        Mapping.AppContext context = new Mapping.AppContext();
        public static Teacher? SelectedTeacherProfile;
        int counter = 0;
        public TeachersWindow()
        {
            InitializeComponent();

            using (context = new Mapping.AppContext())
            {
                // Get All Students , Bindinig Search For teacher ComboBox , Binding ListOfTeachers
                var allTeachers = context.Teachers.ToList();
                SearchForTeacherCBox.ItemsSource = allTeachers;
                ListOfTeachers.ItemsSource = allTeachers;
                ListOfTeachers.SelectedIndex = -1;
            }
        }


        

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        // Handling Search For Teacher ComboBox
        private void SearchForTeacherCBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchForTeacherCBox.Text == "Search For Teacher...")
            {
                SearchForTeacherCBox.Text = string.Empty;
                SearchForTeacherCBox.Foreground = Brushes.Black;
            }
        }
        private void SearchForTeacherCBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SearchForTeacherCBox.Text))
            {
                SearchForTeacherCBox.Text = "Search For Teacher...";
                SearchForTeacherCBox.Foreground = Brushes.Gray;
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SearchForTeacherCBox.SelectedItem != null)
            {
                SelectedTeacherProfile = (Teacher)SearchForTeacherCBox.SelectedItem;


                TeacherProfile teacherProfile = new TeacherProfile();
                this.Close();
                teacherProfile.Show();
            }
            else
                MessageBox.Show("Must Select a Teacher First!");
        }

        private void ListOfTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListOfTeachers.SelectedIndex == 0 && counter == 0)
            {
                ListOfTeachers.SelectedItem = null;
                counter++;
            }
            if (ListOfTeachers.SelectedItem != null)
            {
                SelectedTeacherProfile = (Teacher)ListOfTeachers.SelectedItem;


                TeacherProfile teacherProfile = new TeacherProfile();
                this.Close();
                teacherProfile.Show();
            }
        }

        
    }
}
