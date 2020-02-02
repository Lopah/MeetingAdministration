using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MeetingAdministrator.App.Views.Details
{
    /// <summary>
    /// Interaction logic for EditEntityWindow.xaml
    /// </summary>
    public partial class EditEntityWindow : Window
    {
        public EditEntityWindow()
        {
            InitializeComponent();
        }

        public EditEntityWindow(object entity)
        {
            DataContext = entity;
            InitializeComponent();
        }

        public void SetLabelAndTextBoxBasedOnProperty(object property)
        {
            throw new NotImplementedException();
        }
    }
}
