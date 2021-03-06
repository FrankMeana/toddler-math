﻿/* 
 * File: GamePage.xaml.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: Contains the Interaction logic for GamePage.xaml
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using ToddlerMath.Models;

namespace ToddlerMath
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        /// <summary>
        /// The Toddler Math Player specified in the StartPage
        /// </summary>
        private Player player;

        /// <summary>
        /// The equation to generate
        /// </summary>
        private Equation equation = new Equation();

        /// <summary>
        /// represents the result of a generated equation
        /// </summary>
        private int result;

        /// <summary>
        /// A random potato to be generated in the Game
        /// </summary>
        private Potato randomPotato;

        /// <summary>
        /// represents the number of correct answers
        /// </summary>
        private int rightAnswers = 0;

        /// <summary>
        /// Represents the index of the heart to remove when player loses a life
        /// Starts at 4 because that is the index of the Child image of a StackPanel where the first
        /// heart to remove is located
        /// </summary>
        private int heartIndex = 4;

        /// <summary>
        /// Constructs a GamePage
        /// </summary>
        public GamePage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Construct a GamePage with the specified player
        /// </summary>
        /// <param name="player"></param>
        public GamePage(Player player)
        {
            InitializeComponent();

            // assign the player passed to the player field
            this.player = player;

            // generate an Equation and set the result variable to the return value of method Generate
            result = equation.Generate();

            // generate a random Potato
            randomPotato = Potato.Generate();

            // update GUI labels with the numbers generated by the equation
            DisplayEquation();

            // display potato images to GUI
            DisplayPotatoImages();
        }

        /// <summary>
        /// Displays the stats to the GUI (Namely the correct answers and the player score)
        /// </summary>
        private void DisplayStats()
        {
            correctAnswersLabel.Content = rightAnswers;
            scoreLabel.Content = player.Score;
        }

        /// <summary>
        /// Updates the GUI labels with the numbers generated (by using the variables I specified in their Name property in XAML)
        /// </summary>
        private void DisplayEquation()
        {
            firstNumberLabel.Content = equation.FirstNumber;
            operatorLabel.Content = equation.GetOperator();
            secondNumberLabel.Content = equation.SecondNumber;
        }

        /// <summary>
        /// Displays potato images on the Grids below the equation.
        /// The template used for the grids depends on the operator generated. In the case of addition, DisplayPotatoesAdded is invoked displaying the addition template
        /// In the case of subtraction, DisplayPotatoesSubtracted is invoked displaying the subtraction template for the grids
        /// </summary>
        private void DisplayPotatoImages()
        {
            if (equation.GetOperator().Equals("+"))
                DisplayPotatoesAdded();

            else
                DisplayPotatoesSubtracted();
        }


        /// <summary>
        /// Displays potato images in the grid below the equation's numbers. The amount of potatoes in both grids matches exacty the number in the equation above it.
        /// This template for the grid images will be used in the case of addition
        /// </summary>
        private void DisplayPotatoesAdded()
        {
            // Declare an image (to be used for altering the potatoes displayed in the for loop)
            Image image;

            // Display potato images corresponding to first number
            // iterate for as long as the length of the first number, access each image and change its source
            for (int i = 0; i < equation.FirstNumber; i++)
            {
                image = firstNumberPotatoGrid.Children[i] as Image;
                image.Source = new BitmapImage(new Uri(randomPotato.ImageSource(), UriKind.Relative));
            }

            // Display potato images corresponding to second number
            // iterate for as long as the length of the second number, access each image and change its source
            for (int i = 0; i < equation.SecondNumber; i++)
            {
                image = secondNumberPotatoGrid.Children[i] as Image;
                image.Source = new BitmapImage(new Uri(randomPotato.ImageSource(), UriKind.Relative));
            }
        }

        /// <summary>
        /// Displays potato images only in the grid below the first number. The other grid below the second number remains empty. Instead, what occurs is images in the first grid are
        /// crossed out. The number of crossed out images corresponds exactly to the second number which are the amount of potatoes subtracted.
        /// This template for the grids will be used in the case of subtraction
        /// </summary>
        private void DisplayPotatoesSubtracted()
        {
            // Declare an image (to be used for altering the potatoes displayed in the for loop)
            Image image;

            // Display potato images corresponding to the result (which is how many are actually left)
            // iterate for as long as the length of the result, access each image and change its source
            for (int i = 0; i < result; i++)
            {
                image = firstNumberPotatoGrid.Children[i] as Image;
                image.Source = new BitmapImage(new Uri(randomPotato.ImageSource(), UriKind.Relative));
            }

            // Display the potatoes that are subtracted faded
            // iterate for as long as the length of (FINISH DESCRIBING THIS) 
            for (int i = result; i < equation.FirstNumber; i++)
            {
                image = firstNumberPotatoGrid.Children[i] as Image;

                // USE CROSSED OUT IMAGE HERE !!! 
                image.Source = new BitmapImage(new Uri(randomPotato.CrossedImageSource(), UriKind.Relative));
            }
        }


        /// <summary>
        /// Clears all potato images from both grids under the equation generated
        /// </summary>
        private void ClearPotatoImages()
        {
            // Declare an image (to be used for altering the potatoes displayed in the for loop)
            Image image;

            // Display potato images corresponding to first number
            // iterate for as long as the length of the first number, access each image and change its source to null
            for (int i = 0; i < equation.FirstNumber; i++)
            {
                image = firstNumberPotatoGrid.Children[i] as Image;
                image.Source = null;
            }

            // Display potato images corresponding to second number
            // iterate for as long as the length of the second number, access each image and change its source to null
            for (int i = 0; i < equation.SecondNumber; i++)
            {
                image = secondNumberPotatoGrid.Children[i] as Image;
                image.Source = null;
            }

        }

        
        /// <summary>
        /// Reusable method that checks losing and winning conditions for player and sends them to the corresponding page.
        /// It also takes an answer which allows me to reuse it in all button event handlers by passing a different argument
        /// for each one
        /// </summary>
        /// <param name="answer">A Player's answer to the Equation</param>
        private void Answer(int answer)
        {
            // check the Player's answer against the actual result of the Equation
            if (answer == result)
            {
                // increment rightAnswers field if the answer is correct
                rightAnswers++;
                player.Score += 50;

                // might have to call DisplayStats here instead to give the user a glimpse of their final stats and comment other
                //DisplayStats();

                // ***** CHANGE THIS BACK TO 10 (ITS JUST 5 NOW FOR TESTING PURPOSES OF DATASET) *****
                // check winning condition
                if (rightAnswers == 10)
                {
                    // later send some Player object or any object with data the Win page requires
                    NavigationService.Navigate(new WinPage(player));
                }
            }
            else
            {
                // decrement Player's lives if the answer is wrong
                player.Lives--;
                // get the image from the statsPanel at the index specified and cast (with keyword as) the return type to an Image
                Image image = statsPanel.Children[heartIndex] as Image;
                // set the source of the heart image to a blank heart
                image.Source = new BitmapImage(new Uri(@"/Images/empty_heart.png", UriKind.Relative)); // = null; (for no image at all)
                // decrement the heartIndex in order to change the correct heart next time
                heartIndex--;

                // decrement the player score by 25
                player.Score -= 25;

                // might have to call DisplayStats here instead to give the user a glimpse of their final stats and comment other
                //DisplayStats();

                // check losing condition
                if (player.Lives == 0)
                {
                    // later send some Player object or any object with data the Lose page requires
                    NavigationService.Navigate(new LosePage(player));
                }
            }

            
            ClearPotatoImages();

            // Eitherway, generate another problem and store its result into the result field
            result = equation.Generate();

            // generate a random Potato
            randomPotato = Potato.Generate();

            // might have to comment this one out but not sure and call this method above where I specified myself
            DisplayStats();

            // update the GUI to display the new problem
            DisplayEquation();

            DisplayPotatoImages();
            
        }

        /* --- Button Event Handlers ---  */

        /// <summary>
        /// When the Zero button is pressed, the Answer method is invoked and the value of 0 is passed to it
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void ZeroButtonClicked(object sender, RoutedEventArgs e)
        {
            Answer(0);
        }

        /// <summary>
        /// When the One button is pressed, the Answer method is invoked and the value of 1 is passed to it
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void OneButtonClicked(object sender, RoutedEventArgs e)
        {
            Answer(1);
        }

        /// <summary>
        /// When the Two button is pressed, the Answer method is invoked and the value of 2 is passed to it
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void TwoButtonClicked(object sender, RoutedEventArgs e)
        {
            Answer(2);
        }

        /// <summary>
        /// When the Three button is pressed, the Answer method is invoked and the value of 3 is passed to it
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void ThreeButtonClicked(object sender, RoutedEventArgs e)
        {
            Answer(3);
        }

        /// <summary>
        /// When the Four button is pressed, the Answer method is invoked and the value of 4 is passed to it
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void FourButtonClicked(object sender, RoutedEventArgs e)
        {
            Answer(4);
        }

        /// <summary>
        /// When the Five button is pressed, the Answer method is invoked and the value of 5 is passed to it
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void FiveButtonClicked(object sender, RoutedEventArgs e)
        {
            Answer(5);
        }

        /// <summary>
        /// When the Six button is pressed, the Answer method is invoked and the value of 6 is passed to it
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void SixButtonClicked(object sender, RoutedEventArgs e)
        {
            Answer(6);
        }

        /// <summary>
        /// When the Seven button is pressed, the Answer method is invoked and the value of 7 is passed to it
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void SevenButtonClicked(object sender, RoutedEventArgs e)
        {
            Answer(7);
        }

        /// <summary>
        /// When the Eight button is pressed, the Answer method is invoked and the value of 8 is passed to it
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void EightButtonClicked(object sender, RoutedEventArgs e)
        {
            Answer(8);
        }

        /// <summary>
        /// When the Nine button is pressed, the Answer method is invoked and the value of 9 is passed to it
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void NineButtonClicked(object sender, RoutedEventArgs e)
        {
            Answer(9);
        }
    }
}
