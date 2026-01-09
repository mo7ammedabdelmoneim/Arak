using Mapping.Entities;
using Microsoft.EntityFrameworkCore;
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

namespace Intrface.BrailleSession
{
    
    public partial class AddNewBrailleSession : Window
    {
        Mapping.AppContext context;


        public AddNewBrailleSession()
        {
            InitializeComponent();

            using(context = new Mapping.AppContext())
            {
                // Set Student Name
                this.StudentName.Text = BrailleStudentSessions.StudentName;

                //fill SearchForTeacherCBox
                var allTeachers = context.Teachers.AsNoTracking().ToList();
                SearchForTeacherCBox.ItemsSource = allTeachers;

                
            }
        }


        // Back Buttons
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
        private void BackToLastScreen(object sender, RoutedEventArgs e)
        {
            BrailleStudentSessions brailleSession = new BrailleStudentSessions();
            this.Close();
            brailleSession.Show();
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

        private void AddBrailleSession_Click(object sender, RoutedEventArgs e)
        {
            using(context = new Mapping.AppContext())
            {
                if (SearchForTeacherCBox.SelectedItem != null)
                {
                    Braille_Session session = new Braille_Session();
                    session.StudentName = BrailleStudentSessions.StudentName;
                    session.SubjectName = "برايل خاص";
                    session.TeacherId = ((Teacher)SearchForTeacherCBox.SelectedItem).TeacherId;
                    session.Date = DateTime.Now;

                    context.Add(session);
                    context.SaveChanges();

                    MessageBox.Show("Session is Added 👍");
                    this.BackToLastScreen(sender, e);
                }
                else
                    MessageBox.Show("You Must Select a Teacher First!");
            }
        }
    }
}
