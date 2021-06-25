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
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace WPFProga
{

    public partial class log : Window
    {
        bool check = false;
        Train train = new Train();
        public log()
        {
            InitializeComponent();
        }
        reg registration = new reg();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else if (check != true)
            {
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                bool login = false;
                int j = 1;
                while (!login)
                {
                    if (File.Exists($@"{MainWindow.fullPath}\accounts777\user{j}.json"))
                    {
                        reg.userq = JsonConvert.DeserializeObject<User>(File.ReadAllText($@"{MainWindow.fullPath}\accounts777\user{j}.json"));
                        if (reg.userq.Username == email)
                        {
                            if (reg.userq.password == password)
                            {
                                login = true;
                                check = true;
                                Close();
                                train.Show();
                                reg.i = j;
                            }
                        }
                        j++;
                    }
                    else
                    {
                        errormessage.Text = "Неправильный логин или пароль.";
                        login = true;
                    }
                }
            }
            else
            {
                Close();
            }
        }
        private void ButtonReg(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }

        private void StackPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}
