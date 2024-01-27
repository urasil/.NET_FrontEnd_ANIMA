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
        // Back end
        string backendJsonFilePath = @"../../backend.json";
        private string backendJsonContent = File.ReadAllText("../../backend.json");
        private Dictionary<string, string> backendJsonObject;

        // Front end
        string frontendJsonFilePath = @"../../frontend.json";
        private string frontendJsonContent = File.ReadAllText("../../frontend.json");
        private Dictionary<string, string> frontendJsonObject;
        List<string> listOfNames;
        public ManageVoicesWindow()
        {
            InitializeComponent();
            backendJsonObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(backendJsonContent);
            frontendJsonObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(frontendJsonContent);
            listOfNames = ExtractNames();
            string currentUser = frontendJsonObject["nameOfCurrentUser"];
            yourVoiceRadioButton.Content = currentUser;


            foreach (string name in listOfNames)
            {
                if(name != currentUser)
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton.Content = name;
                    radioButton.Name = name;
                    radioButton.Foreground = Brushes.AntiqueWhite;
                    radioButton.Margin = new Thickness(0, 0, 0, 10);
                    radioButton.FontSize = 25;
                    radioButton.FontWeight = FontWeights.DemiBold;
                    radioButton.FontStyle = FontStyles.Italic;
                    radioButton.FontFamily = new FontFamily("Times New Roman");
                    radioButton.GroupName = "VoiceSelection";
                    groupPanel.Children.Add(radioButton);
                }
                
            }

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

        private async void ImportVoice(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            bool? response = dialog.ShowDialog();
            if (response == true)
            {
                string filePath = dialog.FileName;
                frontendJsonObject["importFilePath"] = filePath;
                string updatedJsonContent = JsonConvert.SerializeObject(frontendJsonObject, Formatting.Indented);
                File.WriteAllText(frontendJsonFilePath, updatedJsonContent);
                await SendFileContentBackToFrontend();
                if(backendJsonObject["importSuccess"] == "false")
                {
                    MessageBox.Show("Coudln't create a voice profile from uploaded file");
                }
                
            }
        }

        private async Task SendFileContentBackToFrontend()
        {
            while (backendJsonObject["importSuccess"] != "true" || backendJsonObject["importSuccess"] != "false")
            {
                await Task.Delay(1000);
            }
        }

        private void DeleteVoice(object sender, RoutedEventArgs e)
        {

        }

        private void SelectVoice(object sender, RoutedEventArgs e)
        {
            string oldUser = frontendJsonObject["nameOfCurrentUser"];
            foreach (var child in groupPanel.Children)
            {
                if(child is RadioButton radioButton &&  radioButton.IsChecked == true)
                {
                    frontendJsonObject["nameOfCurrentUser"] = radioButton.Content.ToString();
                    string updatedJsonContent = JsonConvert.SerializeObject(frontendJsonObject, Formatting.Indented);
                    File.WriteAllText(frontendJsonFilePath, updatedJsonContent);
                    break;
                }
            }
            string currentUser = frontendJsonObject["nameOfCurrentUser"];
            foreach (var child in groupPanel.Children)
            {
                if (child is RadioButton radioButton)
                {
                    if (radioButton.Content == currentUser) 
                    {
                        radioButton.Content = oldUser;
                        break;
                    }
                }

            }
            yourVoiceRadioButton.Content = currentUser;
            yourVoiceRadioButton.IsChecked = true;

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
