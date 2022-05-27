// *********************************************************
// Class: Program
// CptS321_HW6
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// *********************************************************
namespace CptS321_HW6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using CptS321;

    /// <summary>
    /// Program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main for run program.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            ExpressionTree expressionTree = new ExpressionTree("\"A1-12-C1\"");
            string userInput;
            bool consoleEnd = false;
            while (consoleEnd != true)
            {
                Console.WriteLine("Menu (current expression=)" + expressionTree.Expression);
                Console.WriteLine("  1 = Enter a new expression");
                Console.WriteLine("  2 = Set a variable value");
                Console.WriteLine("  3 = Evaluate tree");
                Console.WriteLine("  4 = Quit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Write("Enter new expression: ");
                        string inputExpression = Console.ReadLine();
                        expressionTree = new ExpressionTree(inputExpression);
                        continue;
                    case "2":
                        Console.Write("Enter variable name: ");
                        string inputName = Console.ReadLine();
                        Console.Write("Enter variable value: ");
                        string inputValue = Console.ReadLine();
                        expressionTree.SetVariable(inputName, Convert.ToDouble(inputValue));
                        continue;
                    case "3":
                        Console.WriteLine(expressionTree.Evaluate());
                        continue;
                    case "4":
                        Console.WriteLine("Done");
                        consoleEnd = true;
                        break;
                    default:
                        Console.WriteLine("Wrong enter, please enter the number from 1 to 4.");
                        Console.WriteLine("-------------------------------------------------");
                        continue;
                }
            }
        }
    }
}