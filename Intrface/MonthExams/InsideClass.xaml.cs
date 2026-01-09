using Intrface.E_Day;
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

namespace Intrface.MonthExams
{
    public partial class InsideClass : Window
    {
        Mapping.AppContext context;
        public static List<Button>? AddBtns;
        public static List<Button>? ViewBtns;
        public static List<TextBlock>? StudentsTBlocks;
        public static Button? ClickedButton;
        public InsideClass()
        {
            InitializeComponent();
            using (context = new Mapping.AppContext())
            {
                //set header name with class name
                var className = ChooseClassForMonthExam.clickedButton?.Content.ToString();
                this.HeaderText.Text = className;

                var classId = context.Grades.AsNoTracking().SingleOrDefault(G => G.Name == className)?.GradeID;
                var classStudnets = context.Students.Where(S => S.GradeID == classId).ToList();

                StudentsTBlocks = new List<TextBlock>() { this.Student1, Student2, Student3, Student4, Student5, Student6, Student7, Student8, Student9, Student10, Student11, Student12, Student13, Student14, Student15 };
                List<TextBlock> PerfomanceValues = new List<TextBlock>() {this.PerfomanceValue1 ,PerfomanceValue2,PerfomanceValue3,PerfomanceValue4,PerfomanceValue5,PerfomanceValue6,PerfomanceValue7,PerfomanceValue8,PerfomanceValue9,PerfomanceValue10
                                                                            ,PerfomanceValue11 ,PerfomanceValue12,PerfomanceValue13,PerfomanceValue14,PerfomanceValue15};
                AddBtns = new List<Button>() { this.AddExamBtn1, AddExamBtn2, AddExamBtn3, AddExamBtn4, AddExamBtn5, AddExamBtn6, AddExamBtn7, AddExamBtn8, AddExamBtn9, AddExamBtn10, AddExamBtn11, AddExamBtn12, AddExamBtn13, AddExamBtn14, AddExamBtn15 };
                ViewBtns = new List<Button> { this.ViewExamBtn1, ViewExamBtn2, ViewExamBtn3, ViewExamBtn4, ViewExamBtn5, ViewExamBtn6, ViewExamBtn7, ViewExamBtn8, ViewExamBtn9, ViewExamBtn10, ViewExamBtn11, ViewExamBtn12, ViewExamBtn13, ViewExamBtn14, ViewExamBtn15 };
                List<Grid> Containers = new List<Grid>() { this.Container1, Container2, Container3, Container4, Container5, Container6, Container7, Container8, Container9, Container10, Container11, Container12, Container13, Container14, Container15 };
                int counter = 0;

                foreach (var student in classStudnets)
                {
                    Containers[counter].Visibility = Visibility.Visible;
                    StudentsTBlocks[counter].Text = student.Name;

                    var studentExams = context.MonthExams.AsNoTracking().Where(ME => ME.StudentId == student.StudentId).ToList();
                    decimal totalMarkPercent = 0;
                    foreach (var exam in studentExams)
                    {
                        totalMarkPercent += exam.mark * 10;
                    }
                    if(studentExams.Count() == 0)
                        PerfomanceValues[counter].Text = "No Exams Yet";
                    else
                        PerfomanceValues[counter].Text =  $"{((totalMarkPercent / studentExams.Count())):F2}%";

                    counter++;
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
            ChooseClassForMonthExam chooseClass = new ChooseClassForMonthExam();
            this.Close();
            chooseClass.Show();
        }


        private void AddExamBtn_Click(object sender, RoutedEventArgs e)
        {
            ClickedButton = sender as Button;
            AddExam addExam = new AddExam();
            this.Close();
            addExam.Show();
        }

        private void ViewExamBtn_Click(object sender, RoutedEventArgs e)
        {
            ClickedButton = sender as Button;
            ExamsDetails details = new ExamsDetails();
            this.Close();
            details.Show();
        }

    }
}
