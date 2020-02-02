using MeetingAdministrator.App.ViewModels.Details;
using System;
using System.Windows;

namespace MeetingAdministrator.App.Views.Details
{
    /// <summary>
    /// Interaction logic for EditEntityWindow.xaml
    /// </summary>
    public partial class EditEntityWindow : Window
    {
        private readonly EditEntityViewModel _viewModel;
        public EditEntityWindow()
        {
            InitializeComponent();
        }

        public EditEntityWindow(Type entityType, object entityValue)
        {
            InitializeComponent();

            ContentPanel.DataContext = entityValue == null ? Activator.CreateInstance(entityType) : entityValue;
            _viewModel = new EditEntityViewModel(ContentPanel, entityType, entityValue, this);
            this.DataContext = _viewModel;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = ContentPanel.DataContext;
            this.DialogResult = true;
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}