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

namespace Intrface.MonthExams
{
    public partial class ExamsDetails : Window
    {
        Mapping.AppContext context;
        Student? Student;

        public ExamsDetails()
        {
            InitializeComponent();

            using (context = new Mapping.AppContext())
            {
                var BtnName = InsideClass.ClickedButton?.Name;
                int index = 0;
                for (var x = 0; x < InsideClass.ViewBtns?.Count(); x++)
                {
                    if (InsideClass.ViewBtns[x].Name == BtnName)
                        index = x;
                }

                var studentName = InsideClass.StudentsTBlocks?[index].Text;
                Student = context.Students.SingleOrDefault(S => S.Name == studentName);
                var studentSubjects = context.Subjects.Where(s => (s.GradeId == Student.GradeID) && (!s.Name.Contains("برايل"))).ToList();
                this.HeaderText.Text = studentName;

                var studentExams = context.MonthExams.Where(ME=> ME.StudentId == Student.StudentId).GroupBy(ME=> ME.MonthNumber).ToList();

                List<TextBlock> MonthsTBoxs = new List<TextBlock>() { this.Month1, this.Month2 , Month3 ,Month4,Month5 ,Month6,Month7,Month8,Month9 ,Month10, Month11, Month12};
                List<Grid> Containers = new List<Grid>() { this.Container1 ,Container2,Container3 ,Container4 ,Container5 ,Container6, Container7 ,Container8, Container9, Container10 ,Container11 ,Container12};

                List<TextBlock> month1Subjects = new List<TextBlock> { this.Subject1OfMonth1 , Subject2OfMonth1 ,Subject3OfMonth1 , Subject4OfMonth1 , Subject5OfMonth1,Subject6OfMonth1 , Subject7OfMonth1 };
                List<TextBlock> month2Subjects = new List<TextBlock> { this.Subject1OfMonth2 , Subject2OfMonth2 ,Subject3OfMonth2 , Subject4OfMonth2 , Subject5OfMonth2,Subject6OfMonth2 , Subject7OfMonth2 };
                List<TextBlock> month3Subjects = new List<TextBlock> { this.Subject1OfMonth3 , Subject2OfMonth3 ,Subject3OfMonth3 , Subject4OfMonth3, Subject5OfMonth3 ,Subject6OfMonth3, Subject7OfMonth3 };
                List<TextBlock> month4Subjects = new List<TextBlock> { this.Subject1OfMonth4 , Subject2OfMonth4 ,Subject3OfMonth4 , Subject4OfMonth4 ,Subject5OfMonth4 ,Subject6OfMonth4 ,Subject7OfMonth4 };
                List<TextBlock> month5Subjects = new List<TextBlock> { this.Subject1OfMonth5 , Subject2OfMonth5 ,Subject3OfMonth5 , Subject4OfMonth5 ,Subject5OfMonth5 ,Subject6OfMonth5 ,Subject7OfMonth5 };
                List<TextBlock> month6Subjects = new List<TextBlock> { this.Subject1OfMonth6 , Subject2OfMonth6 ,Subject3OfMonth6 , Subject4OfMonth6 ,Subject5OfMonth6 ,Subject6OfMonth6 ,Subject7OfMonth6 };
                List<TextBlock> month7Subjects = new List<TextBlock> { this.Subject1OfMonth7 , Subject2OfMonth7 ,Subject3OfMonth7 , Subject4OfMonth7 ,Subject5OfMonth7,Subject6OfMonth7 ,Subject7OfMonth7};
                List<TextBlock> month8Subjects = new List<TextBlock> { this.Subject1OfMonth8 , Subject2OfMonth8 ,Subject3OfMonth8 , Subject4OfMonth8 ,Subject5OfMonth8 ,Subject6OfMonth8 ,Subject7OfMonth8 };
                List<TextBlock> month9Subjects = new List<TextBlock> { this.Subject1OfMonth9 , Subject2OfMonth9 ,Subject3OfMonth9 , Subject4OfMonth9 ,Subject5OfMonth9 ,Subject6OfMonth9 ,Subject7OfMonth9 };
                List<TextBlock> month10Subjects = new List<TextBlock> { this.Subject1OfMonth10 , Subject2OfMonth10 ,Subject3OfMonth10 , Subject4OfMonth10 ,Subject5OfMonth10 ,Subject6OfMonth10 ,Subject7OfMonth10 };
                List<TextBlock> month11Subjects = new List<TextBlock> { this.Subject1OfMonth11 , Subject2OfMonth11 ,Subject3OfMonth11 , Subject4OfMonth11 ,Subject5OfMonth11 ,Subject6OfMonth11 ,Subject7OfMonth11 };
                List<TextBlock> month12Subjects = new List<TextBlock> { this.Subject1OfMonth12 , Subject2OfMonth12 ,Subject3OfMonth12 , Subject4OfMonth12 ,Subject5OfMonth12 ,Subject6OfMonth12 ,Subject7OfMonth12 };
                List<List<TextBlock>> monthsSubjects = new List<List<TextBlock>> { month1Subjects, month2Subjects, month3Subjects, month4Subjects, month5Subjects, month6Subjects, month7Subjects, month8Subjects ,month9Subjects, month10Subjects, month11Subjects , month12Subjects };

                List<TextBlock> MarkOfSubjectsMonth1 = new List<TextBlock> { this.MarkOfSubject1Month1, MarkOfSubject2Month1, MarkOfSubject3Month1, MarkOfSubject4Month1, MarkOfSubject5Month1 ,MarkOfSubject6Month1, MarkOfSubject7Month1 };
                List<TextBlock> MarkOfSubjectsMonth2 = new List<TextBlock> { this.MarkOfSubject1Month2, MarkOfSubject2Month2, MarkOfSubject3Month2, MarkOfSubject4Month2, MarkOfSubject5Month2 ,MarkOfSubject6Month2, MarkOfSubject7Month2 };
                List<TextBlock> MarkOfSubjectsMonth3 = new List<TextBlock> { this.MarkOfSubject1Month3, MarkOfSubject2Month3, MarkOfSubject3Month3, MarkOfSubject4Month3, MarkOfSubject5Month3 ,MarkOfSubject6Month3, MarkOfSubject7Month3 };
                List<TextBlock> MarkOfSubjectsMonth4 = new List<TextBlock> { this.MarkOfSubject1Month4, MarkOfSubject2Month4, MarkOfSubject3Month4, MarkOfSubject4Month4, MarkOfSubject5Month4 ,MarkOfSubject6Month4, MarkOfSubject7Month4 };
                List<TextBlock> MarkOfSubjectsMonth5 = new List<TextBlock> { this.MarkOfSubject1Month5, MarkOfSubject2Month5, MarkOfSubject3Month5, MarkOfSubject4Month5, MarkOfSubject5Month5 ,MarkOfSubject6Month5, MarkOfSubject7Month5 };
                List<TextBlock> MarkOfSubjectsMonth6 = new List<TextBlock> { this.MarkOfSubject1Month6, MarkOfSubject2Month6, MarkOfSubject3Month6, MarkOfSubject4Month6, MarkOfSubject5Month6 ,MarkOfSubject6Month6, MarkOfSubject7Month6 };
                List<TextBlock> MarkOfSubjectsMonth7 = new List<TextBlock> { this.MarkOfSubject1Month7, MarkOfSubject2Month7, MarkOfSubject3Month7, MarkOfSubject4Month7, MarkOfSubject5Month7 ,MarkOfSubject6Month7, MarkOfSubject7Month7 };
                List<TextBlock> MarkOfSubjectsMonth8 = new List<TextBlock> { this.MarkOfSubject1Month8, MarkOfSubject2Month8, MarkOfSubject3Month8, MarkOfSubject4Month8, MarkOfSubject5Month8 ,MarkOfSubject6Month8, MarkOfSubject7Month8 };
                List<TextBlock> MarkOfSubjectsMonth9 = new List<TextBlock> { this.MarkOfSubject1Month9, MarkOfSubject2Month9, MarkOfSubject3Month9, MarkOfSubject4Month9, MarkOfSubject5Month9 ,MarkOfSubject6Month9, MarkOfSubject7Month9 };
                List<TextBlock> MarkOfSubjectsMonth10 = new List<TextBlock> { this.MarkOfSubject1Month10 ,MarkOfSubject2Month10, MarkOfSubject3Month10, MarkOfSubject4Month10, MarkOfSubject5Month10 ,MarkOfSubject6Month10, MarkOfSubject7Month10 };
                List<TextBlock> MarkOfSubjectsMonth11 = new List<TextBlock> { this.MarkOfSubject1Month11 ,MarkOfSubject2Month11, MarkOfSubject3Month11, MarkOfSubject4Month11, MarkOfSubject5Month11 ,MarkOfSubject6Month11, MarkOfSubject7Month11 };
                List<TextBlock> MarkOfSubjectsMonth12 = new List<TextBlock> { this.MarkOfSubject1Month12 ,MarkOfSubject2Month12, MarkOfSubject3Month12, MarkOfSubject4Month12, MarkOfSubject5Month12 ,MarkOfSubject6Month12, MarkOfSubject7Month12 };
                List<List<TextBlock>> marksOfMonths = new List<List<TextBlock>> { MarkOfSubjectsMonth1, MarkOfSubjectsMonth2, MarkOfSubjectsMonth3, MarkOfSubjectsMonth4 ,MarkOfSubjectsMonth5, MarkOfSubjectsMonth6, MarkOfSubjectsMonth7, MarkOfSubjectsMonth8 ,MarkOfSubjectsMonth9, MarkOfSubjectsMonth10, MarkOfSubjectsMonth11, MarkOfSubjectsMonth12 };

                List<string> monthNames = new List<string> {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                int counter = 0;
                foreach (var examsOfMonth in studentExams)
                {
                    Containers[counter].Visibility = Visibility.Visible;
                    MonthsTBoxs[counter].Text = monthNames[(examsOfMonth.FirstOrDefault().MonthNumber) - 1];

                    var monthSubjects = monthsSubjects[counter];
                    var monthMarks = marksOfMonths[counter];
                    int insideCounter = 0;
                    foreach (var subject in studentSubjects)
                    {
                        monthSubjects[insideCounter].Text = subject.Name;
                        var mark = examsOfMonth.SingleOrDefault(E => E.SubjectId == subject.SubjectId);
                        if (mark != null)
                            monthMarks[insideCounter].Text = mark?.mark.ToString();
                        else
                            monthMarks[insideCounter].Text = "No Exam";

                        insideCounter++;
                    }
                    counter++;
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
            InsideClass insideClass = new InsideClass();
            this.Close();
            insideClass.Show();
        }


    }
}
