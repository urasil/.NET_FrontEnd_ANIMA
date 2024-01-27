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

namespace dotnetAnima
{
    /// <summary>
    /// Interaction logic for ManageVoicesWindow.xaml
    /// </summary>
    public partial class ManageVoicesWindow : Window
    {
        public ManageVoicesWindow()
        {
            InitializeComponent();
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
