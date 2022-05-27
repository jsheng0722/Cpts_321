// *********************************************************
// Class: ExpressionTree
// CptS321_HW6
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ExpressionTree class.
    /// </summary>
    public class ExpressionTree : Expression
    {
        /// <summary>
        /// The operators.
        /// </summary>
        private Node op;

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
            char op = default(char);
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

            this.op = this.Build(this.expression);
        }

        /// <summary>
        /// Gets or sets the expression string value.
        /// </summary>
        public string Expression
        {
            get
            {
                return this.expression;
            }

            set
            {
                this.expression = value;
                this.op = this.Build(this.expression);
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
        /// Sets the specified variable within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName">Variable name.</param>
        /// <returns>Double value.</returns>
        public double GetVariable(string variableName)
        {
            double variableValue = 0.0;
            if (this.dictionary1.TryGetValue(variableName, out variableValue))
            {
                return this.dictionary1[variableName];
            }
            else
            {
                throw new Exception("Value not in dictionary.");
            }
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
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            if (s[0] == '(')
            {
                int parenthesisCounter = 1;
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] == '(')
                    {
                        parenthesisCounter++;
                    }
                    else if (s[i] == ')')
                    {
                        parenthesisCounter--;
                        if (parenthesisCounter == 0)
                        {
                            if (i != s.Length - 1)
                            {
                                break;
                            }
                            else
                            {
                                return Compile(s.Substring(1, s.Length - 2));
                            }
                        }
                    }
                }
            }

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
                    Value = number,
                };
            }
            else
            {
                return new VariableNode()
                {
                    Name = s,
                };
            }
        }

        /// <summary>
        /// Compile the expression string with operator.
        /// </summary>
        /// <param name="s">Expression string.</param>
        /// <param name="op">Operators in string.</param>
        /// <returns>Operator or null.</returns>
        private static OperatorNode Compile(string s, char op)
        {
            int parenthesisCounter = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ')')
                {
                    parenthesisCounter++;
                }
                else if (s[i] == '(')
                {
                    parenthesisCounter--;
                }

                if (s[i] == op && parenthesisCounter == 0)
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

            if (parenthesisCounter != 0)
            {
                throw new Exception("The parenthesisCounter is asymmetry");
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
                        if (this.Evaluate(operatorNode.Right) != 0)
                        {
                            result = this.Evaluate(operatorNode.Left) / this.Evaluate(operatorNode.Right);
                        }
                        else
                        {
                            new Exception("The denominator cannot be zero.");
                        }

                        break;
                    default:
                        throw new NotSupportedException("Operator " + this.op.ToString() + "is not support.");
                }

                return result;
            }

            return 0;
        }

        /// <summary>
        /// Postfix expression.
        /// </summary>
        /// <param name="s"> String of expression.</param>
        /// <returns> The expression in list.</returns>
        private List<string> Postfix(string s)
        {
            List<string> postfixString = new List<string>();
            Stack<char> operatorStack = new Stack<char>();
            int operandStart = -1;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (this.IsOperator(c) || this.IsParenthesis(c))
                {
                    if (operandStart != -1)
                    {
                        postfixString.Add(s.Substring(operandStart, i - operandStart));
                        operandStart = -1;
                    }

                    if (c == '(')
                    {
                        operatorStack.Push(c);
                    }
                    else if (c == ')')
                    {
                        char operatorInStack = operatorStack.Pop();
                        while (operatorInStack != '(')
                        {
                            postfixString.Add(operatorInStack.ToString());
                            operatorInStack = operatorStack.Pop();
                        }
                    }
                    else
                    {
                        while (operatorStack.Count > 0 && this.GetPrecedence(c) <= this.GetPrecedence(operatorStack.Peek()))
                        {
                            postfixString.Add(operatorStack.Pop().ToString());
                        }

                        operatorStack.Push(c);
                    }
                }
                else if (operandStart == -1)
                {
                    operandStart = i;
                }
            }

            if (operandStart != -1)
            {
                postfixString.Add(s.Substring(operandStart, s.Length - operandStart));
                operandStart = -1;
            }

            while (operatorStack.Count > 0)
            {
                postfixString.Add(operatorStack.Pop().ToString());
            }

            return postfixString;
        }

        /// <summary>
        /// Judge whether operator exists.
        /// </summary>
        /// <param name="c"> The operators.</param>
        /// <returns>Operator exists then true, else false.</returns>
        private bool IsOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/')
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Judge whether parenthesis exists.
        /// </summary>
        /// <param name="c">The string expression.</param>
        /// <returns>Parenthesis exists then true, else false.</returns>
        private bool IsParenthesis(char c)
        {
            if (c == '(' || c == ')')
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the precedence of operators.
        /// </summary>
        /// <param name="c"> The operator.</param>
        /// <returns>The precedence of operator.</returns>
        private int GetPrecedence(char c)
        {
            if (c == '+' | c == '-')
            {
                return 1;
            }
            else if (c == '*' | c == '/')
            {
                return 2;
            }

            return -1;
        }

        /// <summary>
        /// Use OperatorNodeFactory to get the result of expression calculation.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <returns> Result of calculation.</returns>
        private Node Build(string s)
        {
            Stack<Node> operatorNode = new Stack<Node>();
            List<string> postfixString = this.Postfix(s);
            foreach (var item in postfixString)
            {
                if (item.Length == 1 && this.IsOperator(item[0]))
                {
                    switch (item[0])
                    {
                        case '+':
                            OperatorNodeFactory.Add add = new OperatorNodeFactory.Add();
                            add.Right = operatorNode.Pop();
                            add.Left = operatorNode.Pop();
                            operatorNode.Push(add);
                            break;
                        case '-':
                            OperatorNodeFactory.Minus minus = new OperatorNodeFactory.Minus();
                            minus.Right = operatorNode.Pop();
                            minus.Left = operatorNode.Pop();
                            operatorNode.Push(minus);
                            break;
                        case '*':
                            OperatorNodeFactory.Multiple multiple = new OperatorNodeFactory.Multiple();
                            multiple.Right = operatorNode.Pop();
                            multiple.Left = operatorNode.Pop();
                            operatorNode.Push(multiple);
                            break;
                        case '/':
                            OperatorNodeFactory.Divide divide = new OperatorNodeFactory.Divide();
                            divide.Right = operatorNode.Pop();
                            divide.Left = operatorNode.Pop();
                            operatorNode.Push(divide);
                            break;
                        default:
                            new Exception("No such operator");
                            break;
                    }
                }
                else
                {
                    double number = 0.0;
                    if (double.TryParse(item, out number))
                    {
                        operatorNode.Push(new ConstantNode(number));
                    }
                    else
                    {
                        operatorNode.Push(new VariableNode(item, ref this.dictionary1));
                    }
                }
            }

            return operatorNode.Pop();
        }
    }
}
