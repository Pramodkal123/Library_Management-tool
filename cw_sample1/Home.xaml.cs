using System.Windows;

namespace cw_sample1
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
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

        private void btn_regbook_Click(object sender, RoutedEventArgs e)
        {
            reg_book_form obj = new reg_book_form();
            obj.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void btn_regmember_Click(object sender, RoutedEventArgs e)
        {
            Register_form obj = new Register_form();
            obj.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void btn_deletebook_Click(object sender, RoutedEventArgs e)
        {
            removebook obj = new removebook();
            obj.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void btn_delmember_Click(object sender, RoutedEventArgs e)
        {
            removemember obj = new removemember();
            obj.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void btn_viewmember_Click(object sender, RoutedEventArgs e)
        {
           viewmember obj=new viewmember();
            obj.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void btn_viewbook_Click(object sender, RoutedEventArgs e)
        {
            viewbook obj = new viewbook();
            obj.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void btn_lend_Click(object sender, RoutedEventArgs e)
        {
            lendbooks obj = new lendbooks();
            obj.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void btn_return_Click(object sender, RoutedEventArgs e)
        {
            returnbooks obj = new returnbooks();
            obj.Show();
            this.Visibility = Visibility.Hidden;

        }

        
    }
}
