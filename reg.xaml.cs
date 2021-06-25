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
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace WPFProga
{
    public class User
    {
        public string Username;
        public string password;
        public Human human;
    }
    public class Human
    {
        public int weight;
        public string target;
        public string sex;
    }
    public partial class reg : Window
    {
        public string sex = "";
        public string target = "";
        MainWindow mw = new MainWindow();
        public static int i = 1;
        public static User userq = new User();
        public reg()
        {
            InitializeComponent();
        }
        public void Login_Click(object sender, RoutedEventArgs e)
        {
            log login = new log();
            login.Show();
            Close();
        }
        public void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            mw.ButtonReg(sender, e);
        }
        public void Reset()
        {
            Close();
        }

        public void ButtonSex(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            sex = pressed.Content.ToString();
        }
        public void ButtonTarget(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            target = pressed.Content.ToString();
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            mw.Show();
            Close();
        }
        public void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxUsername.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxUsername.Focus();
            }
            else if (!Regex.IsMatch(textBoxUsername.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxUsername.Select(0, textBoxUsername.Text.Length);
                textBoxUsername.Focus();
            }
            else
            {
                string username = textBoxUsername.Text;
                string weight = textBoxWeight.Text;
                string password = passwordBox1.Password;
                if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    errormessage.Text = "Enter Confirm password.";
                    passwordBoxConfirm.Focus();
                }
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    errormessage.Text = "Confirm password must be same as password.";
                    passwordBoxConfirm.Focus();
                }
                else if (sex == "")
                {
                    errormessage.Text = "Sex must be chosen.";
                    textBlockSex.Focus();
                }
                else if (target == "")
                {
                    errormessage.Text = "Target must be chosen.";
                    textBlockTarget.Focus();
                }
                else
                {
                    userq.Username = username;
                    userq.password = password;
                    Human human = new Human();
                    human.weight = Convert.ToInt32(weight);
                    human.sex = sex;
                    human.target = target;
                    userq.human = human;
                    List<string> users = new List<string>();
                    bool a = true;
                    while (a)
                    {
                        if (File.Exists($@"{MainWindow.fullPath}\accounts777\user{i}.json"))
                        {
                            users.Add($"user{i}.json");
                      	    i++;
                        
                        }
                        else
                        {
                            a = false;
                        }
                    }
                    using (StreamWriter file = File.CreateText($@"{MainWindow.fullPath}\accounts777\user{ users.Count + 1}.json"))
                    {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Serialize(file, userq);
                        }
                        errormessage.Text = "You have Registered successfully.";
                        Train train = new Train();
                        train.Show();
                        Close();

                }
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}