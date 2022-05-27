// *********************************************************
// <copyright file="SpreadsheetTest.cs" company="My Company">
// Class: Cpts321
// SpreadsheetTest
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace Spreadsheet_Jihui_Sheng
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// NUnit test class:SpreadsheetTest. Test for things in spreadsheet
    /// </summary>
    [TestFixture]
    class SpreadsheetTest
    {
        /// <summary>
        /// Set up.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test the whether alph work.
        /// </summary>
        [Test]
        public void Test_Alph()
        {
            String alph = ((char)('A' + 1)).ToString();
            Assert.AreEqual("B", alph);
        }

    }
}
