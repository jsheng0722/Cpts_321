// *********************************************************
// <copyright file="Program.cs" company="My Company">
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
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Program class.
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
            Application.Run(new Form1());
        }
    }
}
