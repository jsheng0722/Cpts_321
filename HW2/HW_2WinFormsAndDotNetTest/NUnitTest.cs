// *********************************************************
// <copyright file="NUnitTest.cs" company="My Company">
// Class: Cpts321
// Hw2: WinFormsAndDotNetTest
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace HW_2WinFormsAndDotNetTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using HW_2WinFormsAndDotNetTest;
    using NUnit.Framework;

    /// <summary>
    /// NUnit Test class.
    /// </summary>
    [TestFixture]
    public class NUnitTest
    {
        /// <summary>
        /// Set up to test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test first approach.
        /// </summary>
        [Test]
        public void Test_FirstApproach()
        {
            List<int> numberList = new List<int>() { 1, 2, 2, 3, 4, 5, 4 };
            HashSet<int> hashSet = new HashSet<int>(numberList);
            Assert.AreEqual(5, hashSet.Count());
        }

        /// <summary>
        /// Test second approach.
        /// </summary>
        [Test]
        public void Test_SecondApproach()
        {
            List<int> numberList = new List<int>() { 2, 3, 4, 3, 2, 1 };
            numberList.Sort();
            Assert.AreEqual(4, numberList.Distinct().Count());
        }

        /// <summary>
        /// Test third approach.
        /// </summary>
        [Test]
        public void Test_ThirdApproach()
        {
            List<int> numberList = new List<int>() { 10, 9, 2, 4, 2, 3, 1 };
            Assert.AreEqual(6, (from x in numberList select x).Distinct().Count());
        }
    }
}
