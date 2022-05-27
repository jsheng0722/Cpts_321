// *********************************************************
// Class: Cpts321
// Spreadsheet_Jihui_Sheng
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// *********************************************************
namespace Spreadsheet_Jihui_Sheng
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CptS321;

    /// <summary>
    /// From1 class.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Spread sheet.
        /// </summary>
        private SpreadSheet sheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();

        }

        /// <summary>
        /// For reset the dataGridView.
        /// </summary>
        private void ResetDataGridView()
        {
            this.dataGridView1.CancelEdit();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = null;
        }

        /// <summary>
        /// Form load for creating spreadsheet.
        /// </summary>
        /// <param name="sender">Event Sender.</param>
        /// <param name="e">Event Args.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ResetDataGridView();

            this.sheet = new SpreadSheet(26, 50);

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridView1.CellValueChanged += this.SpreadSheet_Update;
            this.dataGridView1.CellBeginEdit += this.CellBeginEdit_Event;
            this.dataGridView1.CellEndEdit += this.CellEndEdit_Event;

            for (int i = 0; i < this.sheet.RowCount(); i++)
            {
                string alph = ((char)('A' + i)).ToString();
                this.dataGridView1.Columns.Add(alph, alph);
                this.dataGridView1.Columns[i].MinimumWidth = 50;
                this.dataGridView1.Columns[i].Width = 100;
            }

            for (int j = 0; j < this.sheet.ColumnCount(); j++)
            {
                string[] rows = new string[] { };
                this.dataGridView1.Rows.Add(rows);
            }

            int rowNumber = 1;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                row.HeaderCell.Value = string.Empty + rowNumber;
                rowNumber = rowNumber + 1;
            }
        }

        /// <summary>
        /// CellBeginEdit event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Event args.</param>
        private void CellBeginEdit_Event(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.sheet.GetCell(e.RowIndex, e.ColumnIndex).CellText;
        }

        /// <summary>
        /// CellEndEdit event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Event args.</param>
        private void CellEndEdit_Event(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            string changeText = this.sheet.GetCell(e.RowIndex, e.ColumnIndex).CellText;
            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.sheet.GetCell(e.RowIndex, e.ColumnIndex).Value;
            this.sheet.GetCell(e.RowIndex, e.ColumnIndex).CellText = changeText;
            for (int i = 0; i < this.sheet.GetCell(e.RowIndex, e.ColumnIndex).ChangeList.Count; ++i)
            {
                string curSubCellIndex = this.sheet.GetCell(e.RowIndex, e.ColumnIndex).ChangeList[i];
                int col = Convert.ToInt32(curSubCellIndex[0]) - 65;
                int row = Convert.ToInt32(curSubCellIndex.Substring(1)) - 1;
                string cellText = this.sheet.GetCell(row, col).CellText;
                DataGridViewCell curSubCell = this.dataGridView1.Rows[row].Cells[col];
                curSubCell.Value = this.sheet.GetCell(row, col).Value;
                this.sheet.GetCell(row, col).CellText = cellText;
            }
        }

        /// <summary>
        /// Update the spreadsheet when complete edit cell text.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Event args.</param>
        private void SpreadSheet_Update(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }

            this.sheet.GetCell(e.RowIndex, e.ColumnIndex).CellText = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        /// <summary>
        /// Button for random text in cells.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Event args.</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            Random c = new Random();
            this.button1.Text = "Perform Demo";
            for (int i = 0; i < 50; i++)
            {
                this.sheet.GetCell(r.Next(1, this.sheet.RowCount()), c.Next(1, this.sheet.ColumnCount())).CellText = "Hello World!";

                this.dataGridView1.Rows[r.Next(1, this.sheet.ColumnCount())].Cells[c.Next(1, this.sheet.RowCount())].Value = "Hello World!";
            }

            for (int j = 0; j < this.sheet.ColumnCount(); j++)
            {
                this.dataGridView1.Rows[j].Cells[1].Value = "This is cell" + j.ToString() + "#";
            }

            for (int j = 0; j < this.sheet.ColumnCount(); j++)
            {
                this.dataGridView1.Rows[j].Cells[0].Value = "=" + j.ToString() + "#";
            }
        }
    }
}
