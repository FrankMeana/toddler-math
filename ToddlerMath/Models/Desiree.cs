/* 
 * File: Desiree.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: A more specific potato type which inherits from the abstract Potato class.
 */


namespace ToddlerMath.Models
{
    /// <summary>
    /// This class represents a more specific potato type which inherits from the abstract Potato class.
    /// </summary>
    public class Desiree : Potato
    {
        /// <summary>
        /// Returns the image source of a Desiree potato in the case of addition
        /// </summary>
        /// <returns>The image source of a Desiree potato in the case of addition</returns>
        public override string ImageSource()
        {
            return @"/Images/desiree.png";
        }

        /// <summary>
        /// Returns the image source of a Desiree potato in the case of subtraction
        /// </summary>
        /// <returns>The image source of a Desiree potato in the case of subtraction</returns>
        public override string CrossedImageSource()
        {
            return @"/Images/desiree_crossed.png";
        }
    }
}
