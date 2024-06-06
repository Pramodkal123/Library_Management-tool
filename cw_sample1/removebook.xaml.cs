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
    /// Interaction logic for removebook.xaml
    /// </summary>
    public partial class removebook : Window
    {
        public removebook()
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

        private void btn_removebook_Click(object sender, RoutedEventArgs e)
        {
            dbconnection obj = new dbconnection();

            string query = "Delete from book where bookid = '" + txt_bookid.Text + "'";
            int line = obj.runcmd(query);
            if (line == 1)
            {
                MessageBox.Show("Book deleted Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                txt_bookid.Clear();
            }
            else
            {
                MessageBox.Show("Book ID not found. Please enter valid ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_bookid.Clear();
            }
        }
    }
}
