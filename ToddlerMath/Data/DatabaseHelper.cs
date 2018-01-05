/* 
 * File: DatabaseHelper.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: A class that helps to connect, query and insert into our database. All the database logic will be here.
 * Tutorial used can be found at: http://blog.tigrangasparian.com/2012/02/09/getting-started-with-sqlite-in-c-part-one/
 */

using System.Data.SQLite;
using System.Data;
using System.Windows.Controls;

namespace ToddlerMath.Data
{
    /// <summary>
    /// A class that helps to connect, query and insert into our database. All the database logic will be here.
    /// </summary>
    class DatabaseHelper
    {
        /// <summary>
        /// Connects to the database. A connection object is needed every time you interact with the database
        /// </summary>
        private static SQLiteConnection connection;

       
        /// <summary>
        /// Creates a new database file with the specified name
        /// </summary>
        public static void createNewDatabase()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
        }

        /// <summary>
        /// Creates a connection with our database file and nitializes the connection with the specified connection string
        /// Then opens the connection
        /// </summary>
        public static void connectToDatabase()
        {
            connection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            connection.Open();
        }

        /// <summary>
        /// Creates a table named 'highscores' with two columns: name (a string of max 50 characters) and score (an int)
        /// </summary>
        public static void createTable()
        {
            // string containing the query
            string sql = "CREATE TABLE IF NOT EXISTS Highscores " +
                "(Name VARCHAR(50), " +
                "Score INT)";

            // Create an SQLite command by entering the sql query along with the connection object
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // execute the command
            command.ExecuteNonQuery();
            
        }

        /// <summary>
        /// Insterts the specified player name and player score into the highscores table
        /// </summary>
        /// <param name="playerName">The name of the player to insert into the highscores table</param>
        /// <param name="playerScore">The score of the player to insert into the highscores table</param>
        public static void Insert(string playerName, int playerScore)
        {
            string sql = string.Format("insert into Highscores (Name, Score) values ('{0}', {1})", playerName, playerScore);
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        
        /// <summary>
        /// Displays Highscores into a DataGrid control sorted in decending order with a limit of 7 maximum
        /// </summary>
        /// <param name="dataGrid">The Datagrid where the scores will be displayed (A GUI based class will call this method and pass its own DataGrid object into it)</param>
        public static void DisplayHighScores(DataGrid dataGrid)
        {
            string sql = "select * from highscores order by score desc limit 7";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            command.ExecuteNonQuery();

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

            // provide the name of the table in the database
            DataTable dataTable = new DataTable("Highscores");

            // fill the adapter with the DataTable info
            dataAdapter.Fill(dataTable);

            dataGrid.ItemsSource = dataTable.DefaultView;

            dataAdapter.Update(dataTable);
        }
    }
}
