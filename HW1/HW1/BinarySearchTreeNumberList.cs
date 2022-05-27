// *********************************************************
// <copyright file="BinarySearchTreeNumberList.cs" company="My Company">
// Class: Cpts321
// Hw1: BST Number List in Console/Terminal
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace BSTnumberList
{
    using System;

    /// <summary>
    /// This class include whole program.
    /// </summary>
    public class BinarySearchTreeNumberList
    {
        /// <summary>
        /// The Tree node class.
        /// </summary>
        public class TreeNode
        {
            /// <summary>
            /// Gets or sets the value in the node.
            /// </summary>
            public int Data;

            /// <summary>
            /// Gets or sets the left node.
            /// </summary>
            public TreeNode Left;

            /// <summary>
            /// Gets or sets the right node.
            /// </summary>
            public TreeNode Right;

            /// <summary>
            /// Initializes a new instance of the <see cref="TreeNode"/> class.
            /// </summary>
            /// <param name="data"> The value put into tree.</param>
            public TreeNode(int data)
            {
                this.Data = data;
                this.Left = null;
                this.Right = null;
            }
        }

        /// <summary>
        /// Class for create tree, add and display the elements in tree.
        /// </summary>
        public class Tree
        {
            /// <summary>
            /// Gets or sets peek node.
            /// </summary>
            public TreeNode Root;

            /// <summary>
            /// Count the number of nodes in tree.
            /// </summary>
            public int NumberOfNodes;

            /// <summary>
            /// Count the number of tree levels.
            /// </summary>
            public int NumberOfLevels;

            /// <summary>
            /// Initializes a new instance of the <see cref="Tree"/> class.
            /// </summary>
            public Tree()
            {
                this.Root = null;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Tree"/> class.
            /// </summary>
            /// <param name="root"> initialize tree with peek value.</param>
            public Tree(int root)
            {
                TreeNode newRoot = new TreeNode(root);
            }

            /// <summary>
            /// Add each node to tree. smaller left, bigger right. Except same value.
            /// </summary>
            /// <param name="value"> value add to tree.</param>
            public void AddToTreeInOrder(int value)
            {
                // Create newNode.
                TreeNode newNode = new TreeNode(value);
                if (this.Root == null)
                {
                    // If tree is empty, add node and return.
                    this.Root = newNode;
                    return;
                }
                else
                {
                    // If tree already have node, compare and add new node.
                    TreeNode parent;
                    TreeNode current;
                    current = this.Root;
                    while (true)
                    {
                        ////There's value can add in
                        parent = current;
                        if (newNode.Data < current.Data)
                        {
                            current = current.Left;
                            if (current == null)
                            {
                                parent.Left = newNode;
                                break;
                            }
                        }
                        else if (newNode.Data > current.Data)
                        {
                            current = current.Right;
                            if (current == null)
                            {
                                parent.Right = newNode;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            /// <summary>
            /// Display the values in tree from small to big.
            /// Also count the number of nodes.
            /// </summary>
            /// <param name="node"> Tree node.</param>
            public void DisplayTreeInOrder(TreeNode node)
            {
                if (node != null)
                {
                    this.DisplayTreeInOrder(node.Left);
                    Console.Write(node.Data);
                    Console.Write("  ");
                    this.DisplayTreeInOrder(node.Right);
                    this.NumberOfNodes++;
                }
            }

            /// <summary>
            /// Count the level of tree.
            /// </summary>
            /// <param name="node"> Tree node.</param>
            /// <returns>
            /// An int value which is the level of tree.</returns>
            public int GetLevelsOfTree(TreeNode node)
            {
                int result = 0;
                if (node != null)
                {
                    result = Math.Max(this.GetLevelsOfTree(node.Left), this.GetLevelsOfTree(node.Right)) + 1;
                }

                return result;
            }

            /// <summary>
            /// Get the minimum lever of tree.
            /// </summary>
            /// <returns>
            /// An int value which is the number of nodes in tree.</returns>
            public int GetMinLeversOfTree()
            {
                int result = Convert.ToInt32(Math.Ceiling(Math.Log(this.NumberOfNodes, Math.E))) + 1;
                return result;
            }
        }

        /// <summary>
        /// User input interface.
        /// </summary>
        /// <param name="args"> args.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a collection of numbers in the range [0,100], separated by spaces: ");

            // Get the user input
            string userInput = Console.ReadLine();

            //// Separate input into array
            string[] userInputArray = userInput.Split(' ');

            // Create empty tree
            Tree binarySearchTree = new Tree();
            for (int i = 0; i <= userInputArray.Length - 1; i++)
            {
                // Add each value to tree
                binarySearchTree.AddToTreeInOrder(int.Parse(userInputArray[i]));
            }
            //// Get the result as follow
            Console.Write("Tree contents: ");
            binarySearchTree.DisplayTreeInOrder(binarySearchTree.Root);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Tree statistics: ");
            Console.WriteLine("  Number of nodes " + binarySearchTree.NumberOfNodes);
            binarySearchTree.NumberOfLevels = binarySearchTree.GetLevelsOfTree(binarySearchTree.Root);
            Console.WriteLine("  Number of levels: " + binarySearchTree.NumberOfLevels);
            Console.WriteLine("  Minimum number of levels that a tree with " + binarySearchTree.NumberOfNodes + " nodes could have = " + binarySearchTree.GetMinLeversOfTree());
            Console.WriteLine("Done");
        }
    }
}