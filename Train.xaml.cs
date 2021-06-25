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

namespace WPFProga
{
    public partial class Train : Window
    {
        MainWindow mw = new MainWindow();
        public Train()
        {
            InitializeComponent();
        }
        public void UserP(object sender, RoutedEventArgs e)
        {
            TrainPage.Content = new UserPage();
        }
        public void Tr(object sender, RoutedEventArgs e)
        {
            TrainPage.Content = new Training();
        }
        public void LogOut(object sender, RoutedEventArgs e)
        {
            Close();
            mw.Show();
        }

        private void TrainPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}
