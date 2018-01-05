/* 
 * File: Equation.cs
 * Author: Frank Meana
 * Date: October 20, 2017
 * Description: A class capable of representing a mathematical equation by generating two random operands and an operator.
 */

using System;

namespace ToddlerMath.Models
{
    /// <summary>
    /// An enumerator representing a mathematical Operator. Either Plus or Minus
    /// </summary>
    enum Operator
    {
        Plus, Minus
    }

    /// <summary>
    /// An Equation is composed of two random numbers and an Operator 
    /// </summary>
    public class Equation
    {
        /// <summary>
        /// The first number generated in the Equation
        /// </summary>
        private int firstNumber;

        /// <summary>
        /// The second number generated in the Equation
        /// </summary>
        private int secondNumber;

        /// <summary>
        /// The operator generated in the Equation
        /// </summary>
        private Operator op;

        /// <summary>
        /// A Random object shared by all instances of this class that will be used in order
        /// to generate random numbers and operator
        /// </summary>
        private static Random randomNumber = new Random();

        /// <summary>
        /// Read-Only Property for firstNumber field 
        /// </summary>
        public int FirstNumber
        {
            get { return firstNumber; }
        }

        /// <summary>
        /// Read-Only Property for secondNumber field 
        /// </summary>
        public int SecondNumber
        {
            get { return secondNumber; }
        }

        /// <summary>
        /// Returns this Equation's Operator as a string
        /// </summary>
        /// <returns>The string "+" if the Operator equals Plus. Otherwise returns string "-"</returns>
        public string GetOperator()
        {
            return (op.Equals(Operator.Plus) ? "+" : "-");
        }


        /// <summary>
        /// Returns a number between 1 and 9
        /// </summary>
        /// <returns>A number between 1 and 9</returns>
        private int RandomNumber()
        {
            // lower bound is inclusive, upper bound is exclusive, hence using 10
            // when I want max number to be 9
            return randomNumber.Next(1, 10);
        }


        /// <summary>
        /// Returns a random Operator. Namely, Plus or Minus
        /// </summary>
        /// <returns>A random Operator. Namely, Plus or Minus</returns>
        private Operator RandomOperator()
        {
            // generate a number between 0 and 1 and test if it equals 0
            if (randomNumber.Next(2) == 0)
            {
                return Operator.Plus;
            }

            return Operator.Minus;
        }

        /// <summary>
        /// Generates a random equation and returns its result
        /// </summary>
        /// <returns>The result of a randomly generated equation</returns>
        public int Generate()
        {
            firstNumber = RandomNumber();
            secondNumber = RandomNumber();
            int placeHolder;
            int result;

            // guarantee the result will never be greater than 9
            while ((firstNumber + secondNumber) > 9)
            {
                firstNumber = RandomNumber();
                secondNumber = RandomNumber();
            }

            // generate a random operator
            op = RandomOperator();

            // In the case of the operator generated being PLUS, add the two random numbers
            // and store the result of the addition into the result variable
            if (op.Equals(Operator.Plus))
            {
                result = firstNumber + secondNumber;
            }
            else
            {
                // ensure the first number is greater than the second in the case of subtraction
                // in order for toddlers to not have to deal with negative numbers
                if (firstNumber < secondNumber)
                {
                    // swap values such that firsValue always contains maximum value
                    placeHolder = firstNumber;
                    firstNumber = secondNumber;
                    secondNumber = placeHolder;
                }

                result = firstNumber - secondNumber;
            }

            return result;
        }

        /// <summary>
        /// Overrides ToString to return a string representing the current state of this Equation
        /// </summary>
        /// <returns>a string representing the current equation</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2} = ", firstNumber, 
                (op.Equals(Operator.Plus) ? "+" : "-"), secondNumber);
        }

    }
}
