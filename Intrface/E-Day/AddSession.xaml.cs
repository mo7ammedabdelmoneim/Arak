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
using Mapping.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intrface.E_Day
{
    public partial class AddSession : Window
    {
        public ICollection<Teacher>? Teachers;
        public List<CheckBox>? allStudentsInSubject = new List<CheckBox>();
        public List<CheckBox>? AttendingStudentsCBoxes = new List<CheckBox>();
        public List<Student>? AttendingStudents = new List<Student>();
        public Mapping.AppContext context;
        public byte classId;
        public Subject? subject;

        public AddSession()
        {
            InitializeComponent();

            using (context = new Mapping.AppContext())
            {
                //set header title with subject name
                var subjectName = ClassAttendance.ClickedSubjectButton.Content;
                this.HeaderText.Text = subjectName.ToString();

                //fill listBox
                var className = ChooseClass.clickedButton?.Content;
                classId = context.Grades.Where(g => g.Name == className).Select(g => g.GradeID).FirstOrDefault();
                //var Students = context.Students.Where(s => s.GradeID == classId).ToList();

                // fill comboBox
                Teachers = context.Teachers.ToList();
                TeacherComboBox.ItemsSource = Teachers;

                //Determine the subjct as object
                subject = context.Subjects.Where(s => s.GradeId == classId && s.Name.Contains($"{subjectName}")).FirstOrDefault();

                //Determine the Teacher of the subjct as object
                var teacherId = subject.TeacherId;

                //set Default teacher
                var SelectedTeacher = context.Teachers.SingleOrDefault(t => t.TeacherId == teacherId);
                TeacherComboBox.SelectedItem = SelectedTeacher;

                // Provide CheckBoxes
                AddCheckBoxesOfClassInDay();

            }
        }

        // Provide CheckBoxes
        private void AddCheckBoxesOfClassInDay()
        {
            var Temp = ClassAttendance.AllStudents.Select(s => new CheckBox { Content = s.Content, IsChecked = s.IsChecked });
            foreach (var st in Temp)
            {
                CheckBox NewCheckBox = new CheckBox()
                {
                    Content = st.Content,
                    IsChecked = st.IsChecked,
                    Style = (Style)FindResource("CheckBoxStyle")
                };
                allStudentsInSubject.Add(NewCheckBox);
            }
            foreach (CheckBox? student in allStudentsInSubject)
            {
                if (!this.CheckBoxesContainerForSubject.Children.Contains(student) && student.Parent == null)
                {
                    student.Style = (Style)FindResource("CheckBoxStyle");
                    this.CheckBoxesContainerForSubject.Children.Add(student);
                }
            }

        }


        private void BackToLastScreen(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChooseClass.ClassAttendance?.Show();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }


        private void AddSessionButton_Click(object sender, RoutedEventArgs e)
        {
            //********* PopUp ************
            //Get Attending Students
            if (!this.ConfirmationPopUp.IsOpen)
            {
                using (context = new Mapping.AppContext())
                {
                    List<CheckBox> AttendingStudentsCBoxes = allStudentsInSubject.Where(s => s.IsChecked == true).ToList();
                    var allStudentsOfGrade = context.Students.Where(s => s.GradeID == classId).ToList();

                    foreach (var studentCheckBox in AttendingStudentsCBoxes)
                    {
                        foreach (var student in allStudentsOfGrade)
                        {
                            if (student.Name.Contains($"{studentCheckBox.Content}") && !AttendingStudents.Contains(student))
                            {
                                AttendingStudents.Add(student);
                            }
                        }
                    }

                    //fill Attending Students listBox In PopUp ,Teacher and Subject
                    foreach (var item in StudentsInSessionInPopUp?.Items)
                    {
                        StudentsInSessionInPopUp.Items.Remove(item);
                    }
                    this.StudentsInSessionInPopUp.ItemsSource = AttendingStudents;


                    this.SubjectInPopUp.Text = ClassAttendance.ClickedSubjectButton.Content.ToString();
                    this.TeacherInPopUp.Text = ((Teacher)TeacherComboBox.SelectedItem).Name;


                    //Check if there ia any Student
                    if (AttendingStudents.Count == 0)
                    {
                        MessageBox.Show("Must be at least 1 student to add session!");
                        AttendingStudents.Clear();
                        StudentsInSessionInPopUp.ItemsSource = null;
                        // AddSessionButton_Click(sender,e);
                    }
                    else
                    {
                        this.ConfirmationPopUp.IsOpen = true;
                    }
                }
            }
        }

        private void ConfirmAddSession(object sender, RoutedEventArgs e)
        {

            using (context = new Mapping.AppContext())
            {
                // Add session in DB
                Session newSession = new Session()
                {
                    GradeID = classId,
                    TeacherId = ((Teacher)TeacherComboBox.SelectedItem).TeacherId,
                    SubjectId = subject.SubjectId,
                    Date = DateTime.Now,
                };
                context.Sessions.Add(newSession);
                context.SaveChanges();

                // Record Attending students in DB
                if(AttendingStudents != null)
                {
                    foreach (var st in AttendingStudents)
                    {
                        SessionAttendance newSessionAttendance = new SessionAttendance()
                        {
                            SessionID = newSession.Id,
                            StudentId = st.StudentId,
                        };
                        context.SessionAttendances.Add(newSessionAttendance);
                    }
                }
                context.SaveChanges();



                // Exit from session
                this.ConfirmationPopUp.IsOpen = false;
                MessageBox.Show($"Session is Added {(char)2}");
                this.Close();


                ChooseClass.ClassAttendance?.Show();

            }
        }

        private void CancelAddSession(object sender, RoutedEventArgs e)
        {
            this.StudentsInSessionInPopUp.ItemsSource = null;
            AttendingStudents.Clear();
            this.ConfirmationPopUp.IsOpen = false;

        }
    }
}
