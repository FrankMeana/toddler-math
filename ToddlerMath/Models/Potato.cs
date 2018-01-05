/* 
 * File: Potato.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: A base class representing a potato. It is designed to be subclassed by more specific potato types
 */

using System;

namespace ToddlerMath.Models
{
    /// <summary>
    /// A base class representing a potato. It is designed to be subclassed by more specific potato types
    /// </summary>
    public abstract class Potato
    {
        /// <summary>
        /// A static Random object for generating different kinds of potatoes
        /// </summary>
        private static Random randomNumber = new Random();

        /// <summary>
        /// Returns the source of the image corresponding to this Potato object
        /// </summary>
        /// <returns>A string representing the source of the image corresponding to this Potato object</returns>
        public abstract string ImageSource();

        /// <summary>
        /// Returns the source of the crossed image corresponding to this Potato object
        /// </summary>
        /// <returns>A string representing the source of the crossed image corresponding to this Potato object</returns>
        public abstract string CrossedImageSource();

        /// <summary>
        /// Generates a random Potato child object
        /// </summary>
        /// <returns>An random instance of one of the subclasses of Potato</returns>
        public static Potato Generate()
        {
            // generates a random number from 1 - 5 (lower bound is inclusive, upper bound is exclusive)
            int number = randomNumber.Next(1, 6);

            switch (number)
            {
                case 1:
                    return new Desiree();

                case 2:
                    return new Majesty();

                case 3:
                    return new Nadine();

                case 4:
                    return new Russet();

                case 5:
                    return new Yukon();
            }

            return null;
        }
    }
}
