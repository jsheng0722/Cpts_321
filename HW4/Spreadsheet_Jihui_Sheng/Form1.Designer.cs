// *********************************************************
// <copyright file="Form1.Designer.cs" company="My Company">
// Class: Cpts321
// Spreadsheet_Jihui_Sheng
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace Spreadsheet_Jihui_Sheng
{
    /// <summary>
    /// Partial class form1.
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// The dataGridView1 for create table.
        /// </summary>
        private System.Windows.Forms.DataGridView dataGridView1;

        /// <summary>
        /// First column A.
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn upperCaseA;

        /// <summary>
        /// Second column B.
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn upperCaseB;

        /// <summary>
        /// Third column C.
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn upperCaseC;

        /// <summary>
        /// Forth column D.
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn upperCaseD;

        /// <summary>
        /// Fifth column E.
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn upperCaseE;

        /// <summary>
        /// Sixth column F.
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn upperCaseF;

        /// <summary>
        /// Seventh column G.
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn upperCaseG;

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
            this.upperCaseA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upperCaseB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upperCaseC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upperCaseD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upperCaseE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upperCaseF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upperCaseG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.upperCaseA,
            this.upperCaseB,
            this.upperCaseC,
            this.upperCaseD,
            this.upperCaseE,
            this.upperCaseF,
            this.upperCaseG});
            this.dataGridView1.Location = new System.Drawing.Point(26, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(500, 250);
            this.dataGridView1.TabIndex = 0;
            // 
            // A
            // 
            this.upperCaseA.HeaderText = "A";
            this.upperCaseA.MinimumWidth = 6;
            this.upperCaseA.Name = "A";
            this.upperCaseA.Width = 125;
            // 
            // B
            // 
            this.upperCaseB.HeaderText = "B";
            this.upperCaseB.MinimumWidth = 6;
            this.upperCaseB.Name = "B";
            this.upperCaseB.Width = 125;
            // 
            // C
            // 
            this.upperCaseC.HeaderText = "C";
            this.upperCaseC.MinimumWidth = 6;
            this.upperCaseC.Name = "C";
            this.upperCaseC.Width = 125;
            // 
            // D
            // 
            this.upperCaseD.HeaderText = "D";
            this.upperCaseD.MinimumWidth = 6;
            this.upperCaseD.Name = "D";
            this.upperCaseD.Width = 125;
            // 
            // E
            // 
            this.upperCaseE.HeaderText = "E";
            this.upperCaseE.MinimumWidth = 6;
            this.upperCaseE.Name = "E";
            this.upperCaseE.Width = 125;
            // 
            // F
            // 
            this.upperCaseF.HeaderText = "F";
            this.upperCaseF.MinimumWidth = 6;
            this.upperCaseF.Name = "F";
            this.upperCaseF.Width = 125;
            // 
            // G
            // 
            this.upperCaseG.HeaderText = "G";
            this.upperCaseG.MinimumWidth = 6;
            this.upperCaseG.Name = "G";
            this.upperCaseG.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(500, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Spreadsheet Cpts 321";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}