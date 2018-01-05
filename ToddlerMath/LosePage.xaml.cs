/* 
 * File: LosePage.xaml.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: Contains the Interaction logic for LosePage.xaml
 */

using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ToddlerMath.Data;
using ToddlerMath.Models;

namespace ToddlerMath
{
    /// <summary>
    /// Interaction logic for LosePage.xaml
    /// </summary>
    public partial class LosePage : Page
    {
        /// <summary>
        /// The player who lost the game
        /// </summary>
        private Player player;

        /// <summary>
        /// Constructs a LosePage
        /// </summary>
        public LosePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructs a LosePage with a reference to the Player who lost
        /// Displays the message to the player about his loss with his name
        /// and inserts his/her score to the database
        /// </summary>
        /// <param name="player">The player who lost the game</param>
        public LosePage(Player player)
        {
            InitializeComponent();

            this.player = player;

            sorryLabel.Content = string.Format("Sorry {0}", player.Name);

           DatabaseHelper.connectToDatabase();
           DatabaseHelper.Insert(player.Name, player.Score);
        }

        /// <summary>
        /// When the Play Again button is pressed the program navigates to the StartPage
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void PlayAgainButtonClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }

        /// <summary>
        /// When the Highscores button is pressed, the program navigates to the HighscoresPage passing a reference to this Page to it 
        /// so that when it returns back to this page it still knows the player name and his/her stats
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void highscoresButtonClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HighscoresPage(this));
        }
    }
}
