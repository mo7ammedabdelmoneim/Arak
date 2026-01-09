using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using Intrface.E_Day;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;
using Intrface.Students;
using Intrface.Teachers;
using Intrface.MonthExams;
using Microsoft.EntityFrameworkCore.Migrations;
using Mapping;
using Intrface.BrailleSession;
using Intrface.SpecialBrailleCourse;

namespace Intrface
{
    
    public partial class MainWindow : Window
    {
        public static ChooseClass chooseClass;
        public MainWindow()
        {
            InitializeComponent();

            DataOfApp.SeedData();

            #region Random Images
            //BitmapImage bitmap = new BitmapImage();
            //bitmap.BeginInit();
            //bitmap.CacheOption = BitmapCacheOption.OnLoad;

            //Random randomImg = new Random();
            //int num = randomImg.Next(1, 3);
            //switch (num)
            //{
            //    case 1:
            //        bitmap.UriSource = new Uri("C: \\Users\\AFAQE\\source\\repos\\Migration\\Intrface\\Images\\FB_IMG_1737574413529.jpg", UriKind.Absolute);
            //        bitmap.EndInit();
            //        break;
            //    case 2:
            //        bitmap.UriSource = new Uri("C:\\Users\\AFAQE\\source\\repos\\Migration\\Intrface\\Images\\photo.jpg", UriKind.Absolute);
            //        bitmap.EndInit();
            //        break; 
            //}

            //this.img.Source = bitmap;

            #endregion


            #region Counters
            using (var context = new Mapping.AppContext())
            {
                var SessionsWithinTerm = (context?.Sessions?.Count() + context.BrailleSessions.AsNoTracking().Count()) ?? 0;
                RightCounter.Text = $"{SessionsWithinTerm}";



                var currentMonth = DateTime.Now.Month;
                var SessionsWithinCurrntmonth = (context?.Sessions?.AsNoTracking().ToList().Where(s => s.Date.Month == currentMonth).Count() + context.BrailleSessions.AsNoTracking().Where(s=>s.Date.Month == currentMonth).Count() )?? 0;
                LeftCounter.Text = $"{SessionsWithinCurrntmonth}";
            } 
            #endregion


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            chooseClass = new ChooseClass();
            this.Close();
            chooseClass.Show();
        }

        private void OpenStudentsWindow(object sender, RoutedEventArgs e)
        {
            StudentsWindow students = new StudentsWindow();
            this.Close();
            students.Show();
        }

        private void OpenTeachersWindow(object sender, RoutedEventArgs e)
        {
            TeachersWindow teachers = new TeachersWindow();
            this.Close();
            teachers.Show();
        }

        private void OpenMonthExamsWindow(object sender, RoutedEventArgs e)
        {
            ChooseClassForMonthExam monthExam = new ChooseClassForMonthExam();
            this.Close();
            monthExam.Show();
        }

        private void BrailleSession_Click(object sender, RoutedEventArgs e)
        {
            BrailleSessionInterface brailleSession = new BrailleSessionInterface();
            this.Close(); 
            brailleSession.Show();
        }

        private void OpenBrailleCoursesWindow(object sender, RoutedEventArgs e)
        {
            BrailleCourseInterface brailleCourse = new BrailleCourseInterface();
            this.Close();
            brailleCourse.Show();
        }
    }
}