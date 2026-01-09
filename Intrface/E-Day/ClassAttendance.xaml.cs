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

namespace Intrface.E_Day
{
    public partial class ClassAttendance : Window
    {
        public Mapping.AppContext context;
        public static Grade? grade;
        public static List<string>? Students;
        public static Button? ClickedSubjectButton;
        public static List<CheckBox>? AllStudents;


        public ClassAttendance()
        {
            InitializeComponent();

            using ( context = new Mapping.AppContext())
            {
                //set header name with class name
                var className = ChooseClass.clickedButton.Content.ToString();
                this.HeaderText.Text = className;

                //fill listbox
                var classId = context.Grades.AsNoTracking().Where(g=> g.Name == className).Select(g=>g.GradeID).FirstOrDefault();
                Students = context.Students.AsNoTracking().Where(s => s.GradeID == classId).Select(s=>s.Name).ToList();

                // fill subjects buttons
                List<Button> SubjectButtons = new List<Button>() { this.btnSub1, btnSub2, btnSub3, btnSub4 ,btnSub5 ,btnSub6 };
                var Subjects = context.Subjects.AsNoTracking().Where(s=>s.GradeId == classId).Select(s=>s.Name).ToList();
                int counter = 0;
                foreach (var subject in Subjects)
                {
                    string[] words = subject.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length > 0 && words[0] != "قراءة" && words[0] != "كتابة")
                    {
                        SubjectButtons[counter].Visibility = Visibility.Visible;
                        SubjectButtons[counter].Content = words[0];
                        counter++;
                    }
                }

                // Provide CheckBoxes
                AddCheckBoxesOfClassInDay();
            }
        }


        // Provide CheckBoxes
        private void AddCheckBoxesOfClassInDay()
        {
            AllStudents = new List<CheckBox>();
            foreach (var student in Students)
            {
               var checkBox= new CheckBox()
                {
                    Content = student,
                    Style = (Style)FindResource("CheckBoxStyle")
                };
                CheckBoxesContainer.Children.Add(checkBox);
                AllStudents.Add(checkBox);
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
            ChooseClass chooseClass = new ChooseClass();
            this.Close();
            chooseClass.Show();
        }
        private void ListOfStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void SubjectSession(object sender, RoutedEventArgs e)
        {
            ClickedSubjectButton = sender as Button;

            if (ClickedSubjectButton != null)
            {
                AddSession addSession = new AddSession();

                this.Hide();
                addSession.Show();
            }
        }
    }
}
