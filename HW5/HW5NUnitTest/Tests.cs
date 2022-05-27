// *********************************************************
// <copyright file="Tests.cs" company="My Company">
// Class: Cpts321
// NUnit test for testing.
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace HW5NUnitTest
{
    using CptS321;
    using NUnit.Framework;

    /// <summary>
    /// Test class for testing expression.
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Set up.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test tree one minus.
        /// </summary>
        [Test]
        public void TestTree1()
        {
            ExpressionTree expressionTree = new ExpressionTree("Hello-12-World");
            expressionTree.SetVariable("Hello", 42);
            expressionTree.SetVariable("World", 20);
            Assert.AreEqual(10.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Test tree two add.
        /// </summary>
        [Test]
        public void TestTree2()
        {
            ExpressionTree expressionTree = new ExpressionTree("A+B+C1+Hello+6");
            expressionTree.SetVariable("A", 1);
            expressionTree.SetVariable("B", 2);
            expressionTree.SetVariable("C1", 3);
            expressionTree.SetVariable("Hello", 4);
            Assert.AreEqual(16.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Test tree three multiple.
        /// </summary>
        [Test]
        public void TestTree3()
        {
            ExpressionTree expressionTree = new ExpressionTree("2*3*World");
            expressionTree.SetVariable("World", 10);
            Assert.AreEqual(60.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Test tree four divide.
        /// </summary>
        [Test]
        public void TestTree4()
        {
            ExpressionTree expressionTree = new ExpressionTree("Documents/folder/CptS321");
            expressionTree.SetVariable("Documents", 42);
            expressionTree.SetVariable("folder", 2);
            expressionTree.SetVariable("CptS321", 7);
            Assert.AreEqual(3.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Test tree five wrong expression.
        /// </summary>
        [Test]
        public void TestTree5()
        {
            ExpressionTree expressionTree = new ExpressionTree("X+Y-Z");
            expressionTree.SetVariable("X", 12);
            expressionTree.SetVariable("Y", 20);
            expressionTree.SetVariable("Z", 10);
            Assert.AreEqual(22.0, expressionTree.Evaluate());
        }
    }
}