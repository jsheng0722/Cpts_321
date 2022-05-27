// *********************************************************
// <copyright file="Form1.cs" company="My Company">
// Class: Cpts321
// WinForms “Notepad” Application / Fibonacci BigInt Text Reader
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace HW3_Notepad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// From1 class.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Drop down item 1, which is load from file.
        /// </summary>
        /// <param name="sender">Event Sender.</param>
        /// <param name="e">Event Arguments.</param>
        public void DropDownItems1_Clicked(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.OpenFile()))
                {
                    this.LoadText(reader);
                }
            }
        }

        /// <summary>
        /// Drop down item 2, which is load 50th Fibonacci numbers.
        /// </summary>
        /// <param name="sender">Event Sender.</param>
        /// <param name="e">Event Arguments.</param>
        public void DropDownItems2_Clicked(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            FibonacciTextReader fibText = new FibonacciTextReader(50);

            for (int i = 1; i <= 50; i++)
            {
                this.textBox1.Text += i + ": " + fibText.Fb[i] + Environment.NewLine;
            }
        }

        /// <summary>
        /// Drop down item 3, which is load 100th Fibonacci numbers.
        /// </summary>
        /// <param name="sender">Event Sender.</param>
        /// <param name="e">Event Arguments.</param>
        public void DropDownItems3_Clicked(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            FibonacciTextReader fibText = new FibonacciTextReader(100);

            for (int i = 1; i <= 100; i++)
            {
                this.textBox1.Text += i + ": " + fibText.Fb[i] + Environment.NewLine;
            }
        }

        /// <summary>
        /// Drop down item 4, which is save to file.
        /// </summary>
        /// <param name="sender">Event Sender.</param>
        /// <param name="e">Event Arguments.</param>
        public void DropDownItems4_Clicked(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8);
                sw.Write(this.textBox1.Text);
                sw.Close();
            }
        }

        /// <summary>
        /// Load the text from textbox.
        /// </summary>
        /// <param name="sr"> Text Reader.</param>
        public void LoadText(TextReader sr)
        {
            this.textBox1.Text = sr.ReadToEnd();
        }
    }
}
