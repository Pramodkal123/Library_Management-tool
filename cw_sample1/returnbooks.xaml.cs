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

namespace cw_sample1
{
    /// <summary>
    /// Interaction logic for returnbooks.xaml
    /// </summary>
    public partial class returnbooks : Window
    {
        public returnbooks()
        {
            InitializeComponent();
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
            txt_fine.Clear();
        

        }

        private void btn_cal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double fine = 0;
                dbconnection obj3 = new dbconnection();
                DateTime dlend = obj3.getdate("select bdate from lend where lendid='" + txt_borrowid.Text + "';");

                DateTime currentDate = DateTime.Today;


                TimeSpan difference = currentDate - dlend;
                int numberOfDays = difference.Days;
                if (numberOfDays > 7) { fine = (numberOfDays - 7) * 10; }
                else { fine = 0; }
                txt_fine.Text = fine.ToString();
            }
            catch (InvalidOperationException ex) { MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error); }
          
        }

        private void btn_return_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                dbconnection obj4 = new dbconnection();

                string bookid = obj4.getData("select bookid from lend where lendid='" + txt_borrowid.Text + "';");
              int i=  obj4.runcmd("update book set status= 'available' where bookid='" + bookid + "'");
                
               
                if (i == 1) { MessageBox.Show("Book successfully returned", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    txt_borrowid.Clear();
                    txt_fine.Clear();
                }
                else { MessageBox.Show("Please enter a valid reference No.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }

        }
    }
}
