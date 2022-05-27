// *********************************************************
// <copyright file="NotepadTest.cs" company="My Company">
// Class: Cpts321
// WinForms “Notepad” Application / Fibonacci BigInt Text Reader
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace HW3_NotepadTest
{
    using System;
    using System.Numerics;
    using HW3_Notepad;
    using NUnit.Framework;

    /// <summary>
    /// NUnit test class: NotepadTest. Test for using Fibonacci number.
    /// </summary>
    [TestFixture]
    public class NotepadTest
    {
        /// <summary>
        /// Set up.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test the first number in dictionary.
        /// </summary>
        [Test]
        public void Test_TryFibonacciNumbers()
        {
            FibonacciTextReader fibTest = new FibonacciTextReader(50);
            Assert.AreEqual(BigInteger.Parse("1"), fibTest.Fb[2]);
        }

        /// <summary>
        /// Test whether 50 numbers Fibonacci numbers are correct. Also test whether BigInteger work.
        /// </summary>
        [Test]
        public void Test_FiftyFibonacciNumbers()
        {
            FibonacciTextReader fibTest = new FibonacciTextReader(50);
            Assert.AreEqual(BigInteger.Parse("7778742049"), fibTest.Fb[50]);
        }

        /// <summary>
        /// Test whether 100 numbers Fibonacci numbers are correct.
        /// </summary>
        [Test]
        public void Test_HundradFibonacciNumbers()
        {
            FibonacciTextReader fibTest = new FibonacciTextReader(100);
            Assert.AreEqual(BigInteger.Parse("218922995834555169026"), fibTest.Fb[100]);
        }
    }
}
