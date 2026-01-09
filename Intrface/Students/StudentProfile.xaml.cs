using Mapping.Entities;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.IO;
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
using Path = System.IO.Path;


namespace Intrface.Students
{
    public partial class StudentProfile : Window
    {
        Mapping.AppContext context;
        Student Student = new Student() ;
        private string imagesFolder;
        string savedImagePath = string.Empty;
        OpenFileDialog dlg = new OpenFileDialog
        {
            Filter = "Image|*.png;*.jpg;*.jpeg;*.gif;*.bmp",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        };

        public StudentProfile()
        {
            InitializeComponent();

            if (this.StudentImage.Source == null)
            {
                this.UploadBorder.Visibility = Visibility.Visible;
            }
            else
            {
                this.UploadBorder.Visibility = Visibility.Collapsed;
            }

            using(context = new Mapping.AppContext())
            {
                if(StudentsWindow.SelectedStudentProfile != null)
                {
                     Student = StudentsWindow.SelectedStudentProfile;
                }
                if(ClassMembers.SelectedStudentProfile != null)
                {
                     Student = ClassMembers.SelectedStudentProfile;
                }

                // Insert Image
                

                // Show Image
                string folderPath = Path.Combine( AppDomain.CurrentDomain.BaseDirectory,"Images");
                if (Directory.Exists(folderPath))
                {
                    string imagePath = Path.Combine(folderPath, $"{Student.Name}_{Student.Age}.jpg");
                    if (File.Exists(imagePath))
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                        bitmap.EndInit();
                        // عرض الصورة في الواجهة
                        StudentImage.Source = bitmap;
                    }
                }


                if (Student != null)
                {
                    //< !--Student Info-- >
                    this.StudentName.Text = Student.Name;
                    this.StudentGrade.Text = context.Grades.AsNoTracking().Where(g => g.GradeID == Student.GradeID).Select(g => g.Name).FirstOrDefault();
                    if(Student.Age != null)
                    {
                        this.StudentAge.Text = $"سنه {Student.Age.ToString()} ";
                    }
                    this.StudentAddress.Text = Student.Address;
                    this.StudentPhone.Text = Student.Phone;


                    //< !--Parent Info-- >
                    this.ParentName.Text = Student.ParentName;
                    this.ParentPhone.Text = Student.ParentPhone;


                    //< !--Attendance-- >
                    var currentMonth = DateTime.Now.Month;
                    var privateBrailleSessions = context.BrailleSessions.Where(s=> s.StudentName == Student.Name).ToList();
                    var sessionsInMonth = context.SessionAttendances.AsNoTracking().Where(ST => (ST.StudentId == Student.StudentId) && (ST.Session.Date.Month == currentMonth)).Count();
                    var sessionsInTerm = context.SessionAttendances.AsNoTracking().Where(ST=> ST.StudentId == Student.StudentId).Count();
                    var numOfAllSessions = sessionsInTerm;

                    // increament counters
                    if(privateBrailleSessions != null && privateBrailleSessions.Count() > 0)
                    {
                        sessionsInMonth += privateBrailleSessions.Where(s => s.Date.Month == currentMonth).Count();
                        sessionsInTerm += privateBrailleSessions.Count();
                    }
                    // Sessions In Month
                    this.SessionsInMonth.Text = sessionsInMonth.ToString();

                    // Sessions In Term
                    this.SessionsInTerm.Text = sessionsInTerm.ToString();

                    // Absence Days 
                    var daysOfClass = context.Sessions.AsNoTracking().Select(s => s.Date.Date).Distinct().Count();
                    var daysOfStudent = context.SessionAttendances.AsNoTracking().Where(ST => ST.StudentId == Student.StudentId).
                                        Select(ST => ST.Session.Date.Date).Distinct().Count();
                    
                    var daysOfClassWithinMonth = context.Sessions.AsNoTracking().Where(s => s.Date.Month == currentMonth).Select(s => s.Date.Date).Distinct().Count();
                    var daysOfStudentWithinMonth = context.SessionAttendances.AsNoTracking()
                                                    .Where(ST => (ST.StudentId == Student.StudentId) && (ST.Session.Date.Month == currentMonth) ).
                                                    Select(ST => ST.Session.Date.Date).Distinct().Count();

                    var AbsenceDaysWithinMonth = daysOfClassWithinMonth - daysOfStudentWithinMonth;
                    var AbsenceDaysWithinTerm = daysOfClass - daysOfStudent;

                    this.AbsenceDays.Text = $"{AbsenceDaysWithinMonth}/{AbsenceDaysWithinTerm}";

                    // Attendance Percentage 
                    var allSessionsOfClass = context.Sessions.AsNoTracking().Where(s=> s.GradeID == Student.GradeID).Count();
                    double AttendancePercentage = ((double)numOfAllSessions / (double)allSessionsOfClass) * 100 ;
                    this.AttendancePercentage.Text = $"{AttendancePercentage:F2}%";


                    //< !--Courses-- >
                    this.Braille.Text = $"{context.SessionAttendances.AsNoTracking().Where(ST=> (ST.StudentId == Student.StudentId)  && (ST.Session.Subject.Name.Contains("برايل")) && (ST.Session.Date.Month == currentMonth)).Count().ToString()}/ {context.SessionAttendances.AsNoTracking().Where(ST=> (ST.StudentId == Student.StudentId)  && (ST.Session.Subject.Name.Contains("برايل"))).Count().ToString()}";
                    this.Arabic.Text  = $"{context.SessionAttendances.AsNoTracking().Where(ST=> (ST.StudentId == Student.StudentId)  && (ST.Session.Subject.Name.Contains("عربى")) && (ST.Session.Date.Month == currentMonth)).Count().ToString()}/{context.SessionAttendances.AsNoTracking().Where(ST=> (ST.StudentId == Student.StudentId)  && (ST.Session.Subject.Name.Contains("عربى"))).Count().ToString()}";
                    this.English.Text = $"{context.SessionAttendances.AsNoTracking().Where(ST=> (ST.StudentId == Student.StudentId)  && (ST.Session.Subject.Name.Contains("انجليزى")) && (ST.Session.Date.Month == currentMonth)).Count().ToString()}/{context.SessionAttendances.AsNoTracking().Where(ST => (ST.StudentId == Student.StudentId) && (ST.Session.Subject.Name.Contains("انجليزى"))).Count().ToString()}";

                    if(Student.GradeID < 7)
                    {
                        this.DifferentSubject.Text = "Math: ";
                        this.Subject4.Text = $"{context.SessionAttendances.AsNoTracking().Where(ST=> (ST.StudentId == Student.StudentId)  && (ST.Session.Subject.Name.Contains("حساب")) && (ST.Session.Date.Month == currentMonth)).Count().ToString()}/{context.SessionAttendances.AsNoTracking().Where(ST => (ST.StudentId == Student.StudentId) && (ST.Session.Subject.Name.Contains("حساب"))).Count().ToString()}";    
                    }
                    else
                    {
                        this.DifferentSubject.Text = "Studies: ";
                        this.Subject4.Text = $"{context.SessionAttendances.AsNoTracking().Where(ST => (ST.StudentId == Student.StudentId) && (ST.Session.Subject.Name.Contains("درسات")) && (ST.Session.Date.Month == currentMonth)).Count().ToString()}/{context.SessionAttendances.AsNoTracking().Where(ST => (ST.StudentId == Student.StudentId) && (ST.Session.Subject.Name.Contains("درسات"))).Count().ToString()}";
                    }
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
            if (ClassMembers.SelectedStudentProfile != null)
            {
                ClassMembers classMembers = new ClassMembers();
                this.Close();
                classMembers.Show();
            }
            else 
            {
                StudentsWindow studentsWindow = new StudentsWindow();
                this.Close();
                studentsWindow.Show();
            }



        }

        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            string exePath = AppDomain.CurrentDomain.BaseDirectory;
            imagesFolder = Path.Combine(exePath, "Images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            if(dlg.ShowDialog() == true)
            {
                // حفظ نسخة من الصورة في مجلد Images
                savedImagePath = Path.Combine(imagesFolder, $"{Student.Name}_{Student.Age}.jpg");

                // في حال كانت هناك صورة محفوظة بنفس الاسم نقوم بحذفها أولاً
                if (File.Exists(savedImagePath))
                {
                    File.Delete(savedImagePath);
                }
                // نسخ الصورة إلى مجلد Images
                File.Copy(dlg.FileName, savedImagePath, true);

                // تحميل الصورة المحددة
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.UriSource = new Uri(dlg.FileName, UriKind.Absolute);
                bitmap.EndInit();

                // عرض الصورة في الواجهة
                this.StudentImage.Source = bitmap;
                this.UploadBorder.Visibility = Visibility.Hidden;
            }

            
        }

        private void RemoveStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            this.ConfirmationPopUp.IsOpen = true;
        }

        private void ConfirmRemoveStudent(object sender, RoutedEventArgs e)
        {

            using (context = new Mapping.AppContext())
            {
                context.Remove(Student);
                context.SaveChanges();

                this.ConfirmationPopUp.IsOpen = false;
                MessageBox.Show("Student is Removed.");
                this.BackToLastScreen(sender,e);
            }
        }
        private void CancelRemoveStudent(object sender, RoutedEventArgs e)
        {
            this.ConfirmationPopUp.IsOpen = false;
        }

    }
}
