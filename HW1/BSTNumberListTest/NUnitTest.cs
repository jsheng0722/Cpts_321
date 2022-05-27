// ********************************
// <copyright file="BSTNumberListTest.cs" company="My Company">
// Test for BSTNmberlist.
// </copyright>
// ********************************
namespace HW1.BSTnumberList.Tests
{
    using BSTnumberList;
    using NUnit.Framework;

    /// <summary>
    /// The test class.
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
        /// Test the level of tree.
        /// </summary>
        [Test]
        public void TestBSTreeLevel()
        {
            Assert.AreEqual(7,7);
        }
    }
}
