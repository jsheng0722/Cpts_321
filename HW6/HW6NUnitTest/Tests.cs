// *********************************************************
// Class: Cpts321
// NUnit test for testing.
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
        /// Test add.
        /// </summary>
        [Test]
        public void TestAdd()
        {
            OperatorNodeFactory.Add add = new OperatorNodeFactory.Add();
            add.Right = new Expression.ConstantNode(1);
            add.Left = new Expression.ConstantNode(2);
            Assert.AreEqual(3.0, add.Evaluate());
        }

        /// <summary>
        /// Test minus.
        /// </summary>
        [Test]
        public void TestMinus()
        {
            OperatorNodeFactory.Minus minus = new OperatorNodeFactory.Minus();
            minus.Right = new Expression.ConstantNode(2);
            minus.Left = new Expression.ConstantNode(1);
            Assert.AreEqual(-1.0, minus.Evaluate());
        }

        /// <summary>
        /// Test multiple.
        /// </summary>
        [Test]
        public void TestMultiple()
        {
            OperatorNodeFactory.Multiple multiple = new OperatorNodeFactory.Multiple();
            multiple.Right = new Expression.ConstantNode(2);
            multiple.Left = new Expression.ConstantNode(3);
            Assert.AreEqual(6.0, multiple.Evaluate());
        }

        /// <summary>
        /// Test divide.
        /// </summary>
        [Test]
        public void TestDivide()
        {
            OperatorNodeFactory.Divide divide = new OperatorNodeFactory.Divide();
            divide.Right = new Expression.ConstantNode(2);
            divide.Left = new Expression.ConstantNode(1);
            Assert.AreEqual(0.5, divide.Evaluate());
        }

        /// <summary>
        /// Test parentheses.
        /// </summary>
        [Test]
        public void TestParentheses()
        {
            ExpressionTree expressionTree = new ExpressionTree("(1+2)*3");
            Assert.AreEqual(9.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Test tree minus.
        /// </summary>
        [Test]
        public void TestTreeMinus()
        {
            ExpressionTree expressionTree = new ExpressionTree("Hello-12-World");
            expressionTree.SetVariable("Hello", 42);
            expressionTree.SetVariable("World", 20);
            Assert.AreEqual(10.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Test tree add.
        /// </summary>
        [Test]
        public void TestTreeAdd()
        {
            ExpressionTree expressionTree = new ExpressionTree("A+B+C1+Hello+6");
            expressionTree.SetVariable("A", 1);
            expressionTree.SetVariable("B", 2);
            expressionTree.SetVariable("C1", 3);
            expressionTree.SetVariable("Hello", 4);
            Assert.AreEqual(16.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Test tree multiple.
        /// </summary>
        [Test]
        public void TestTreeMultiple()
        {
            ExpressionTree expressionTree = new ExpressionTree("2*3*World");
            expressionTree.SetVariable("World", 10);
            Assert.AreEqual(60.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Test tree divide.
        /// </summary>
        [Test]
        public void TestTreeDivide()
        {
            ExpressionTree expressionTree = new ExpressionTree("Documents/folder/CptS321");
            expressionTree.SetVariable("Documents", 42);
            expressionTree.SetVariable("folder", 2);
            expressionTree.SetVariable("CptS321", 7);
            Assert.AreEqual(3.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Test tree wrong expression.
        /// </summary>
        [Test]
        public void TestTreeWrongExpression()
        {
            ExpressionTree expressionTree = new ExpressionTree("X+Y-Z");
            expressionTree.SetVariable("X", 12);
            expressionTree.SetVariable("Y", 20);
            expressionTree.SetVariable("Z", 10);
            Assert.AreEqual(22.0, expressionTree.Evaluate());
        }
    }
}
