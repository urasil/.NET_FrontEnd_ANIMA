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
    /// Interaction logic for TextToSpeechWindow.xaml
    /// </summary>
    public partial class TextToSpeechWindow : Window
    {
        string jsonFilePath;
        Dictionary<string, string> jsonObject;
        public TextToSpeechWindow()
        {
            InitializeComponent();
            // Read the JSON file to get information about the current user
            jsonFilePath = @"../../abc.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            jsonObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);
            string nameOfUser = jsonObject["nameOfCurrentUser"];
            string newText = selectedVoice.Text + nameOfUser;
            selectedVoice.Text = newText;
        }

        // Send the content typed by the user via registering it to the Json file
        private void Speak(object sender, RoutedEventArgs e)
        {
            jsonObject["content"] = myTextBox.Text;
            string updatedJsonContent = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            File.WriteAllText(jsonFilePath, updatedJsonContent);
        }

        private void ManageVoices(object sender, RoutedEventArgs e)
        {
            //ManageVoicesWindow manageWindow = new ManageVoicesWindow();
            //this.Close();
            //manageWindow.Left = this.Left;
            //manageWindow.Top = this.Top;
            //manageWindow.Show();
        }

        private void ReadFromImageButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
