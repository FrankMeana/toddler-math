/* 
 * File: PotatoTest.cs
 * Author: Frank Meana
 * Date: December 01, 2017
 * Description: A class that tests inheritance and polymorphism by ensuring all subclasses of Potato display their own unique image versions.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToddlerMath.Models;

namespace ToddlerMathTests
{
    /// <summary>
    /// Test class that ensures all potato sub-classes' images display correctly
    /// </summary>
    [TestClass]
    public class PotatoTest
    {
        /// <summary>
        /// A Potato object to be assigned an instance of one of each subclasses in each test
        /// </summary>
        private Potato potato;


        /// <summary>
        /// Ensures Desiree potato images displayed match the expected
        /// </summary>
        [TestMethod]
        public void Frank_Meana_DesireeContainsCorrectImages()
        {
            // assign a Desire instance to the Potato
            potato = new Desiree();

            // test expected images match actual
            Assert.AreEqual(@"/Images/desiree.png", potato.ImageSource(), "Desire image expected does not match actual");
            Assert.AreEqual(@"/Images/desiree_crossed.png", potato.CrossedImageSource(), "Desire crossed image expected does not match actual");
        }

        /// <summary>
        /// Ensures Majesty potato images displayed match the expected
        /// </summary>
        [TestMethod]
        public void Frank_Meana_MajestyContainsCorrectImages()
        {
            // assign a Majesty instance to the Potato
            potato = new Majesty();

            // test expected images match actual
            Assert.AreEqual(@"/Images/majesty.png", potato.ImageSource(), "Majesty image expected does not match actual");
            Assert.AreEqual(@"/Images/majesty_crossed.png", potato.CrossedImageSource(), "Majesty crossed image expected does not match actual");
        }

        /// <summary>
        /// Ensures Nadine potato images displayed match the expected
        /// </summary>
        [TestMethod]
        public void Frank_Meana_NadineContainsCorrectImages()
        {
            // assign a Nadine instance to the Potato
            potato = new Nadine();

            // test expected images match actual
            Assert.AreEqual(@"/Images/nadine.png", potato.ImageSource(), "Nadine image expected does not match actual");
            Assert.AreEqual(@"/Images/nadine_crossed.png", potato.CrossedImageSource(), "Nadine crossed image expected does not match actual");
        }

        /// <summary>
        /// Ensures Russet potato images displayed match the expected
        /// </summary>
        [TestMethod]
        public void Frank_Meana_RussetContainsCorrectImages()
        {
            // assign a Russet instance to the Potato
            potato = new Russet();

            // test expected images match actual
            Assert.AreEqual(@"/Images/russet.png", potato.ImageSource(), "Russet image expected does not match actual");
            Assert.AreEqual(@"/Images/russet_crossed.png", potato.CrossedImageSource(), "Russet crossed image expected does not match actual");
        }

        /// <summary>
        /// Ensures Yukon potato images displayed match the expected
        /// </summary>
        [TestMethod]
        public void Frank_Meana_YukonContainsCorrectImages()
        {
            // assign a Yukon instance to the Potato
            potato = new Yukon();

            // test expected images match actual
            Assert.AreEqual(@"/Images/yukon.png", potato.ImageSource(), "Yukon image expected does not match actual");
            Assert.AreEqual(@"/Images/yukon_crossed.png", potato.CrossedImageSource(), "Yukon crossed image expected does not match actual");
        }




    }
}
