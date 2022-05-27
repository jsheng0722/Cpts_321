// *********************************************************
// Class: Expression
// CptS321_HW6
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="Expression.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// *********************************************************
namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Expression class.
    /// </summary>
    public class Expression
    {
        /// <summary>
        /// Abstract Node class.
        /// </summary>
        public abstract class Node
        {
            /// <summary>
            /// Abstract Evaluate function.
            /// </summary>
            /// <returns>Double value.</returns>
            public abstract double Evaluate();
        }

        /// <summary>
        /// Constant node that implement Node which is constant number.
        /// </summary>
        public class ConstantNode : Node
        {
            /// <summary>
            /// Private value.
            /// </summary>
            private double value;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConstantNode"/> class.
            /// </summary>
            public ConstantNode()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ConstantNode"/> class.
            /// </summary>
            /// <param name="value">Double value.</param>
            public ConstantNode(double value)
            {
                this.Value = value;
            }

            /// <summary>
            /// Gets or sets value in constant node.
            /// </summary>
            public double Value
            {
                get
                {
                    return this.value;
                }

                set
                {
                    this.value = value;
                }
            }

            /// <summary>
            /// Evaluate in Constant Node get its own.
            /// </summary>
            /// <returns>Its value.</returns>
            public override double Evaluate()
            {
                return this.Value;
            }
        }

        /// <summary>
        /// Variable node that implement node which put string in dictionary and define them with number.
        /// </summary>
        public class VariableNode : Node
        {
            /// <summary>
            /// Dictionary variables.
            /// </summary>
            private Dictionary<string, double> variables;

            /// <summary>
            /// Private name.
            /// </summary>
            private string name;

            /// <summary>
            /// Initializes a new instance of the <see cref="VariableNode"/> class.
            /// </summary>
            public VariableNode()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="VariableNode" /> class.
            /// </summary>
            /// <param name="name">Name in dictionary.</param>
            /// <param name="variables">Variables in dictionary.</param>
            public VariableNode(string name, ref Dictionary<string, double> variables)
            {
                this.Name = name;
                this.variables = variables;
            }

            /// <summary>
            /// Gets or sets name.
            /// </summary>
            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            /// <summary>
            /// Evaluate in variable node.
            /// </summary>
            /// <returns>The result value.</returns>
            public override double Evaluate()
            {
                double value = 0.0;
                if (this.variables.ContainsKey(this.Name))
                {
                    value = this.variables[this.Name];
                }

                return value;
            }
        }

        /// <summary>
        /// Operator node that implement node.
        /// </summary>
        public class OperatorNode : Node
        {
            /// <summary>
            /// The left node.
            /// </summary>
            private int precedence;

            /// <summary>
            /// The left node.
            /// </summary>
            private Node leftNode;

            /// <summary>
            /// The right node.
            /// </summary>
            private Node rightNode;

            /// <summary>
            /// The operators.
            /// </summary>
            private char op;

            /// <summary>
            /// Initializes a new instance of the <see cref="OperatorNode"/> class.
            /// </summary>
            /// <param name="c">The operator.</param>
            public OperatorNode(char c)
            {
                this.op = c;
                this.Left = this.Right = null;
                if (c == '+' | c == '-')
                {
                    this.precedence = 1;
                }
                else if (c == '*' | c == '/')
                {
                    this.precedence = 2;
                }
                else
                {
                    this.precedence = -1;
                }
            }

            /// <summary>
            /// Gets public precedence.
            /// </summary>
            public int Precedence
            {
                get
                {
                    return this.precedence;
                }
            }

            /// <summary>
            /// Gets operator.
            /// </summary>
            public char Operator
            {
                get
                {
                    return this.op;
                }
            }

            /// <summary>
            /// Gets or sets left child.
            /// </summary>
            public Node Left
            {
                get
                {
                    return this.leftNode;
                }

                set
                {
                    this.leftNode = value;
                }
            }

            /// <summary>
            /// Gets or sets right child.
            /// </summary>
            public Node Right
            {
                get
                {
                    return this.rightNode;
                }

                set
                {
                    this.rightNode = value;
                }
            }

            /// <summary>
            /// Evaluate function get operators.
            /// </summary>
            /// <returns>The operators.</returns>
            public override double Evaluate()
            {
                return this.op;
            }
        }
    }
}
