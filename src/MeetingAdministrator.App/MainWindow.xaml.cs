using System.Windows;

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