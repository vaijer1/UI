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
using System.IO;

namespace WPFProga
{

    public partial class MainWindow : Window
    {
        //public static string path1 = @"accounts777";
        //public static string fullPath = System.IO.Path.GetFullPath(path1);
        static string fullpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        public static string fullPath = fullpath.Substring(0, fullpath.Length - 10);
        public MainWindow()
        {
            InitializeComponent();

        }
        public void ButtonReg(object sender, RoutedEventArgs e)
        {
            reg reg = new reg();
            reg.Show();
            Close();
        }
        private void ButtonLog(object sender, RoutedEventArgs e)
        {
            log log = new log();
            log.Show();
            Close();
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}
