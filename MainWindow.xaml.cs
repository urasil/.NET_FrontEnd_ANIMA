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

namespace dotnetAnima
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string path = @"../../animaProfiles";
            InitializeComponent();
            if (Directory.Exists(path))
            {
                string[] directoriesWithinPath = Directory.GetFiles(path);
                if (directoriesWithinPath.Length > 0)
                {
                    desc.Inlines.Clear();
                    desc.Inlines.Add(new Run("                                                    Welcome Back!") { FontWeight = FontWeights.Bold });
                    startButton.Content = "Text-to-Speech";
                    startButton.Margin = new Thickness(136,319,282,47);
                }
            }

        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            BankVoiceWindow bankWindow = new BankVoiceWindow();
            this.Close();
            bankWindow.Left = this.Left;
            bankWindow.Top = this.Top;
            bankWindow.Show();
        }
    }
}
