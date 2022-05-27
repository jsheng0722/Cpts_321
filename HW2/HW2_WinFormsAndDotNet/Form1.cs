// *********************************************************
// <copyright file="Form1.cs" company="My Company">
// Class: Cpts321
// Hw2: WinFormsAndDotNet
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace HW2_WinFormsAndDotNet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The form class.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the Form1 class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The load method in the events.
        /// </summary>
        /// <param name="sender"> Provides a reference to the object that raised the event.</param>
        /// <param name="e"> Passes an object specific to the event that is being handled.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the Title of the form.
            this.Text = "Jihui.Sheng #11539324";

            // Create an instance of a TextBox control.
            TextBox textBox1 = new TextBox();

            // Set the Multiline property to true.
            textBox1.Multiline = true;

            // Add vertical scroll bars to the TextBox control.
            textBox1.Dock = DockStyle.Fill;

            // The number that are random in the List.
            int numbersInList;

            // Create random.
            Random rand = new Random();

            // Create the list store the number.
            List<int> numberList = new List<int>();

            // Use the random class to create a list with 10,000 random integers in the range [0, 20,000].
            for (int i = 0; i < 10000; i++)
            {
                // Random number in range [0, 20,000] should be rand.Next(0, 20001).
                numbersInList = rand.Next(0, 20001);

                // Add random number into numberList. If Count is less than Capacity, this method is an O(1) operation.
                numberList.Add(numbersInList);
            }

            // First approach: HashSet.
            HashSet<int> hashSet1 = new HashSet<int>(numberList);

            int firstA = hashSet1.Count();

            //// Second approach: list.sort().
            numberList.Sort();
            int secondA = numberList.Distinct().Count();

            // Third approach: (from x in numberList select x).
            int thirdA = (from x in numberList select x).Distinct().Count();

            // Set the text of the control.
            textBox1.Text = "1. HashSet method: " + firstA.ToString() + " unique numbers" + Environment.NewLine;
            textBox1.Text += "The time complexity that Add numbers to list need O(n). " +
                                "The time complexity that Hashset need is O(n)" +
                                "When use sort() function sort numbers, because the number in list is too large, so it use quick sort method," +
                                " which the average time complexity and best time complexity is O(nlogn) and worst time complexity is O(n^2), " +
                                "So the total average time complexity is O(n + n + nlogn) = O(nlogn)," +
                                " the total best average time complexity using list.sort() is also O(nlogn)" +
                                " and total worst average time complexity is O(n + n + n^2) = O(n^2)" + Environment.NewLine;
            textBox1.Text += "2. O(1) storage method: " + secondA.ToString() + " unique numbers" + Environment.NewLine;
            textBox1.Text += "3. Sorted method: " + firstA.ToString() + " unique numbers" + Environment.NewLine;

            // Add control.
            this.Controls.Add(textBox1);
        }
    }
}
