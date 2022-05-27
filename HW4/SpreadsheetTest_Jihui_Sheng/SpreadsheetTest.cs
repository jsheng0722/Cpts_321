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
    using CptS321;
    using NUnit.Framework;
    using SpreadsheetEngine;

    /// <summary>
    /// NUnit test class: SpreadsheetTest.
    /// </summary>
    [TestFixture]
    public class SpreadsheetTest
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
            string alph = ((char)('A' + 1)).ToString();
            Assert.AreEqual("B", alph);
        }

        /// <summary>
        /// Test row index
        /// </summary>
        [Test]
        public void Test_RowIndex()
        {
            Cell[,] cell = new Cell[1, 2];
            Assert.AreEqual("B", cell[1, 2].RowIndex);
        }

        /// <summary>
        /// Test col index
        /// </summary>
        [Test]
        public void Test_ColIndex()
        {
            Cell[,] cell = new Cell[1, 2];
            Assert.AreEqual("B", cell[1, 2].ColumnIndex);
        }
    }
}
