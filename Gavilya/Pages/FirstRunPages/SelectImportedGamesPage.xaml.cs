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
using Gavilya.UserControls;
using Gavilya.Windows;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Gavilya.Pages.FirstRunPages
{
	/// <summary>
	/// Interaction logic for SelectImportedGamesPage.xaml
	/// </summary>
	public partial class SelectImportedGamesPage : Page
	{
		FirstRun FirstRun;
		public SelectImportedGamesPage(FirstRun firstRun)
		{
			InitializeComponent();
			FirstRun = firstRun; // Set

			InitUI(); // Load the UI
		}

		private void InitUI()
		{
			if (Definitions.Games.Count > 0) // If there are games
			{
				for (int i = 0; i < Definitions.Games.Count; i++)
				{
					GamePresenter.Children.Add(new ImportGameItem(Definitions.Games[i])); // Add item
				}
			}
		}

		private void NextBtn_Click(object sender, RoutedEventArgs e)
		{
			if (GamePresenter.Children.Count > 0)
			{
				List<GameInfo> gameInfos = new();

				for (int i = 0; i < GamePresenter.Children.Count; i++)
				{
					var game = (ImportGameItem)GamePresenter.Children[i];
					if (game.SelectCheckBox.IsChecked.Value)
					{
						gameInfos.Add(game.GameInfo); // Add 
					}
				}

				Definitions.Games = gameInfos; // Set
				new GameSaver().Save(Definitions.Games); // Save changes
			}

			FirstRun.ChangePage(Enums.FirstRunPages.Finish); // Change page
		}
	}
}
