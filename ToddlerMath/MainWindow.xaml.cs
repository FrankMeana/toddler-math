/* 
 * File: MainWindow.xaml.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: Contains the Interaction logic for MainWindow.xaml
 */

using System.Windows;

namespace ToddlerMath
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructs a MainWindow and sets the content of its frame to the StartPage
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content = new StartPage();
        }

    }
}
