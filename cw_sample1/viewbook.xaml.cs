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
    /// Interaction logic for viewbook.xaml
    /// </summary>
    public partial class viewbook : Window
    {
        public viewbook()
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


        private void btn_getid_Click(object sender, RoutedEventArgs e)
        {
            dbconnection obj2 = new dbconnection();
            try
            {

                string name = obj2.getData("select bname from book where bookid='" + txt_viewbookid.Text + "';");
                txt_name.Text = name;
                string email = obj2.getData("select genre from book where bookid='" + txt_viewbookid.Text + "';");
                txt_gen.Text = email;
                string tel = obj2.getData("select author from book where bookid='" + txt_viewbookid.Text + "';");
                txt_auth.Text = tel;
                string add = obj2.getData("select publisher from book where bookid='" + txt_viewbookid.Text + "';");
                txt_publisher.Text = add;
                if (string.IsNullOrEmpty(txt_name.Text))
                {
                    MessageBox.Show("Book ID not found. Please enter a valid ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Book ID not found. Please enter a valid ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt_viewbookid.Clear();
            txt_name.Clear();
            txt_gen.Clear();
            txt_auth.Clear();
            txt_publisher.Clear();
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            booktable obj = new booktable();
            obj.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}

