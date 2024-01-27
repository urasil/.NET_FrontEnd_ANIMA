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
using System.IO;
using Newtonsoft.Json;

namespace dotnetAnima
{
    /// <summary>
    /// Interaction logic for ManageVoicesWindow.xaml
    /// </summary>
    public partial class ManageVoicesWindow : Window
    {
        private string backendJsonContent = File.ReadAllText("../../backend.json");
        private Dictionary<string, string> backendJsonObject;
        public ManageVoicesWindow()
        {
            InitializeComponent();
            backendJsonObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(backendJsonContent);
            List<string> listOfNames = ExtractNames();

        }

        private List<string> ExtractNames()
        {
            string names = backendJsonObject["animaProfiles"];
            List<string> listOfNames = names.Split(' ').ToList();
            for(int i = 0; i < listOfNames.Count; i++) 
            {
                listOfNames[i] = listOfNames[i].Trim().Replace(".animaProfile", "");
            }
            return listOfNames;
        }


        private void RedoVoice(object sender, RoutedEventArgs e)
        {

        }

        private void ImportVoice(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteVoice(object sender, RoutedEventArgs e)
        {

        }

        private void SelectVoice(object sender, RoutedEventArgs e)
        {

        }

        private void Speak(object sender, RoutedEventArgs e)
        {
            TextToSpeechWindow speechWindow = new TextToSpeechWindow();
            this.Close();
            speechWindow.Left = this.Left;
            speechWindow.Top = this.Top;
            speechWindow.Show();
        }
    }
}
