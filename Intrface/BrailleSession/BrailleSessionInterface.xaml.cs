using Intrface.Teachers;
using Mapping.Entities;
using Microsoft.EntityFrameworkCore;
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

namespace Intrface.BrailleSession
{
    public partial class BrailleSessionInterface : Window
    {
        Mapping.AppContext context;
        List<PrivateBrailleStudents>? BrailleStudents;
        public static PrivateBrailleStudents? SelectedStudentProfile;
        int counter;

        public BrailleSessionInterface()
        {
            InitializeComponent();
            
            using(context = new Mapping.AppContext())
            {
                // fill ListOfBrailleStudents viewBox
                BrailleStudents = context.PrivateBrailleStudents.AsNoTracking().ToList();
                ListOfBrailleStudents.ItemsSource = BrailleStudents;
                ListOfBrailleStudents.SelectedIndex = -1;


                // fill AddNewStudentCBox
                var allStudents = context.Students.AsNoTracking().ToList();
                allStudents.RemoveAll(student=> BrailleStudents.Any(b=> b.Name == student.Name)); // To remove the Added Students
                AddNewStudentCBox.ItemsSource = allStudents;
            }

        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        // Handling Add New Student ComboBox
        private void AddNewStudent_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AddNewStudentCBox.Text == "Add New Student...")
            {
                AddNewStudentCBox.Text = string.Empty;
                AddNewStudentCBox.Foreground = Brushes.Black;
            }
        }
        private void AddNewStudent_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(AddNewStudentCBox.Text))
            {
                AddNewStudentCBox.Text = "Add New Student...";
                AddNewStudentCBox.Foreground = Brushes.Gray;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            using (context = new Mapping.AppContext())
            {
                var selectedStudent = (Student)AddNewStudentCBox.SelectedItem;

                if (selectedStudent != null)
                {
                    context.Add(new PrivateBrailleStudents { Name = selectedStudent.Name });
                    context.SaveChanges();
               
                    BrailleSessionInterface brailleSessionInterface = new BrailleSessionInterface();
                    this.Close();
                    brailleSessionInterface.Show();
                }
                else
                    MessageBox.Show("You Should Select a Students First!");
            }
        }


        private void ListOfBrailleStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListOfBrailleStudents.SelectedIndex == 0 && counter == 0)
            {
                ListOfBrailleStudents.SelectedItem = null;
                counter++;
            }
            if (ListOfBrailleStudents.SelectedItem != null)
            {
                SelectedStudentProfile = (PrivateBrailleStudents)ListOfBrailleStudents.SelectedItem;


                BrailleStudentSessions sessions = new BrailleStudentSessions();
                this.Close();
                sessions.Show();
            }
        }
    }
}
