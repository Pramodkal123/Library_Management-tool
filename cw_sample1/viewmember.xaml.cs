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
    /// Interaction logic for viewmember.xaml
    /// </summary>
    public partial class viewmember : Window
    {
        public viewmember()
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
            try {

                string name = obj2.getData("select name from student where stid='" + txt_viewmemid.Text + "';");
                txt_name.Text = name;
                string email = obj2.getData("select email from student where stid='" + txt_viewmemid.Text + "';");
                txt_email.Text = email;
                string tel = obj2.getData("select tel from student where stid='" + txt_viewmemid.Text + "';");
                txt_tel.Text = tel;
                string add = obj2.getData("select address from student where stid='" + txt_viewmemid.Text + "';");
                txt_add.Text = add;
                if (string.IsNullOrEmpty(txt_name.Text))
                {
                    MessageBox.Show("Member ID not found. Please enter valid ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Member ID not found. Please enter valid ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt_viewmemid.Clear();
            txt_name.Clear();
            txt_email.Clear();
            txt_tel.Clear();
            txt_add.Clear();
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            membertable obj = new membertable();
            obj.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
