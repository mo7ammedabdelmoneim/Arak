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
    public partial class ChooseClass : Window
    {
        Mapping.AppContext context;
        List<string> classesNames;
        public static Button? clickedButton;
        public static ClassAttendance? ClassAttendance;




        public ChooseClass()
        {
            InitializeComponent();
            using (context = new Mapping.AppContext())
            {
                List<Button> Classes = new List<Button>() {this.Btn1,Btn2,Btn3,Btn4,Btn5,Btn6,Btn7,Btn8,Btn9,Btn10,Btn11,Btn12 };
                classesNames = context.Grades.AsNoTracking().Select(x => x.Name).ToList();
                int counter = 0;
                foreach (var className in classesNames)
                {
                    Classes[counter].Content = className;
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

        private void OpenInsideClass(object sender, RoutedEventArgs e)
        {
             clickedButton = sender as Button;
            
            if(clickedButton != null)
            {
                ClassAttendance = new ClassAttendance();

                this.Close();
                ClassAttendance.Show();
            } 

            
        }
    }
}
