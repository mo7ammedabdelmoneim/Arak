using Mapping.Entities;
using Intrface.E_Day;
using Microsoft.Win32;
using System.IO;
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
using Path = System.IO.Path;

namespace Intrface.Students
{
    public partial class AddStudent : Window
    {
        Mapping.AppContext context;
        private readonly string imagesFolder;
        string savedImagePath = string.Empty;
        OpenFileDialog dlg = new OpenFileDialog
        {
            Filter = "Image|*.png;*.jpg;*.jpeg;*.gif;*.bmp",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        };

        public AddStudent()
        {
            InitializeComponent();

            string exePath = AppDomain.CurrentDomain.BaseDirectory;
            imagesFolder = Path.Combine(exePath, "Images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }
        }


        // Back Buttons
        private void BackToLastScreen(object sender, RoutedEventArgs e)
        {
            ClassMembers classMembers = new ClassMembers();
            this.Close();
            classMembers.Show();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }


        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    // تحميل الصورة المحددة
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.UriSource = new Uri(dlg.FileName, UriKind.Absolute);
                    bitmap.EndInit();

                    // عرض الصورة في الواجهة
                    StudentImage.Source = bitmap;                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء فتح أو حفظ الصورة: " + ex.Message);
                }
            }
        }

        private void AddNewStudent_Click(object sender, RoutedEventArgs e)
        {
            using(context = new Mapping.AppContext())
            {
                Student newStudent = new Student();
                // Name
                if(this.Name.Text == "")
                {
                    MessageBox.Show("You must enter Student Name");
                    return;
                }

                // Age
                if(this.Age.Text ==  "")
                {
                    MessageBox.Show("You must enter Student Age");
                    return;
                }
                var IsValid = byte.TryParse(this.Age.Text, out byte age);
                if(!IsValid)
                {
                    MessageBox.Show("Invalid Age, Enter it again");
                    return;
                }
               

                // Address
                if (this.Address.Text == "")
                {
                    MessageBox.Show("You must enter Student Address");
                    return;
                }

                // Parent Name
                if (this.ParentName.Text == "")
                {
                    MessageBox.Show("You must enter Parent Name");
                    return;
                }

                // Parent Phone
                if (this.ParentPhone.Text == "")
                {
                    MessageBox.Show("You must enter Parent Phone");
                    return;
                }
               

                if(dlg.FileName == "")
                {
                    this.ImagePopUp.IsOpen = true;
                }
                else
                {
                    
                    // حفظ نسخة من الصورة في مجلد Images
                    savedImagePath = Path.Combine(imagesFolder, $"{this.Name.Text}_{age}.jpg");

                    // في حال كانت هناك صورة محفوظة بنفس الاسم نقوم بحذفها أولاً
                    if (File.Exists(savedImagePath))
                    {
                        File.Delete(savedImagePath);
                    }
                    // نسخ الصورة إلى مجلد Images
                    File.Copy(dlg.FileName, savedImagePath, true); 
                    this.ConfirmationPopUp.IsOpen = true;
                }
            }
        }
      
        
        // PupUp Handling
        private void ConfirmAddStudent_PupUp(object sender, RoutedEventArgs e)
        {
            using(context = new Mapping.AppContext())
            {

                Student newStudent = new Student();

                newStudent.Name = this.Name.Text;
                byte.TryParse(this.Age.Text, out byte age);
                newStudent.Age = age;
                newStudent.Address = this.Address.Text;
                newStudent.Phone = this.Phone.Text;

                newStudent.ParentName = this.ParentName.Text;
                newStudent.ParentPhone = ParentPhone.Text;

                newStudent.GradeID = ClassMembers.Class.GradeID;


                context.Students.Add(newStudent);
                context.SaveChanges();

                // Exit
                this.ConfirmationPopUp.IsOpen = false;
                MessageBox.Show("Student is added");
                BackToLastScreen(sender, e);
            }
        }       
        private void CancelAddStudent_PupUp(object sender, RoutedEventArgs e)
        {
            this.ConfirmationPopUp.IsOpen = false;
        }

        private void UploadPupUp_Click(object sender, RoutedEventArgs e)
        {
            this.ImagePopUp.IsOpen = false;
            UploadImage_Click(sender, e);
        }
        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            this.ImagePopUp.IsOpen = false;
            this.ConfirmationPopUp.IsOpen = true;
        }

    }
}
