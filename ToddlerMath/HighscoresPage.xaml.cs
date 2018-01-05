/* 
 * File: HighscoresPage.xaml.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: Contains the Interaction logic for HighscoresPage.xaml
 */

using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ToddlerMath.Data;

namespace ToddlerMath
{
    /// <summary>
    /// Interaction logic for HighscoresPage.xaml
    /// </summary>
    public partial class HighscoresPage : Page
    {
        /// <summary>
        /// A reference to the Page that invoked us
        /// </summary>
        private Page page;

        /// <summary>
        /// Constructs a HighscoresPage
        /// </summary>
        public HighscoresPage()
        {
            InitializeComponent();
            DatabaseHelper.DisplayHighScores(highScoresDataGrid);
        }

        /// <summary>
        /// Constructs a HighscoresPage with a reference to the Page that invoked this page in order to be able to go back to
        /// the old page and have the name of the player and his scored still in memory
        /// </summary>
        /// <param name="page">The page that invoked this page</param>
        public HighscoresPage(Page page)
        {
            InitializeComponent();

            // assign the page field a reference to the page that invoked this page
            this.page = page;

            // use the DatabaseHelper to call the method that displays the scores to the DataGrid GUI component and pass in our highScoresDataGrid id 
            // defined in the xaml file associated with this one
            DatabaseHelper.DisplayHighScores(highScoresDataGrid);
        }

        /// <summary>
        /// Navigate back to the Page that invoked this page when the back button is clicked
        /// </summary>
        /// <param name="sender">The control (button in this case) that was clicked</param>
        /// <param name="e">Contains state information and event data associated with a routed event</param>
        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(page);
        }
    }
}
