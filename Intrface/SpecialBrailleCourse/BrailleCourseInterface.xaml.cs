using Intrface.BrailleSession;
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

namespace Intrface.SpecialBrailleCourse
{
    public partial class BrailleCourseInterface : Window
    {
        Mapping.AppContext context;
        List<BrailleCourseDBO>? ListOfBrailleCourse = new List<BrailleCourseDBO>();
        public static BrailleCourseDBO? SelectedCourseProfile;
        int counter;

        public BrailleCourseInterface()
        {
            InitializeComponent();

            using(context = new Mapping.AppContext())
            {
                var brailleCourses = context.BrailleCourses.AsNoTracking().ToList();
                if (brailleCourses != null && brailleCourses.Count > 0)
                {
                    foreach (var course in brailleCourses)
                    {
                        var instructorName = context.Instructors.AsNoTracking().SingleOrDefault(i => i.Id == course.InstrutorId)?.Name;
                        var sessionsNumber = context.BrailleCourseSessions.AsNoTracking().Where(s => s.BrailleCourseId == course.Id).Count();

                        BrailleCourseDBO brailleCourse = new BrailleCourseDBO
                        {
                            StudentName = course.LearnerName,
                            TeacherName = instructorName,
                            State = course.State,
                            SessionsNumber = sessionsNumber
                        };

                        ListOfBrailleCourse.Add(brailleCourse);
                    }
                    this.ListOfBrailleCourses.ItemsSource = ListOfBrailleCourse;
                    this.ListOfBrailleCourses.SelectedIndex = -1;
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

        private void ListOfBrailleCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListOfBrailleCourses.SelectedIndex == 0 && counter == 0)
            {
                ListOfBrailleCourses.SelectedItem = null;
                counter++;
            }
            if (ListOfBrailleCourses.SelectedItem != null)
            {
                SelectedCourseProfile = (BrailleCourseDBO)ListOfBrailleCourses.SelectedItem;


                LearnerSessions sessions = new LearnerSessions();
                this.Close();
                sessions.Show();
            }
        }

        private void AddNewCourse_Click(object sender, RoutedEventArgs e)
        {
            AddNewCourse addNewCourse = new AddNewCourse();
            this.Close();
            addNewCourse.Show();
        }
    }
}
