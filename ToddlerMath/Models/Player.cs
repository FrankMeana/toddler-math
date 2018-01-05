/* 
 * File: Player.cs
 * Author: Frank Meana
 * Date: October 31, 2017
 * Description: A Player in the Toddler Math game
 */


namespace ToddlerMath.Models
{
    /// <summary>
    /// A Player in the Toddler Math game
    /// </summary>
    public class Player
    {
        /// <summary>
        /// A Player's name
        /// </summary>
        private string name;

        /// <summary>
        /// A Player's score
        /// </summary>
        private int score;

        /// <summary>
        /// The number of lives a Player has
        /// </summary>
        private int lives;


        /// <summary>
        /// A Player's name property
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// A Player's score property
        /// </summary>
        public int Score
        {
            get { return score; }
            set
            {
                if (value < 0)
                    score = 0;
                else
                    score = value;
            }
        }

        /// <summary>
        /// A Player's lives property
        /// </summary>
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        /// <summary>
        /// Constructs a Player object with the specified name and score
        /// </summary>
        /// <param name="name">The player's name</param>
        /// <param name="score">The player's score</param>
        public Player(string name, int score, int lives)
        {
            Name = name;
            Score = score;
            Lives = lives;
        }
    }
}
