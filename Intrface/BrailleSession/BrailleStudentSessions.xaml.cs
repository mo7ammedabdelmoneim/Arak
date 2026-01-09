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

namespace Intrface.BrailleSession
{
    public partial class BrailleStudentSessions : Window
    {
        Mapping.AppContext context;
        public static string? StudentName;

        public BrailleStudentSessions()
        {
            InitializeComponent();

            using (context = new Mapping.AppContext())
            {
                 StudentName = BrailleSessionInterface.SelectedStudentProfile?.Name;
                var sessions = context.BrailleSessions.AsNoTracking().Where(s=> s.StudentName == StudentName).Select(s=> new { s.StudentName , TName= s.Teacher.Name , date = s.Date.Date});
                this.HeaderText.Text = StudentName;
                List<BrailleSessionInfo> sessionsInfo = new List<BrailleSessionInfo>();
                foreach (var session in sessions)
                {
                    BrailleSessionInfo info = new BrailleSessionInfo();
                    info.StudentName = session.StudentName;
                    info.TeacherName = session.TName;
                    info.Date = session.date.ToLongDateString();
                    sessionsInfo.Add(info);
                }
                ListOfBrailleStudentsSessions.ItemsSource = sessionsInfo;
                ListOfBrailleStudentsSessions.SelectedIndex = -1;


                // fill counters
                var currentMonth = DateTime.Now.Month;
                var monthSessions = sessions.Where(s=> s.date.Month == currentMonth).Count();

                this.MonthSesions.Text = monthSessions.ToString();
                this.TotalSesions.Text = sessions.Count().ToString();
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
            BrailleSessionInterface brailleSession = new BrailleSessionInterface();
            this.Close();
            brailleSession.Show();
        }
        

        private void AddBrailleSession_Click(object sender, RoutedEventArgs e)
        {
            AddNewBrailleSession addNewBrailleSession = new AddNewBrailleSession();
            this.Close();
            addNewBrailleSession.Show();
        }
    }

}
