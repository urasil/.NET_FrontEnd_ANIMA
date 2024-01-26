using dotnetAnima.Core;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace dotnetAnima
{
    /// <summary>
    /// Interaction logic for BankVoiceWindow.xaml
    /// </summary>
    public partial class BankVoiceWindow : Window
    {
        int progressCount, textCount, buttonClickedCount;
        List<string> stringList;
        AudioRecorder recorder;
        public BankVoiceWindow()
        {
            InitializeComponent();
            TextSeperator textSeperator = new TextSeperator();
            recorder = new AudioRecorder();   
            stringList = textSeperator.ReadAndSeparateText();
            this.progressCount = 0;
            this.buttonClickedCount = 0;
            this.textCount = 0;
            pageText.Text = stringList[0];
        }

        // The method that runs when the START RECORDING button is pressed
        private void StartRecording(object sender, RoutedEventArgs e)
        {
            this.buttonClickedCount++;

            // Starting the voice recording
            if(this.buttonClickedCount == 1)
            {
                recorder.StartRecording("../../output.wav");
                restartButton.Visibility = Visibility.Visible;
            }

            // Ending the voice recording
            if(this.buttonClickedCount == 11) 
            {
                recorder.StopRecording();
                listenButton.Visibility = Visibility.Visible;
            }

            // Going to the next page
            // TODO:: IMPLEMENT NEXT PAGE AND NAVIGATION
            if(this.buttonClickedCount == 12)
            {
                recorder.StopSound();
            }
            this.textCount++;
            ChangeInstructions();
            ChangeButtonName();
            ChangeText();
            ChangeBorderColors();
        }

        // Handling the actions after restart button has been pressed
        public void RestartClick(object sender, RoutedEventArgs e)
        {
            recorder.StopRecording();
            recorder.StopSound();
            this.buttonClickedCount = 0;
            this.textCount = 0;
            this.progressCount = 0;
            pageText.Text = stringList[0];
            instructions.Inlines.Clear();
            instructions.Inlines.Add(new Run("Select START READING") { FontWeight = FontWeights.Bold });
            instructions.Inlines.Add(new LineBreak());
            instructions.Inlines.Add(new Run("then begin reading"));
            instructions.Inlines.Add(new LineBreak());
            instructions.Inlines.Add(new Run("the text below"));


            foreach (var child in progress.Children)
            {
                
                if (child is Border anyBorder)
                {
                    anyBorder.Background = Brushes.White;
                }
                
                if (progress.Children[progressCount] is Border border)
                {
                    border.Background = Brushes.DeepSkyBlue;
                }
            }
            restartButton.Visibility = Visibility.Hidden;
            listenButton.Visibility = Visibility.Hidden;

        }

        // Playing sound after listen recording button has been pressed
        public void ListenRecording(object sender, RoutedEventArgs e)
        {
            recorder.PlaySound();
        }

        // Changing the instructions at the top of the window
        public void ChangeInstructions()
        {

            if (this.buttonClickedCount == 1)
            {
                instructions.Inlines.Clear();
                instructions.Inlines.Add(new Run(" RECORDING STARTED") { FontWeight = FontWeights.Bold });
                instructions.Inlines.Add(new LineBreak());
                instructions.Inlines.Add(new Run("read through all pages"));
                instructions.Inlines.Add(new LineBreak());
                instructions.Inlines.Add(new Run("ps: small mistakes are fine!") { FontSize = 14, FontWeight = FontWeights.DemiBold, FontStyle = FontStyles.Italic});
            }
            else if (this.buttonClickedCount == 10)
            {
                instructions.Inlines.Clear();
                instructions.Inlines.Add(new Run("Select FINISH READING") { FontWeight = FontWeights.Bold });
                instructions.Inlines.Add(new LineBreak());
                instructions.Inlines.Add(new Run("to stop recording"));
            }
            else if (this.buttonClickedCount == 11)
            {
                instructions.Inlines.Clear();
                instructions.Inlines.Add(new Run("     Select ALL DONE!") { FontWeight = FontWeights.Bold });
                instructions.Inlines.Add(new LineBreak());
                instructions.Inlines.Add(new Run("     to continue"));
            }
        }

        // Changing the text that the user is reading
        public void ChangeText()
        {
            if(this.buttonClickedCount != 1) 
            {
                if(stringList.Count > this.textCount)
                {
                    pageText.Text = stringList[this.textCount];

                }
            }  
            else 
            {
                this.textCount--;
            }
        }

        // Changing the main button name appropriately 
        public void ChangeButtonName()
        {
            if(this.buttonClickedCount == 1) 
            {
                lovelyButton.Content = "READ NEXT PAGE";
            }
            if(this.buttonClickedCount == 10) 
            {
                lovelyButton.Content = "FINISH READING";
            }
            if(this.buttonClickedCount == 11)
            {
                lovelyButton.Content = "ALL DONE!";
            }
        }

        // Changing the progress bar colors
        private void ChangeBorderColors()
        {
            if (progressCount >= 0 && progressCount < progress.Children.Count)
            {
                foreach (var child in progress.Children)
                {
                    if (child is Border anyBorder)
                    {
                        anyBorder.Background = Brushes.White;
                    }
                }

                // Set the selected border color to blue
                if (progress.Children[progressCount] is Border border)
                {
                    border.Background = Brushes.DeepSkyBlue;
                }
                this.progressCount++;
            }
        }
    }
}
