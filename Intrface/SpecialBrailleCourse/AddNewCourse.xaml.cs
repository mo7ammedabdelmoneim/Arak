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

namespace Intrface.SpecialBrailleCourse
{
    public partial class AddNewCourse : Window
    {
        Mapping.AppContext context;

        public AddNewCourse()
        {
            InitializeComponent();

            using(context = new Mapping.AppContext())
            {
                var instructors = context.Instructors.AsNoTracking().ToList();

                if(instructors != null && instructors.Count > 0)
                {
                    this.SearchForTeacherCBox.ItemsSource = instructors;
                }
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
            BrailleCourseInterface courseInterface = new BrailleCourseInterface();
            this.Close();
            courseInterface.Show();
        }

        // Handling Search For Teacher ComboBox
        private void SearchForTeacherCBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchForTeacherCBox.Text == "Choose an Instructor...")
            {
                SearchForTeacherCBox.Text = string.Empty;
                SearchForTeacherCBox.Foreground = Brushes.Black;
            }
        }
        private void SearchForTeacherCBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SearchForTeacherCBox.Text))
            {
                SearchForTeacherCBox.Text = "Choose an Instructor...";
                SearchForTeacherCBox.Foreground = Brushes.Gray;
            }
        }

        private void AddNewCourse_Click(object sender, RoutedEventArgs e)
        {
            using(context = new Mapping.AppContext())
            {
                if(this.LearnerName.Text == "")
                {
                    MessageBox.Show("You Must Enter The Student Name.");
                    return;
                }

                if (SearchForTeacherCBox.Visibility == Visibility.Visible)
                {
                    if (SearchForTeacherCBox.SelectedItem != null)
                    {
                        var instructor = ((Instructor)SearchForTeacherCBox.SelectedItem);
                        BrailleCourse course = new BrailleCourse
                        {
                            LearnerName = this.LearnerName.Text,
                            InstrutorId = instructor.Id
                        };

                        context.Add(course);
                        context.SaveChanges();

                        MessageBox.Show("Course is Added 👍");
                        this.BackToLastScreen(sender, e);
                    }
                    else
                        MessageBox.Show("You Must Select an Instructor First!");
                }
                else if (NewInstructorTBox.Visibility == Visibility.Visible)
                {
                    if (this.NewInstructorTBox.Text == "")
                    {
                        MessageBox.Show("You Must Enter The Instrutor Name.");
                        return;
                    }
                    else
                    {
                        var instructor = new Instructor { Name = this.NewInstructorTBox.Text };
                        context.Add(instructor);
                        context.SaveChanges();

                        BrailleCourse course = new BrailleCourse
                        {
                            LearnerName = this.LearnerName.Text,
                            InstrutorId = instructor.Id
                        };

                        context.Add(course);
                        context.SaveChanges();

                        MessageBox.Show("Course is Added 👍");
                        this.BackToLastScreen(sender, e);
                    }
                }
            }
        }

        private void AddNewInstructor_Click(object sender, RoutedEventArgs e)
        {
            this.NewInstrutorBtn.Visibility = Visibility.Collapsed;
            this.SearchForTeacherCBox.Visibility = Visibility.Collapsed;
            this.NewInstructorTBox.Visibility = Visibility.Visible;
        }
    }
}
