/* 
 * File: WinPage.xaml.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: Contains the Interaction logic for WinPage.xaml
 */

using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ToddlerMath.Models;
using ToddlerMath.Data;

namespace ToddlerMath
{
    /// <summary>
    /// Interaction logic for WinPage.xaml
    /// </summary>
    public partial class WinPage : Page
    {
        /// <summary>
        /// The player who won the game
        /// </summary>
        private Player player;

        /// <summary>
        /// Constructs a WinPage and initializes GUI components
        /// </summary>
        public WinPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructs a WinPage with a reference to the Player who won the game
        /// Sets a label to congratulate the player by his/her name
        /// Stores the player's name and score into the database
        /// </summary>
        /// <param name="player"></param>
        public WinPage(Player player)
        {
            InitializeComponent();

            this.player = player;

            congratsLabel.Content = string.Format("Congrats {0}", player.Name);

            DatabaseHelper.connectToDatabase();
            DatabaseHelper.Insert(player.Name, player.Score);
        }

        /// <summary>
        /// The Play again button sends the player to a new StartPage in order to begin a brand new game
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void PlayAgainButtonClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }

        /// <summary>
        /// The Highscores button sends the player to the HighscoresPage along with a reference to this page, so when the player decides to come back here, 
        /// by pressing the back button of the HighscoresPage, his/her name is still remembered
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void HighscoresButtonClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HighscoresPage(this));
        }

        /// <summary>
        /// The Secret Dataset button leads the player to navigate to a DatasetPage sending a reference to this page, sowhen the player decides to come back here,
        /// by pressing the back button of the DatasetPage, his/her name is still remembered
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void DatasetButtonClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DatasetPage(this));
        }
    }
}
