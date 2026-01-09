using Mapping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class AddExam : Window
    {
        Mapping.AppContext context;
        Student? Student;
        public AddExam()
        {
            InitializeComponent();

           using(context = new Mapping.AppContext())
            {
                var BtnName = InsideClass.ClickedButton?.Name;
                int index = 0;
                for (var x = 0; x < InsideClass.AddBtns?.Count(); x++)
                {
                    if (InsideClass.AddBtns[x].Name == BtnName)
                        index = x;
                }

                // Fill Subjects ComboBox
                var studentName = InsideClass.StudentsTBlocks?[index].Text;
                Student = context.Students.SingleOrDefault(S=> S.Name == studentName);
                var studentSubjects = context.Subjects.Where(g => (g.GradeId == Student.GradeID) && (!g.Name.Contains("برايل")) ).ToList();

                this.HeaderText.Text = studentName;
                this.SubjectCBox.ItemsSource = studentSubjects;

                // Fill Month ComboBox
                List<Month>? Months = new List<Month>
                {
                    new Month { Number = 1, Name = "January" },
                    new Month { Number = 2, Name = "February" },
                    new Month { Number = 3, Name = "March" },
                    new Month { Number = 4, Name = "April" },
                    new Month { Number = 5, Name = "May" },
                    new Month { Number = 6, Name = "June" },
                    new Month { Number = 7, Name = "July" },
                    new Month { Number = 8, Name = "August" },
                    new Month { Number = 9, Name = "September" },
                    new Month { Number = 10, Name = "October" },
                    new Month { Number = 11, Name = "November" },
                    new Month { Number = 12, Name = "December" },
                };
                this.MonthCBox.ItemsSource = Months;
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


        // Handling Subject ComboBox
        private void SubjectCBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SubjectCBox.Text == "Choose a Subject...")
            {
                SubjectCBox.Text = string.Empty;
                SubjectCBox.Foreground = Brushes.Black;
            }
        }
        private void SubjectCBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SubjectCBox.Text))
            {
                SubjectCBox.Text = "Choose a Subject...";
                SubjectCBox.Foreground = Brushes.Gray;
            }
        }

        // Handling Month ComboBox
        private void MonthCBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MonthCBox.Text == "Choose a Month...")
            {
                MonthCBox.Text = string.Empty;
                MonthCBox.Foreground = Brushes.Black;
            }
        }
        private void MonthCBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(MonthCBox.Text))
            {
                MonthCBox.Text = "Choose a Month...";
                MonthCBox.Foreground = Brushes.Gray;
            }
        }

        private void AddExam_Click(object sender, RoutedEventArgs e)
        {
            using(context =new Mapping.AppContext())
            {
                if (SubjectCBox.SelectedItem == null)
                {
                    MessageBox.Show("You must choose a subject");
                    return;
                }
                if (MonthCBox.SelectedItem == null)
                {
                    MessageBox.Show("You must choose a month");
                    return;
                }
                if (this.GradeTBox.Text == "")
                {
                    MessageBox.Show("You must enter a mark");
                    return;
                }

                var selectedSubjectId = ((Subject)SubjectCBox.SelectedItem).SubjectId;
                var selectedMonthNumber = ((Month)MonthCBox.SelectedItem).Number;

                var checkExam = context.MonthExams.Where(ME => (ME.StudentId == Student.StudentId) && (ME.SubjectId == selectedSubjectId) && (ME.MonthNumber == selectedMonthNumber)).Count();

                MonthExam exam = new MonthExam();

                var markIsValid = decimal.TryParse(GradeTBox.Text, out decimal markValue);
                if(markIsValid)
                {
                    if (markValue > 10 )
                    {
                        MessageBox.Show("Mark must be less than or equels 10");
                        return;
                    }
                    if(checkExam > 0)
                    {
                        MessageBox.Show("This exam has been recorded before!");
                        return;
                    }
                    exam.mark = markValue;
                }
                else
                {
                    MessageBox.Show("Mark is not valid, Try again.");
                    return;
                }
               
                exam.StudentId = Student.StudentId;
                exam.SubjectId = selectedSubjectId;
                exam.MonthNumber = selectedMonthNumber;
              
                context.Add(exam);
                context.SaveChanges();

                MessageBox.Show("Exam is recorded 👍");
                this.BackToLastScreen(sender, e);
            }
        }
    }
}
