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
using System.Text.RegularExpressions;

namespace cw_sample1
{
    /// <summary>
    /// Interaction logic for Register_form.xaml
    /// </summary>
    public partial class Register_form : Window
    {
  
        public Register_form()
        {
            InitializeComponent();



            dbconnection obj1 = new dbconnection();

            string q = "SELECT stid FROM student ORDER BY stid DESC;";
            string meid = obj1.GetNextMeid(q);
            txt_mid.Text = meid.ToString();

        }




        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
         }

        private void txt_mid_TextChanged(object sender, TextChangedEventArgs e)
        {
          

        }

        private void btn_regmem_Click(object sender, RoutedEventArgs e)
        {
            if ((txt_name.Text).Length == 0) { MessageBox.Show("Please enter Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            else if ((txt_email.Text).Length == 0) { MessageBox.Show("Please enter E-mail", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            else if (!Regex.IsMatch(txt_email.Text, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"))
            {
                MessageBox.Show("Please enter a valid E-mail", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if ((txt_tel.Text).Length == 0) { MessageBox.Show("Please enter Telephone", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            else if (!Regex.IsMatch(txt_tel.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$")) { MessageBox.Show("Please enter a valid telephone number", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            else if ((txt_add.Text).Length == 0) { MessageBox.Show("Please enter Address", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }


            else
            {
                dbconnection obj = new dbconnection();

                string query = "insert into student values('" + txt_mid.Text + "','" + txt_name.Text + "','" + txt_email.Text + "','" + txt_tel.Text + "','" + txt_add.Text + "')";
                int line = obj.runcmd(query);
                if (line == 1)
                {
                    email obje = new email();
                    obje.sendmail(txt_email.Text,"Library Registration","You have successfully registerred at the library");

                    MessageBox.Show("Member registerred successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    txt_mid.Clear();
                    txt_name.Clear();
                    txt_email.Clear();
                    txt_tel.Clear();
                    txt_add.Clear();
                    
                }
                else MessageBox.Show("Data not saved", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt_mid.Clear();
            txt_name.Clear();
            txt_email.Clear();
            txt_tel.Clear();
            txt_add.Clear();
        }

        private void btnreturn_Click(object sender, RoutedEventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Visibility = Visibility.Hidden;
        }

     
    }

}
