﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dices_comp_assignment
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
		    Title = "Roll";
			//InitializeComponent();
            InitializeContent();
		}

	    void InitializeContent()
	    {
            var mainLayout = new StackLayout();
            StackLayout gridStack = new StackLayout();
            Grid grid = new Grid();
            gridStack.Children.Add(grid);
            var rollButton = new Button
            {
                Text = "Roll",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var picker = new Picker
	        {
	            Title = "Select number of dices",
                Items =
                {
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6"
                },
                
        };
           
	        rollButton.Clicked += (sender, args) => InitializeGrid(grid, int.Parse(picker.Items[picker.SelectedIndex]));
            var bottomLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    picker,
                    rollButton
                },  
            };
            mainLayout.Children.Add(gridStack);
            mainLayout.Children.Add(bottomLayout);
            mainLayout.Spacing = 10;
            Content = mainLayout;
        }
        void InitializeGrid(Grid grid,int number)
        {
            //Starting with clearting everything in the grid so its emtpy
            grid.Children.Clear();
            //The to for loops for the row and colums
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < (number - 1) / 2 + 1; j++)
                {
                    var diceImg = new Image { Aspect = Aspect.AspectFit };
                    Random rand = new Random();
                    int num = rand.Next(1, 7);
                    if (num == 1)
                    {
                        diceImg.Source = ImageSource.FromFile("dice_one.png");
                    }
                    if (num == 2)
                    {
                        diceImg.Source = ImageSource.FromFile("dice_two.png");
                    }
                    if (num == 3)
                    {
                        diceImg.Source = ImageSource.FromFile("dice_three.png");
                    }
                    if (num == 4)
                    {
                        diceImg.Source = ImageSource.FromFile("dice_four.png");
                    }
                    if (num == 5)
                    {
                        diceImg.Source = ImageSource.FromFile("dice_five.png");
                    }
                    if (num == 6)
                    {
                        diceImg.Source = ImageSource.FromFile("dice_six.png");
                    }

                    if (grid.Children.Count < number)
                    {
                        grid.Children.Add(diceImg, i, j);
                    }
                }
            }
        }
    }
}
