using Mapping.Entities;
using Intrface.Students;
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

namespace Intrface.Teachers
{

    public partial class TeacherProfile : Window
    {
        Mapping.AppContext context;
        Teacher teacher;

        public TeacherProfile()
        {
            InitializeComponent();

            using (context = new Mapping.AppContext())
            {
                if (TeachersWindow.SelectedTeacherProfile != null)
                {
                    teacher = TeachersWindow.SelectedTeacherProfile;

                    this.StudentName.Text = teacher.Name;
                    if (teacher.Age.ToString() != "")
                        this.Age.Text = teacher.Age.ToString();
                    if (teacher.Address != "")
                        this.Address.Text = teacher.Address;
                    if (teacher.Faculty != "")
                        this.Faculty.Text = teacher.Faculty;
                    if (teacher.Phone != "")
                        this.Phone.Text = teacher.Phone;

                    List<Braille_Session>? privateBrailleSessions = context.BrailleSessions.Where(s => s.TeacherId == teacher.TeacherId).ToList();

                    var totalSessions = context.Sessions.AsNoTracking().Where(S => S.TeacherId == teacher.TeacherId).Count();
                    var currenMonth = DateTime.Now.Month;
                    var withinThisMonth = context.Sessions.AsNoTracking().Where(S => S.TeacherId == teacher.TeacherId && S.Date.Month == currenMonth).Count();

                    

                    var teacherSubjects = context.Sessions.Where(S => S.TeacherId == teacher.TeacherId).GroupBy(S => S.SubjectId).ToList();
                    List<TextBlock> subjectTBoxs = new List<TextBlock> { this.Subject1, Subject2, Subject3, Subject4, Subject5, Subject6, Subject7, Subject8, Subject9, Subject10, Subject11, Subject12, Subject13, Subject14, Subject15 };
                    List<TextBlock> MonthValuesTBoxs = new List<TextBlock> { this.MonthValue1, MonthValue2, MonthValue3, MonthValue4, MonthValue5, MonthValue6, MonthValue7, MonthValue8, MonthValue9, MonthValue10, MonthValue11, MonthValue12, MonthValue13, MonthValue14, MonthValue15 };
                    List<TextBlock> TermValuesTBoxs = new List<TextBlock> { this.TermValue1, TermValue2, TermValue3, TermValue4, TermValue5, TermValue6, TermValue7, TermValue8, TermValue9, TermValue10, TermValue11, TermValue12, TermValue13, TermValue14, TermValue15 };
                    List<StackPanel> SubjectsContainers = new List<StackPanel> { this.SubjectsContainer1, SubjectsContainer2, SubjectsContainer3, SubjectsContainer4, SubjectsContainer5, SubjectsContainer6,
                                                                                        SubjectsContainer7, SubjectsContainer8, SubjectsContainer9, SubjectsContainer10 ,SubjectsContainer11, SubjectsContainer12, SubjectsContainer13, SubjectsContainer14, SubjectsContainer15};
                    int Counter = 0;

                    foreach (var subject in teacherSubjects)
                    {
                        SubjectsContainers[Counter].Visibility = Visibility.Visible;

                        var subjectName = context.Subjects.SingleOrDefault(S => S.SubjectId == subject.FirstOrDefault().SubjectId).Name;
                        subjectTBoxs[Counter].Text = subjectName;

                        MonthValuesTBoxs[Counter].Text = subject.Where(S => S.Date.Month == currenMonth).Count().ToString();

                        TermValuesTBoxs[Counter].Text = subject.Count().ToString();

                        Counter++;
                    }

                    // Add Private Braille Subject
                    if(privateBrailleSessions != null && privateBrailleSessions.Count() > 0)
                    {
                        SubjectsContainers[Counter].Visibility = Visibility.Visible;
                        subjectTBoxs[Counter].Text = privateBrailleSessions.FirstOrDefault()?.SubjectName;
                        MonthValuesTBoxs[Counter].Text = privateBrailleSessions.Where(s=> s.Date.Month == currenMonth).Count().ToString();
                        TermValuesTBoxs[Counter].Text = privateBrailleSessions.Count().ToString();

                        // increament Counters
                        withinThisMonth += privateBrailleSessions.Where(s => s.Date.Month == currenMonth).Count();
                        totalSessions += privateBrailleSessions.Count();
                    }


                    // Set Counters
                    this.ThisMonth.Text = withinThisMonth.ToString();
                    this.TotalSessionsValue.Text = totalSessions.ToString();

                }

            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
        private void BackToLastScreen(object sender, RoutedEventArgs e)
        {
            TeachersWindow teachers = new TeachersWindow();
            this.Close();
            teachers.Show();
        }
    }
} 