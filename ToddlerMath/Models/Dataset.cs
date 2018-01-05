/* 
 * File: Dataset.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: A basic model for the Dataset displayed in the DataGrid. Each object represents a record
 */

namespace ToddlerMath.Models
{
    /// <summary>
    /// This class is a basic model for the Dataset displayed in the DataGrid. Each object represents a record
    /// </summary>
    public class Dataset
    {
        /// <summary>
        /// Auto-implemented property for the Ref_Date of the Potato Dataset
        /// </summary>
        public string Ref_Date { get; set; }

        /// <summary>
        /// Auto-implemented property for the GEO of the Potato Dataset
        /// </summary>
        public string GEO { get; set; }

        /// <summary>
        /// Auto-implemented property for the EST of the Potato Dataset
        /// </summary>
        public string EST { get; set; }

        /// <summary>
        /// Auto-implemented property for the Vector of the Potato Dataset
        /// </summary>
        public string Vector { get; set; }

        /// <summary>
        /// Auto-implemented property for the Coordinate of the Potato Dataset
        /// </summary>
        public string Coordinate { get; set; }

        /// <summary>
        /// Auto-implemented property for the Value of the Potato Dataset
        /// </summary>
        public string Value { get; set; }
    }
}
