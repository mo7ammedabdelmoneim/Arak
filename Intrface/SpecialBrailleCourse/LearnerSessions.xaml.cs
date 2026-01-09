using Intrface.BrailleSession;
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
    public partial class LearnerSessions : Window
    {
        Mapping.AppContext context;
        public static string? StudentName;

        public LearnerSessions()
        {
            InitializeComponent();

            using (context = new Mapping.AppContext())
            {
                StudentName = BrailleCourseInterface.SelectedCourseProfile?.StudentName;
                var sessions = context.BrailleCourseSessions.AsNoTracking().Where(s => s.BrailleCourse.LearnerName == StudentName).Select(s=> s.Date.Date);
                this.HeaderText.Text = StudentName;
                List<BrailleCourseSessionDTO> sessionsInfo = new List<BrailleCourseSessionDTO>();
                foreach (var session in sessions)
                {
                    BrailleCourseSessionDTO info = new BrailleCourseSessionDTO();
                    info.TeacherName = BrailleCourseInterface.SelectedCourseProfile?.TeacherName;
                    info.Date = session.Date.ToLongDateString();
                    sessionsInfo.Add(info);
                }
                ListOfBrailleStudentsSessions.ItemsSource = sessionsInfo;
                ListOfBrailleStudentsSessions.SelectedIndex = -1;


                // fill counters
                var currentMonth = DateTime.Now.Month;
                var monthSessions = sessions.Where(s => s.Date.Month == currentMonth).Count();

                this.MonthSesions.Text = monthSessions.ToString();
                this.TotalSesions.Text = sessions.Count().ToString();

                var myCourse = context.BrailleCourses.AsNoTracking().SingleOrDefault(c => c.LearnerName == StudentName);
                // check course state
                if(myCourse?.State == "Finished")
                {
                    this.AddBrailleSessionBtn.Visibility = Visibility.Collapsed;
                    this.FinshCourseBtn.Visibility = Visibility.Collapsed;
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
            BrailleCourseInterface brailleSession = new BrailleCourseInterface();
            this.Close();
            brailleSession.Show();
        }

        private void AddBrailleSession_Click(object sender, RoutedEventArgs e)
        {
            using (context = new Mapping.AppContext())
            {
                MessageBoxResult confirmationResult = MessageBox.Show("Are You Sure To Add This Session?", "Add Session Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (confirmationResult == MessageBoxResult.OK)
                {
                    var courseId = context.BrailleCourses.AsNoTracking().SingleOrDefault(c=> c.LearnerName == StudentName)?.Id;
                    BrailleCourseSession courseSession = new BrailleCourseSession()
                    {
                        BrailleCourseId = courseId,
                        Date = DateTime.Now,
                    };

                    context.Add(courseSession);
                    context.SaveChanges();

                    MessageBox.Show("Session is Added 👍");
                    LearnerSessions learnerSessions = new LearnerSessions();
                    this.Close();
                    learnerSessions.Show();
                }
                else
                {
                    return;
                }
            }
        }

        private void FinshCourse_Click(object sender, RoutedEventArgs e)
        {
            using (context = new Mapping.AppContext())
            {
                var thisCourse = context.BrailleCourses.FirstOrDefault(C=> C.LearnerName ==StudentName);
                if(thisCourse != null)
                {
                    MessageBoxResult confirmationResult = MessageBox.Show("Are You Sure To Finish This Course?", "Finish Course Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (confirmationResult == MessageBoxResult.OK)
                    {
                        thisCourse.State = "Finished";
                        context.SaveChanges();

                        MessageBox.Show("This Course is Finished 👍");
                        this.BackToLastScreen(sender,e);
                    }
                    else
                    {
                        return;
                    }                    
                }
            }
        }
    }
}
