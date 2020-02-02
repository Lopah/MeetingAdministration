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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeetingAdministrator.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainContent_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        //private void MainContent_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    var control = (sender as ContentControl);
        //    control.Content = (this.DataContext as TabControl).SelectedItem;
        //}

        //private void MainContent_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var control = (sender as ContentControl);
        //    control.Content = (this.DataContext as TabControl).SelectedItem;
        //}

        //private void TabControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var tabContent = (sender as TabControl);
        //    this.DataContext = tabContent;

        //}
    }
}
