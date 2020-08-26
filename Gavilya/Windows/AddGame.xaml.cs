﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gavilya.Windows
{
    /// <summary>
    /// Logique d'interaction pour AddGame.xaml
    /// </summary>
    public partial class AddGame : Window
    {
        public AddGame()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (Thread.CurrentThread.CurrentUICulture.ToString()) // Language of the user
            {
                case "fr-FR": // Language: French (France)
                    Title = "Ajouter un jeu"; // Change the title
                    break;
                case "en-US": // Language: English (United States)
                    Title = "Add a game"; // Change the title
                    break;
                default: // Language: English (United States)
                    Title = "Add a game"; // Change the title
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized; // Minimize the window
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close(); // Close the window
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // OpenFileDialog
            openFileDialog.Filter = "JPG|*.jpg|PNG|*.png|Bitmap|*.bmp|All Files|*.*"; // Filter
            
            if (openFileDialog.ShowDialog() ?? true) // If the user selected a file
            {
                try
                {
                    BitmapImage image = new BitmapImage(new Uri(openFileDialog.FileName)); // Create the image
                    GameImg.Source = image; // Set the GameImg's source to the image
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Show the error
                }
                
            }
        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // OpenFileDialog
            openFileDialog.Filter = "EXE|*.exe"; // Filter

            if (openFileDialog.ShowDialog() ?? true) // If the user selected a file
            {
                nameTxt.Text = openFileDialog.SafeFileName.Remove(openFileDialog.SafeFileName.Length - 4); // Name of the file

                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName); // Get the version

                versionTxt.Text = fileVersionInfo.FileVersion; // Version of the file
                locationTxt.Text = openFileDialog.FileName; // Location of the file
            }
        }
    }
}
