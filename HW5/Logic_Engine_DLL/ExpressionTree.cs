// *********************************************************
// <copyright file="ExpressionTree.cs" company="My Company">
// Class: Cpts321
// ExpressionTree for get calculation.
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ExpressionTree class that implement Expression class.
    /// </summary>
    public class ExpressionTree : Expression
    {
        /// <summary>
        /// The operators.
        /// </summary>
        private OperatorNode op;

        /// <summary>
        /// The string of expression.
        /// </summary>
        private string expression;

        /// <summary>
        /// The dictionary for storing value in name.
        /// </summary>
        private Dictionary<string, double> dictionary1 = new Dictionary<string, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree" /> class.
        /// </summary>
        public ExpressionTree()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree" /> class.
        /// </summary>
        /// <param name="expression">Specific expression.</param>
        public ExpressionTree(string expression)
        {
            this.expression = expression;
            char op = new char();
            if (expression.Contains('+'))
            {
                op = expression[expression.IndexOf('+')];
            }
            else if (expression.Contains('-'))
            {
                op = expression[expression.IndexOf('-')];
            }
            else if (expression.Contains('*'))
            {
                op = expression[expression.IndexOf('*')];
            }
            else if (expression.Contains('/'))
            {
                op = expression[expression.IndexOf('/')];
            }

            this.op = Compile(this.expression, op);
        }

        /// <summary>
        /// Gets  the expression string value.
        /// </summary>
        public string Expression
        {
            get
            {
                return this.expression;
            }
        }

        /// <summary>
        /// Sets the specified variable within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName">Variable name.</param>
        /// <param name="variableValue">Variable value.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.dictionary1[variableName] = variableValue;
        }

        /// <summary>
        /// Implement this method with no parameters that evaluates the expression to a double value.
        /// </summary>
        /// <returns>The other evaluate with operators.</returns>
        public double Evaluate()
        {
            return this.Evaluate(this.op);
        }

        /// <summary>
        /// Compile for getting expression and deal with it.
        /// </summary>
        /// <param name="s">Expression string.</param>
        /// <returns>The final result.</returns>
        private static Node Compile(string s)
        {
            char[] operators = { '+', '-', '*', '/' };
            foreach (char op in operators)
            {
                Node n = Compile(s, op);
                if (n != null)
                {
                    return n;
                }
            }

            double number;
            if (double.TryParse(s, out number))
            {
                return new ConstantNode()
                {
                    Value = number
                };
            }
            else
            {
                return new VariableNode()
                {
                    Name = s
                };
            }
        }

        /// <summary>
        /// Compile the expression string with operator
        /// </summary>
        /// <param name="s">Expression string.</param>
        /// <param name="op">Operators in string.</param>
        /// <returns>Operator or null.</returns>
        private static OperatorNode Compile(string s, char op)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == op)
                {
                    OperatorNode newOp = new OperatorNode(s[i]);
                    string leftPart = s.Substring(0, i);
                    string rightPart = s.Substring(i + 1);
                    if (leftPart.Contains('+') | leftPart.Contains('-') | leftPart.Contains('*') | leftPart.Contains('/'))
                    {
                        newOp.Left = Compile(leftPart, op);
                    }
                    else
                    {
                        newOp.Left = Compile(leftPart);
                    }

                    if (rightPart.Contains('+') | rightPart.Contains('-') | rightPart.Contains('*') | rightPart.Contains('/'))
                    {
                        newOp.Right = Compile(rightPart, op);
                    }
                    else
                    {
                        newOp.Right = Compile(rightPart);
                    }

                    return newOp;
                }
            }

            return null;
        }

        /// <summary>
        /// Evaluate the things in node.
        /// </summary>
        /// <param name="node">Node in tree.</param>
        /// <returns>Node type.</returns>
        private double Evaluate(Node node)
        {
            double result = 0.0;
            ConstantNode constantNode = node as ConstantNode;
            if (constantNode != null)
            {
                return constantNode.Value;
            }

            VariableNode variableNode = node as VariableNode;
            if (variableNode != null)
            {
                return this.dictionary1[variableNode.Name];
            }

            OperatorNode operatorNode = node as OperatorNode;
            if (operatorNode != null)
            {
                switch (operatorNode.Operator)
                {
                    case '+':
                        result = this.Evaluate(operatorNode.Left) + this.Evaluate(operatorNode.Right);
                        break;
                    case '-':
                        result = this.Evaluate(operatorNode.Left) - this.Evaluate(operatorNode.Right);
                        break;
                    case '*':
                        result = this.Evaluate(operatorNode.Left) * this.Evaluate(operatorNode.Right);
                        break;
                    case '/':
                        result = this.Evaluate(operatorNode.Left) / this.Evaluate(operatorNode.Right);
                        break;
                }

                return result;
            }

            return 0;
        }
    }
}