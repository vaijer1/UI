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
using Newtonsoft.Json;
using System.IO;


namespace WPFProga
{

    public partial class Training : Page
    {
        public Training()
        {
            InitializeComponent();

            if (reg.userq.human.sex == "Male")
            {
                if (reg.userq.human.target == "Keep in shape")
                {
                    string Weekday = JsonConvert.DeserializeObject<string>(File.ReadAllText(($@"{MainWindow.fullPath}\trainings\keep_in_shape_male.json")));
                    textBlockM.Text = "Monday:  " + Weekday;
                    textBlockT.Text = "Tuesday:  " + Weekday;
                    textBlockTh.Text = "Thursday:  " + Weekday;
                    textBlockF.Text = "Friday:  " + Weekday;
                    textBlockS.Text = "Sunday:  " + Weekday;
                }
                if (reg.userq.human.target == "Gain weight")
                {
                    string Weekday = JsonConvert.DeserializeObject<string>(File.ReadAllText(($@"{MainWindow.fullPath}\trainings\gain_weight_male.json")));
                    textBlockM.Text = "Monday:  " + Weekday;
                    textBlockT.Text = "Tuesday:  " + Weekday;
                    textBlockTh.Text = "Thursday:  " + Weekday;
                    textBlockF.Text = "Friday:  " + Weekday;
                    textBlockS.Text = "Sunday:  " + Weekday;
                }
                if (reg.userq.human.target == "Lose weight")
                {
                    string Weekday = JsonConvert.DeserializeObject<string>(File.ReadAllText(($@"{MainWindow.fullPath}\trainings\lose_weight_male.json")));
                    textBlockM.Text = "Monday:  " + Weekday;
                    textBlockT.Text = "Tuesday:  " + Weekday;
                    textBlockTh.Text = "Thursday:  " + Weekday;
                    textBlockF.Text = "Friday:  " + Weekday;
                    textBlockS.Text = "Sunday:  " + Weekday;
                }
            }
            else
            {
                if (reg.userq.human.target == "Keep in shape")
                {
                    string Weekday = JsonConvert.DeserializeObject<string>(File.ReadAllText(($@"{MainWindow.fullPath}\trainings\keep_in_shape_female.json")));
                    textBlockM.Text = "Monday:  " + Weekday;
                    textBlockT.Text = "Tuesday:  " + Weekday;
                    textBlockTh.Text = "Thursday:  " + Weekday;
                    textBlockF.Text = "Friday:  " + Weekday;
                    textBlockS.Text = "Sunday:  " + Weekday;
                }
                if (reg.userq.human.target == "Gain weight")
                {
                    string Weekday = JsonConvert.DeserializeObject<string>(File.ReadAllText(($@"{MainWindow.fullPath}\trainings\gain_weight_female.json")));
                    textBlockM.Text = "Monday:  " + Weekday;
                    textBlockT.Text = "Tuesday:  " + Weekday;
                    textBlockTh.Text = "Thursday:  " + Weekday;
                    textBlockF.Text = "Friday:  " + Weekday;
                    textBlockS.Text = "Sunday:  " + Weekday;
                }
                if (reg.userq.human.target == "Lose weight")
                {
                    string Weekday = JsonConvert.DeserializeObject<string>(File.ReadAllText(($@"{MainWindow.fullPath}\trainings\lose_weight_female.json")));
                    textBlockM.Text = "Monday:  " + Weekday;
                    textBlockT.Text = "Tuesday:  " + Weekday;
                    textBlockTh.Text = "Thursday:  " + Weekday;
                    textBlockF.Text = "Friday:  " + Weekday;
                    textBlockS.Text = "Sunday:  " + Weekday;
                }
            }
        }
    }
}
