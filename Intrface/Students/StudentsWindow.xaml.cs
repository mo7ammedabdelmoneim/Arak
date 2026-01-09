using Mapping.Entities;
using System;
using System.Collections.Generic;
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

namespace Intrface.Students
{
    public partial class StudentsWindow : Window
    {
        Mapping.AppContext context = new Mapping.AppContext();
        public static Grade? SelectedClass;
        public static Student? SelectedStudentProfile;
        int counter = 0;

        public StudentsWindow()
        {
            InitializeComponent();

            using (context = new Mapping.AppContext())
            {
                // Get All Students , Bindinig Search For Student ComboBox , Binding ListOfStudents
                var allStudent = context.Students.ToList();
                SearchforstidentCBox.ItemsSource = allStudent;
                ListOfStudents.ItemsSource = allStudent;
                ListOfStudents.SelectedIndex = -1;

                // Binding Level and grade ComboBoxs
                var allLevels = context.Levels.ToList();
                this.LevelCBox.ItemsSource = allLevels;



            }



        }


        private void BackToLastScreen(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();

        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }


        // Handling Search For Student ComboBox
        private void SearchforstidentCBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchforstidentCBox.Text == "Search For Student...")
            {
                SearchforstidentCBox.Text = string.Empty;
                SearchforstidentCBox.Foreground = Brushes.Black;
            }
        }
        private void SearchforstidentCBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SearchforstidentCBox.Text))
            {
                SearchforstidentCBox.Text = "Search For Student...";
                SearchforstidentCBox.Foreground = Brushes.Gray;
            }
        }

        // Handling Level ComboBox
        private void LevelCBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LevelCBox.Text == "Choose Level")
            {
                LevelCBox.Text = string.Empty;
                LevelCBox.Foreground = Brushes.Black;
            }
        }
        private void LevelCBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(LevelCBox.Text))
            {
                LevelCBox.Text = "Choose Level";
                LevelCBox.Foreground = Brushes.Gray;
            }
        }

        // Handling Grade ComboBox
        private void GradeCBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (GradeCBox.Text == "Choose Grade")
            {
                GradeCBox.Text = string.Empty;
                GradeCBox.Foreground = Brushes.Black;
            }
        }
        private void GradeCBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(GradeCBox.Text))
            {
                GradeCBox.Text = "Choose Grade";
                GradeCBox.Foreground = Brushes.Gray;
            }
        }


       

        private void LevelCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (context = new Mapping.AppContext())
            {
                var levelId = ((Level)LevelCBox.SelectedItem)?.LevelID;
                var allClassInLevel = context.Grades.Where(g => g.LevelID == levelId).ToList();
                this.GradeCBox.ItemsSource = allClassInLevel;
            }
        }

        private void SearchForClassBtn_Click(object sender, RoutedEventArgs e)
        {
            using (context = new Mapping.AppContext())
            {
                var classId = ((Grade)GradeCBox.SelectedItem)?.GradeID;
                if (classId == null)
                {
                    MessageBox.Show("You should select a class first!");
                }
                else
                {
                    SelectedClass = context.Grades.SingleOrDefault(g => g.GradeID == classId);

                    ClassMembers classMembers = new ClassMembers();
                    this.Close();
                    classMembers.Show();
                }
            }
        }

        private void ListOfStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListOfStudents.SelectedIndex == 0 && counter == 0)
            {
                ListOfStudents.SelectedItem = null;
                counter++;
            }
            if (ListOfStudents.SelectedItem != null)
            {
                SelectedStudentProfile = (Student)ListOfStudents.SelectedItem;


                StudentProfile studentProfile = new StudentProfile();
                this.Close();
                studentProfile.Show();
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SearchforstidentCBox.SelectedItem != null)
            {
                SelectedStudentProfile = (Student)SearchforstidentCBox.SelectedItem;


                StudentProfile studentProfile = new StudentProfile();
                this.Close();
                studentProfile.Show();
            }
            else
                MessageBox.Show("Must Select a Student First!");
        }
    }
}
