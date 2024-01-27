using System;
using System.Collections.Generic;
using System.IO;
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

namespace dotnetAnima
{
    /// <summary>
    /// Interaction logic for AnimaHomePage.xaml
    /// </summary>
    public partial class AnimaHomePage : Page
    {
        public AnimaHomePage()
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
                    startButton.Margin = new Thickness(136, 319, 282, 47);
                }
            }
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BankVoiceWindow());
        }
    }
}
