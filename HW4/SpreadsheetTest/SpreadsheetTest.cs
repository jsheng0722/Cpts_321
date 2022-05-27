// *********************************************************
// <copyright file="SpreadsheetTest.cs" company="My Company">
// Class: Cpts321
// Spreadsheet Test
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace SpreadsheetTest
{
    using System;
    using NUnit.Framework;
    /// <summary>
    /// NUnit test class: SpreadsheetTest.
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
        /// Test whether char can use in string.
        /// </summary>
        [Test]
        public void Test_Alph()
        {
            String alph = ((char)('A' + 1)).ToString();
            Assert.AreEqual("B", alph);
        }

    }
}
