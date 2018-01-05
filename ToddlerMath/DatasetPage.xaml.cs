/* 
 * File: DatasetPage.xaml.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: Contains the Interaction logic for DatasetPage.xaml
 */

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ToddlerMath.Models;
using System.IO;
using System.Threading;

namespace ToddlerMath
{
    /// <summary>
    /// Interaction logic for DatasetPage.xaml
    /// </summary>
    public partial class DatasetPage : Page
    {
        /// <summary>
        /// Will hold a reference to the Page which Navigated to this Page
        /// </summary>
        private Page page;

        /// <summary>
        /// the list of Dataset objects in where each object/element it contains represents a record/row in the CSV file
        /// </summary>
        List<Dataset> secretDatasetList;

        /// <summary>
        /// Constructs a DatasetPage
        /// </summary>
        public DatasetPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructs a DatasetPage with a reference to the Page who navigated here (by calling this constructor and passing itself to it)
        /// </summary>
        /// <param name="page">The page which navigated to this page and passed a reference to itself when it called this constructor</param>
        public DatasetPage(Page page)
        {
            InitializeComponent();

            this.page = page;

            // create  background thread to read the CSV File
            Thread backgroundThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                // assign this list a reference to the list returned by invoking mehod ReadPotatoDatasetCSV()
                secretDatasetList = ReadPotatoDatasetCSV();
            });

            // start the background thread
            backgroundThread.Start();

            // make the GUI thread wait for the background thread to finish before setting the DataGrid to the contents of the secretDatasetList
            backgroundThread.Join();

            // set the ItemsSource property of the secretDataGrid to the contents of the list returned by method ReadPotatoDatasetCSV()
            secretDataGrid.ItemsSource = secretDatasetList;

        }

        /// <summary>
        /// Navigate back to the Page which called this constructor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(page);
        }

        /// <summary>
        /// Reads all the content from a CSV file. During each iteration it splits each line of the CSV into an array of strings separated by commas and sets the
        /// properties of the Dataset object to the content of the array. One of the columns gets problematic as it contains extra commas which vary in amount.
        /// For the special column EST where this occurs, a while loop is implemented checking if the next column starts with the letter "v". The reason for this
        /// is that the next column should be Vector and all its content always starts with the letter v. So the loop concatenates the next column to EST as long
        /// as it does not start with the letter v. Otherwise, Vector is set as well as the other columns as it is required. The object is added to a list. Such
        /// process repeats until the list is full when all lines of the CSV are read. The list is finally returned to the caller.
        /// </summary>
        /// <returns>A list containing Dataset objects matching the contents of a CSV file</returns>
        private List<Dataset> ReadPotatoDatasetCSV()
        {
            // a list to store DataSet objects
            List<Dataset> list = new List<Dataset>();

            // the content of a csv file split by lines
            string[] fileContent = File.ReadAllLines("00010014-eng.csv");

            // an array that will split each line of the file content array delimited by commas
            string[] line;

            // the model object that will set its state equivalent to values read in the file
            Dataset dataset;

            // a counter for a while loop (starts at 2 because that is when unwanted commas start coming out in the csv
            int counter;

            for (int i = 1; i < fileContent.Length; i++)
            {
                // each iteration creates a new DataSet object to set properties into
                dataset = new Dataset();

                // further split the current line of the file into a string[] delimited by commas
                line = fileContent[i].Split(',');

                // set the Ref_Date property of this Dataset object to the first element in line array
                dataset.Ref_Date = line[0];
                // set the GEO property of this Dataset object to the second element in line array
                dataset.GEO = line[1];
                // set the EST property of this Dataset object to the third element in line array
                dataset.EST = line[2];

                // counter starts at 3 (after EST) because that is when the random commas begin
                counter = 3;

                // ensure that any string that does NOT start with v is concatenated to the EST column value
                //(Vector should be the next column, and all vector values start with v) 
                while (!line[counter].StartsWith("v"))
                {
                    // add comma back and concatenate (ADDING COMMA IS UNDER SUPERVISION BUT I THINK IT IS WORKING)
                    dataset.EST += "," + line[counter];

                    counter++;
                }

                // line[counter] should contain the proper Vector content (always starting with "v")
                dataset.Vector = line[counter];
                // line[counter + 1] should contain the proper Coordinate content
                dataset.Coordinate = line[counter + 1];
                // line[counter + 2] should contain the proper Value content
                dataset.Value = line[counter + 2];

                // add this current Dataset object with all properties set
                list.Add(dataset);
            }

            return list;
        }


    }
}
