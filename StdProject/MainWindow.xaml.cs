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

namespace StdProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeView(new Students());
        }

        private void ChangeView(Page view)
        {
            mainFrame.NavigationService.Navigate(view);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult key = MessageBox.Show("Are you sure you want to quit?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            e.Cancel = (key == MessageBoxResult.Cancel);
        }
    }
}
