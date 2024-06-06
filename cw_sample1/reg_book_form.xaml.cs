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
    /// Interaction logic for reg_book_form.xaml
    /// </summary>
    public partial class reg_book_form : Window
    {
        public reg_book_form()
        {
            InitializeComponent();

            dbconnection obj1 = new dbconnection();

            string q = "SELECT bookid FROM book ORDER BY bookid DESC;";
            string meid = obj1.GetNextMeid(q);
            txt_bid.Text = meid.ToString();


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
            if ((txt_name.Text).Length==0) { MessageBox.Show("Please enter book name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);  }
            else if ((txt_gen.Text).Length == 0) { MessageBox.Show("Please enter book genre", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            else if ((txt_auth.Text).Length == 0) { MessageBox.Show("Please enter Author name", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            else if ((txt_pub.Text).Length == 0) { MessageBox.Show("Please enter Publisher name", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }


            else
            {
                dbconnection obj = new dbconnection();

                string query = "insert into book values('" + txt_bid.Text + "','" + txt_name.Text + "','" + txt_gen.Text + "','" + txt_auth.Text + "','" + txt_pub.Text + "','available')";
                int line = obj.runcmd(query);
                if (line == 1)
                {
                    MessageBox.Show("Book registerred successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    txt_bid.Clear();
                    txt_name.Clear();
                    txt_gen.Clear();
                    txt_auth.Clear();
                    txt_pub.Clear();
                }
                else MessageBox.Show("Data not saved", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            }

                private void Button_Click(object sender, RoutedEventArgs e)
                {
                    txt_bid.Clear();
                    txt_name.Clear();
                    txt_gen.Clear();
                    txt_auth.Clear();
                    txt_pub.Clear();
                }
                private void btnreturn_Click(object sender, RoutedEventArgs e)
                {
                    Home obj = new Home();
                    obj.Show();
                    this.Visibility = Visibility.Hidden;
                }

       
    }
            }
