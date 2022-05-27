// *********************************************************
// <copyright file="Program.cs" company="My Company">
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
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 winForm = new Form1();
            Application.Run(winForm);
        }
    }
}
