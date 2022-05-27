// *********************************************************
// <copyright file="Form1.cs" company="My Company">
// Class: Cpts321
// Spreadsheet_Jihui_Sheng
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace Spreadsheet_Jihui_Sheng
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
    using SpreadsheetEngine;
    /// <summary>
    /// From1 class.
    /// </summary>
    public partial class Form1 : Form
    {
        SpreadSheet sheet;
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        /// <summary>
        /// For reset the dataGridView.
        /// </summary>
        private void ResetDataGridView()
        {
            dataGridView1.CancelEdit();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
        }

        /// <summary>
        /// Form load for creating spreadsheet.
        /// </summary>
        /// <param name="sender">Event Sender.</param>
        /// <param name="e">Event Aruments.</param>
        private void Form1_Load(Object sender, EventArgs e)
        {
            this.ResetDataGridView();

            sheet = new SpreadSheet(26, 50);

            //this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //this.dataGridView1.Columns.Add("", "");
            //this.dataGridView1.Columns[0].MinimumWidth = 50;
            //this.dataGridView1.Columns[0].Width = 100;
            for (int i = 0; i <sheet.RowCount(); i++)
            {
                String alph = ((char)('A' + i)).ToString();
                this.dataGridView1.Columns.Add(alph, alph);
                this.dataGridView1.Columns[i].MinimumWidth = 50;
                this.dataGridView1.Columns[i].Width = 100;
            }

            //dataGridView1.AutoResizeColumnHeadersHeight();
            //this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            for (int j = 0; j < sheet.ColumnCount(); j++)
            {
                string[] rows = new string[] { };
                this.dataGridView1.Rows.Add(rows);
            }


            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = ""+rowNumber;
                rowNumber = rowNumber + 1;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            Random c = new Random();
            button1.Text = "Perform Demo";
            for (int i = 0; i < 50; i++)
            {
                //sheet.GetCell(r.Next(1, sheet.RowCount()), c.Next(1, sheet.ColumnCount())).CellText = "Hello World!";
                this.dataGridView1.Rows[r.Next(1, sheet.ColumnCount())].Cells[c.Next(1, sheet.RowCount())].Value = "Hello World!";
            }
            for (int j =0;j< sheet.ColumnCount(); j++)
            {
                this.dataGridView1.Rows[j].Cells[1].Value = "This is cell" + j.ToString() + "#";
            }
            for (int j = 0; j < sheet.ColumnCount(); j++)
            {
                this.dataGridView1.Rows[j].Cells[0].Value = "=" + j.ToString() + "#";
            }
        }
    }
}
