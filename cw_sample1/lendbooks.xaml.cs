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
using System.Data.SqlClient;

namespace cw_sample1
{
    /// <summary>
    /// Interaction logic for lendbooks.xaml
    /// </summary>
    public partial class lendbooks : Window
    {
        public lendbooks()
        {
            InitializeComponent();

            dbconnection obj1 = new dbconnection();

            string q = "SELECT lendid FROM lend ORDER BY lendid DESC;";
            string meid = obj1.GetNextMeid(q);
            txt_borrowid.Text = meid.ToString();

            datepicker.SelectedDate = DateTime.Today;
            this.datepicker.IsEnabled = false;
        }

        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();



        }
        private void btnreturn_Click(object sender, RoutedEventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt_borrowid.Clear();
            txt_memid.Clear();
            txt_bookid.Clear();

        }

        private void btn_getid_Click(object sender, RoutedEventArgs e)
        {

            dbconnection obj1 = new dbconnection();

            string q = "SELECT lendid FROM lend ORDER BY lendid DESC;";
            string meid = obj1.GetNextMeid(q);
            txt_borrowid.Text = meid.ToString();
        }

        private void btn_lend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbconnection obj2 = new dbconnection();
                string status = obj2.getData("select status from book where bookid='" + txt_bookid.Text + "';");
                if (string.IsNullOrEmpty(status)) { MessageBox.Show("Book ID not found in the database", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
               else if (status.Trim() == "taken")
                {
                    MessageBox.Show("The book is not available", "Sorry", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    {

                        dbconnection obj = new dbconnection();

                        string query = "insert into lend values('" + txt_borrowid.Text + "','" + txt_memid.Text + "','" + txt_bookid.Text + "','" + datepicker.SelectedDate + "')";
                        int line = obj.runcmd(query);
                        if (line == 1)
                        {
                            string update = "update book set status= 'taken' where bookid='" + txt_bookid.Text + "'";
                            obj.runcmd(update);

                            MessageBox.Show("Saved", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            txt_borrowid.Clear();
                            txt_memid.Clear();
                            txt_bookid.Clear();


                        }
                    }

                }
            }
            catch (NullReferenceException) { MessageBox.Show("Member ID or Book ID not found in the database", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Member ID or Book ID not found in the database", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Member ID or Book ID not found", "Try again", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Member ID or Book ID not found in the database", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            lendtableview obj = new lendtableview();
            obj.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
