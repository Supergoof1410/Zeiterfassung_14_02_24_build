using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Zeiterfassung_WPF
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        int attempt = 1;

        public Person person;

        public readonly SqliteConnection? sqliteConnLogin;
        readonly GetSqliteQuery getSqlAttendeeList = new GetSqliteQuery();
        public List<AttendeeList> attendeeList;

        TimeManagement timeManager;

        public Login()
        {
            sqliteConnLogin = ConnectSqlite.ConnectToSqlite(@".\SqliteDB\Teilnehmer.db");
            attendeeList = getSqlAttendeeList.GetAttendee(sqliteConnLogin!);
            person = new Person();

            InitializeComponent();
            //DialogResult = null;

            lblLoginError.Visibility = Visibility.Hidden;

            foreach (var items in attendeeList)
            {
                cbAttendeeList.Items.Add(items.Attendee_Number);
            }
            if (cbAttendeeList.SelectedIndex == -1)
            {
                btnLogin.IsEnabled = false;
                txtPass.IsEnabled = false;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (getSqlAttendeeList.CheckPassword(sqliteConnLogin!, txtPass.Password, cbAttendeeList.SelectedItem.ToString()!))
            {
                person.Tn_Value = cbAttendeeList.SelectedItem.ToString()!;

                DialogResult = true;
            }
            else
            {
                lblLoginError.Visibility = Visibility.Visible;
                lblLoginError.FontSize = 16;
                lblLoginError.Content = $"Login fehlgeschlagen ({attempt})";

                //if (attempt == 3) MessageBox.Show("Bitte strengen Sie sich an!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //else if (attempt > 3)
                //{
                //    MessageBox.Show("3 Fehlversuche sind menschlich, aber mehr sind Absicht!\nProgramm wird beendet!" +
                //        "", "Jetzt reicht es!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    Application.Exit();
                //}
                txtPass.Clear();
                attempt++;
                //sqliteConnLogin?.Close();
            }
        }

        private void cbAttendeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnLogin.IsEnabled = true;
            txtPass.IsEnabled = true;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            sqliteConnLogin?.Close();
            DialogResult = null;
            this.Close();
        }

        private void txtPass_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter) btnLogin_Click(sender, e);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sqliteConnLogin!.Close();
        }
    }
}
