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
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;

namespace WPFProga
{

    public partial class UserPage : Page
    {
        public string username = reg.userq.Username;
        public int weight = reg.userq.human.weight;
        public string sex = reg.userq.human.sex;
        public string target = reg.userq.human.target;

        public UserPage()
        {
            InitializeComponent();

            textBlockUsername1.Text = username;
            textBlockSex1.Text = sex;
            textBlockTarget1.Text = target;
            textBlockWeight1.Text = $"{weight}";
            textBoxUsername.Text = username;
            textBoxWeight.Text = $"{weight}";

        }
        public void ButtonTarget(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            target = pressed.Content.ToString();
        }


        public void Update(object sender, RoutedEventArgs e)
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
                reg.userq.Username = textBoxUsername.Text;
                textBlockUsername1.Text = textBoxUsername.Text;
                errormessage.Text = "Success";
                using (StreamWriter file = File.CreateText($@"{MainWindow.fullPath}\accounts777\user{reg.i}.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, reg.userq);
                }
            }
        }
        public void UpdateW(object sender, RoutedEventArgs e)
        {
            if (textBoxWeight.Text.Length == 0)
            {
                errormessage.Text = "Enter weight";
                textBoxWeight.Focus();
            }
            else
            {
                reg.userq.human.weight = Convert.ToInt32(textBoxWeight.Text);
                textBlockWeight1.Text = textBoxWeight.Text;
                errormessage.Text = "Success";
                using (StreamWriter file = File.CreateText($@"{MainWindow.fullPath}\accounts777\user{reg.i}.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, reg.userq);
                }
            }
        }
        public void UpdateT(object sender, RoutedEventArgs e)
        {
            if (target == "")
            {
                errormessage.Text = "Target must be chosen.";
                textBlockTarget.Focus();
            }
            else
            {
                reg.userq.human.target = target;
                textBlockTarget1.Text = target;
                errormessage.Text = "Success";
                using (StreamWriter file = File.CreateText($@"{MainWindow.fullPath}\accounts777\user{reg.i}.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, reg.userq);
                }
            }
        }
    }
}
