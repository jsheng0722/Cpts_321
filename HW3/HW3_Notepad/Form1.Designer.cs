// *********************************************************
// <copyright file="Form1.Designer.cs" company="My Company">
// Class: Cpts321
// WinForms “Notepad” Application / Fibonacci BigInt Text Reader
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace HW3_Notepad
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Form1 class: Show the property in form windows.
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// TextBox for writing text on win form.
        /// </summary>
        private TextBox textBox1;

        /// <summary>
        /// MenuStrip which locate at top and has tool strip menu item.
        /// </summary>
        private MenuStrip menustrip1;

        /// <summary>
        /// ToolStripMenuItem that has several options to choose.
        /// </summary>
        private ToolStripMenuItem toolStripMenuItem;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> True if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menustrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menustrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.ScrollBars = ScrollBars.Both;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 24);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(600, 342);
            this.textBox1.TabIndex = 0;
            // 
            // menustrip1
            // 
            this.toolStripMenuItem.Text = "File";
            ToolStripItem item1 = this.toolStripMenuItem.DropDownItems.Add("Load from file...");
            item1.Click += new EventHandler(DropDownItems1_Clicked);
            ToolStripItem item2 = this.toolStripMenuItem.DropDownItems.Add("Load Fibonacci numbers(first 50)");
            item2.Click += new EventHandler(DropDownItems2_Clicked);
            ToolStripItem item3 = this.toolStripMenuItem.DropDownItems.Add("Load Fibonacci numbers(first 100)");
            item3.Click += new EventHandler(DropDownItems3_Clicked);
            this.toolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            ToolStripItem item4 = this.toolStripMenuItem.DropDownItems.Add("Save to file...");
            item4.Click += new EventHandler(DropDownItems4_Clicked);
            this.menustrip1.Items.Add(toolStripMenuItem);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menustrip1);
            this.MainMenuStrip = this.menustrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "321 Notepad";
            this.Text = "321 Notepad";
            this.menustrip1.ResumeLayout(false);
            this.menustrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}