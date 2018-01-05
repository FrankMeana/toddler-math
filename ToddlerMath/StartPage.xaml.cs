/* 
 * File: StartPage.xaml.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: Contains the Interaction logic for StartPage.xaml
 */

using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ToddlerMath.Models;

namespace ToddlerMath
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        /// <summary>
        /// Constructs a StartPage and initializes GUI components
        /// </summary>
        public StartPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navigates to the Game page and sends a Player object to the GamePage constructor containing the player name entered by the user,
        /// a score of 0 and 3 lives
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void PlayButtonClick(object sender, RoutedEventArgs e)
        {
           
                // navigate to the Game page and send a Player object to its constructor 
                // with the name entered by the user, a score of 0 and 3 lives
                NavigationService.Navigate(new GamePage(new Player(nameTextBox.Text, 0, 3)));
        }
    }
}
