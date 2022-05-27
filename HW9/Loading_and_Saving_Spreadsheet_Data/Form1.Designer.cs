// *********************************************************
// Class: Cpts321
// Loading_and_Saving_Spreadsheet_Data Form
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="Form1.Designer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// *********************************************************
namespace Loading_and_Saving_Spreadsheet_Data
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Partial class form1.
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// MenuStrip which locate at top and has tool strip menu item.
        /// </summary>
        private MenuStrip menustrip1;

        /// <summary>
        /// ToolStripMenuItem1 that has several options to choose.
        /// </summary>
        private ToolStripMenuItem toolStripMenuItem1;

        /// <summary>
        /// ToolStripMenuItem2 that has several options to choose.
        /// </summary>
        private ToolStripMenuItem toolStripMenuItem2;

        /// <summary>
        /// ToolStripMenuItem that has several options to choose.
        /// </summary>
        private ToolStripMenuItem toolStripMenuItem3;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// The dataGridView1 for create table.
        /// </summary>
        private System.Windows.Forms.DataGridView dataGridView1;

        /// <summary>
        /// Button for change information in table.
        /// </summary>
        private System.Windows.Forms.Button button1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.menustrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menustrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(520, 250);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            //this.button1.Location = new System.Drawing.Point(24, 286);
            //this.button1.Name = "button1";
            //this.button1.Size = new System.Drawing.Size(500, 23);
            //this.button1.TabIndex = 1;
            //this.button1.Text = "button1";
            //this.button1.UseVisualStyleBackColor = true;
            //this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // menustrip1
            // 
            this.menustrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menustrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,this.toolStripMenuItem2,this.toolStripMenuItem3});
            this.menustrip1.Location = new System.Drawing.Point(0, 0);
            this.menustrip1.Name = "menustrip1";
            this.menustrip1.Size = new System.Drawing.Size(551, 28);
            this.menustrip1.TabIndex = 0;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem1.Text = "File";
            ToolStripItem item1 = this.toolStripMenuItem1.DropDownItems.Add("Save");
            item1.Click += new EventHandler(Save_ToFile);
            //ToolStripItem item2 = this.toolStripMenuItem1.DropDownItems.Add("Load Fibonacci numbers(first 50)");
            //item2.Click += new EventHandler(DropDownItems2_Clicked);
            //ToolStripItem item3 = this.toolStripMenuItem1.DropDownItems.Add("Load Fibonacci numbers(first 100)");
            //item3.Click += new EventHandler(DropDownItems3_Clicked);
            //this.toolStripMenuItem1.DropDownItems.Add(new ToolStripSeparator());
            ToolStripItem item4 = this.toolStripMenuItem1.DropDownItems.Add("Load");
            item4.Click += new EventHandler(Load_FromFile);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem2.Text = "Edit";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem3.Text = "Cell";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 300);
            this.Controls.Add(this.menustrip1);
            //this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menustrip1;
            this.Name = "Form1";
            this.Text = "Spreadsheet Cpts 321";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menustrip1.ResumeLayout(false);
            this.menustrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
