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
    /// Interaction logic for membertable.xaml
    /// </summary>
    public partial class membertable : Window
    {
        public membertable()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            cw_sample1.lendtable lendtable = ((cw_sample1.lendtable)(this.FindResource("lendtable")));
            // Load data into the table lend. You can modify this code as needed.
            cw_sample1.lendtableTableAdapters.lendTableAdapter lendtablelendTableAdapter = new cw_sample1.lendtableTableAdapters.lendTableAdapter();
            lendtablelendTableAdapter.Fill(lendtable.lend);
            System.Windows.Data.CollectionViewSource lendViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lendViewSource")));
            lendViewSource.View.MoveCurrentToFirst();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            cw_sample1.lendtable lendtable = ((cw_sample1.lendtable)(this.FindResource("lendtable")));
            // Load data into the table lend. You can modify this code as needed.
            cw_sample1.lendtableTableAdapters.lendTableAdapter lendtablelendTableAdapter = new cw_sample1.lendtableTableAdapters.lendTableAdapter();
            lendtablelendTableAdapter.Fill(lendtable.lend);
            System.Windows.Data.CollectionViewSource lendViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lendViewSource")));
            lendViewSource.View.MoveCurrentToFirst();
        }

        private void Window_Loaded_2(object sender, RoutedEventArgs e)
        {

            cw_sample1.lendtable lendtable = ((cw_sample1.lendtable)(this.FindResource("lendtable")));
            // Load data into the table lend. You can modify this code as needed.
            cw_sample1.lendtableTableAdapters.lendTableAdapter lendtablelendTableAdapter = new cw_sample1.lendtableTableAdapters.lendTableAdapter();
            lendtablelendTableAdapter.Fill(lendtable.lend);
            System.Windows.Data.CollectionViewSource lendViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lendViewSource")));
            lendViewSource.View.MoveCurrentToFirst();
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

        private void Window_Loaded_3(object sender, RoutedEventArgs e)
        {

            cw_sample1.studenttable studenttable = ((cw_sample1.studenttable)(this.FindResource("studenttable")));
            // Load data into the table student. You can modify this code as needed.
            cw_sample1.studenttableTableAdapters.studentTableAdapter studenttablestudentTableAdapter = new cw_sample1.studenttableTableAdapters.studentTableAdapter();
            studenttablestudentTableAdapter.Fill(studenttable.student);
            System.Windows.Data.CollectionViewSource studentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("studentViewSource")));
            studentViewSource.View.MoveCurrentToFirst();
        }
    }
}
