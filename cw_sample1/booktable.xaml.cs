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
    /// Interaction logic for booktable.xaml
    /// </summary>
    public partial class booktable : Window
    {
        public booktable()
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            cw_sample1.bookdataset bookdataset = ((cw_sample1.bookdataset)(this.FindResource("bookdataset")));
            // Load data into the table book. You can modify this code as needed.
            cw_sample1.bookdatasetTableAdapters.bookTableAdapter bookdatasetbookTableAdapter = new cw_sample1.bookdatasetTableAdapters.bookTableAdapter();
            bookdatasetbookTableAdapter.Fill(bookdataset.book);
            System.Windows.Data.CollectionViewSource bookViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bookViewSource")));
            bookViewSource.View.MoveCurrentToFirst();
        }
    }
}
