﻿/*
MIT License

Copyright (c) Léo Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. 
*/
using Gavilya.Classes;
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

namespace Gavilya.Pages.SettingsPages
{
	/// <summary>
	/// Logique d'interaction pour StartupPage.xaml
	/// </summary>
	public partial class StartupPage : Page
	{
		public StartupPage()
		{
			InitializeComponent();
			InitUI();
		}

		/// <summary>
		/// Add items to the combobox.
		/// </summary>
		private void InitUI()
		{
			CardsPageRadioBtn.IsChecked = Definitions.Settings.PageId == 0; // Check if the page ID is equal to 0
			RecentPageRadioBtn.IsChecked = Definitions.Settings.PageId == 1; // Check if the page ID is equal to 1
			ListPageRadioBtn.IsChecked = Definitions.Settings.PageId == 2; // Check if the page ID is equal to 2
		}

		Border CheckedBorder { get; set; }
		private void Border_MouseEnter(object sender, MouseEventArgs e)
		{
			Border border = (Border)sender;
			border.BorderBrush = new SolidColorBrush() { Color = Color.FromRgb(102, 0, 255) }; // Set color
		}

		private void Border_MouseLeave(object sender, MouseEventArgs e)
		{
			Border border = (Border)sender;
			if (border != CheckedBorder)
			{
				border.BorderBrush = new SolidColorBrush() { Color = Colors.Transparent }; // Set color 
			}
		}

		private void CardsPageBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			CardsPageRadioBtn.IsChecked = true; // Check
			CheckedBorder = CardsPageBorder; // Set checked border
			RefreshBorders(); // Refresh

			Definitions.Settings.PageId = 0; // Set the startup page
			SettingsSaver.Save(); // Save changes
		}

		private void RecentPageBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			RecentPageRadioBtn.IsChecked = true; // Check
			CheckedBorder = RecentPageBorder; // Set checked border
			RefreshBorders(); // Refresh

			Definitions.Settings.PageId = 1; // Set the startup page
			SettingsSaver.Save(); // Save changes
		}

		private void CardsPageRadioBtn_Checked(object sender, RoutedEventArgs e)
		{
			CheckedBorder = CardsPageBorder; // Set checked border
			RefreshBorders(); // Refresh
		}

		private void RecentPageRadioBtn_Checked(object sender, RoutedEventArgs e)
		{
			CheckedBorder = RecentPageBorder; // Set checked border
			RefreshBorders(); // Refresh
		}

		private void ListPageRadioBtn_Checked(object sender, RoutedEventArgs e)
		{
			CheckedBorder = ListPageBorder; // Set checked border
			RefreshBorders(); // Refresh
		}

		private void ListPageBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			ListPageRadioBtn.IsChecked = true; // Check
			CheckedBorder = ListPageBorder; // Set checked border
			RefreshBorders(); // Refresh

			Definitions.Settings.PageId = 2; // Set the startup page
			SettingsSaver.Save(); // Save changes
		}

		private void RefreshBorders()
		{
			CardsPageBorder.BorderBrush = new SolidColorBrush() { Color = Colors.Transparent }; // Set color 
			RecentPageBorder.BorderBrush = new SolidColorBrush() { Color = Colors.Transparent }; // Set color 
			ListPageBorder.BorderBrush = new SolidColorBrush() { Color = Colors.Transparent }; // Set color 

			CheckedBorder.BorderBrush = new SolidColorBrush() { Color = Color.FromRgb(102, 0, 255) }; // Set color
		}
	}
}
