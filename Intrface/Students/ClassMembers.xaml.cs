using Mapping.Entities;
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

namespace Intrface.Students
{
    public partial class ClassMembers : Window
    {
        public static Student? SelectedStudentProfile;
        public static Grade? Class;
        int counter = 0;


        Mapping.AppContext context = new Mapping.AppContext();
        public ClassMembers()
        {
            InitializeComponent();
            
           using(context = new Mapping.AppContext())
            {
                var grade = StudentsWindow.SelectedClass;
                // set header title
                this.HeaderText.Text = grade?.Name;

                // Fill List Of Students
                this.ListOfStudents.ItemsSource = context.Students.Where(s=>s.GradeID == grade.GradeID).ToList();
                ListOfStudents.SelectedIndex = -1;
            }
        }

        // back to home page
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
        private void BackToLastScreen(object sender, RoutedEventArgs e)
        {
            StudentsWindow studentsWindow = new StudentsWindow();
            this.Close();
            studentsWindow.Show();

        }

        private void ListOfStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListOfStudents.SelectedIndex == 0 && counter == 0)
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

        private void AddStudent(object sender, RoutedEventArgs e)
        {
            Class = StudentsWindow.SelectedClass;
            AddStudent addStudent = new AddStudent();
            this.Close();
            addStudent.Show();
        }
    }
}
