// *********************************************************
// Class: Cpts321
// Spreadsheet_Jihui_Sheng
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// *********************************************************
namespace Loading_and_Saving_Spreadsheet_Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
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
        /// Tool Strip Item1 in second.
        /// </summary>
        private ToolStripItem item21;

        /// <summary>
        /// Tool Strip Item2 in second.
        /// </summary>
        private ToolStripItem item22;

        /// <summary>
        /// Tool Strip Item1 in third.
        /// </summary>
        private ToolStripItem item31;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.Load += new EventHandler(this.Form1_Load);
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

            this.item21 = this.toolStripMenuItem2.DropDownItems.Add("Undo");
            this.item21.Click += new EventHandler(this.Event_Undo);
            this.item22 = this.toolStripMenuItem2.DropDownItems.Add("Redo");
            this.item22.Click += new EventHandler(this.Event_Redo);
            this.item31 = this.toolStripMenuItem3.DropDownItems.Add("Change background color");
            this.item31.Click += new EventHandler(this.DisplayColorMenu);

            this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
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

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                foreach (DataGridViewColumn col in this.dataGridView1.Columns)
                {
                    unchecked
                    {
                        this.dataGridView1[col.Index, row.Index].Style.BackColor = System.Drawing.Color.FromArgb((int)0xFFFFFFFF);
                    }
                }
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
            if (changeText != null)
            {
                if (changeText[0] == '=')
                {
                    this.sheet.UndostackPop();
                }
            }
            
            foreach (string i in this.sheet.GetCell(e.RowIndex, e.ColumnIndex).VariableList)
            {
                int col = Convert.ToInt32(i[0]) - 65;
                int row = Convert.ToInt32(i.Substring(1)) - 1;
                string prevCellText = this.sheet.GetCell(row, col).CellText;
                dataGridView.Rows[row].Cells[col].Value = this.sheet.GetCell(row, col).Value;
                this.sheet.GetCell(row, col).CellText = prevCellText;
                this.sheet.UndostackPop();
            }
        }

        /// <summary>
        /// Update the spreadsheet when complete edit cell text.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Event args.</param>
        private void SpreadSheet_Update(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }

            string str1;
            if (string.IsNullOrEmpty(this.sheet.GetCell(e.RowIndex, e.ColumnIndex).CellText))
            {
                str1 = string.Empty;
            }
            else
            {
                str1 = this.sheet.GetCell(e.RowIndex, e.ColumnIndex).CellText;
            }

            this.sheet.AddUndo(e.RowIndex, e.ColumnIndex, TypeOfDo.Text, str1);
            this.item21.Text = "Undo Text change";
            this.item22.Enabled = false;
            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                this.sheet.GetCell(e.RowIndex, e.ColumnIndex).CellText = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }

        /// <summary>
        /// Save to file.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Event Args.</param>
        private void Save_ToFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenWrite(saveFileDialog1.FileName);
                this.sheet.Save(fs);
                fs.Dispose();
            }
        }

        /// <summary>
        /// Load from file.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Event Args.</param>
        private void Load_FromFile(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.sheet.Clear();
                Stream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                this.sheet.Load(fs);
                fs.Dispose();
                this.sheet.ClearRedoStack();
                this.sheet.ClearUndoStack();
            }

            for (int i = 0; i < this.sheet.RowCount() - 1; ++i)
            {
                for (int j = 0; j < this.sheet.RowCount() - 1; ++j)
                {
                    if (this.sheet.GetCell(i, j).CellText != null)
                    {
                        this.dataGridView1.Rows[i].Cells[j].Value = this.sheet.GetCell(i, j).CellText;
                    }
                }
            }
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

        /// <summary>
        /// Color Menu pop when click.
        /// </summary>
        /// <param name="sender">The ender.</param>
        /// <param name="e">Event args.</param>
        private void DisplayColorMenu(object sender, EventArgs e)
        {
            ColorDialog myDialog = new ColorDialog();
            myDialog.AllowFullOpen = false;
            this.ChangeCellColor(myDialog);
        }

        /// <summary>
        /// Event handle change cell background color.
        /// </summary>
        /// <param name="colorInCell">The color in background.</param>
        private void ChangeCellColor(ColorDialog colorInCell)
        {
            if (colorInCell.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewCell i in this.dataGridView1.SelectedCells)
                {
                    if (i.RowIndex == -1 || i.ColumnIndex == -1)
                    {
                        return;
                    }

                    this.sheet.AddUndo(i.ColumnIndex, i.RowIndex, TypeOfDo.Color, Convert.ToString(this.sheet.GetCell(i.ColumnIndex, i.RowIndex).Color));
                    this.item21.Text = "Undo Color change";
                    this.sheet.ChangeBackgroundColor(colorInCell.Color.ToArgb(), i.ColumnIndex, i.RowIndex);
                    this.dataGridView1[i.ColumnIndex, i.RowIndex].Style.BackColor = System.Drawing.Color.FromArgb(this.sheet.GetCell(i.ColumnIndex, i.RowIndex).Color);
                }
            }
        }

        /// <summary>
        /// Undo event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Event args.</param>
        private void Event_Undo(object sender, EventArgs e)
        {
            if (this.sheet.UndoStackCount() > 0)
            {
                IDoAction valueOnTop = this.sheet.UndostackPop();

                Undo addToRedo = (Undo)valueOnTop;
                if (addToRedo.DoType == TypeOfDo.Text)
                {
                    IDoAction newRedo = new Redo(addToRedo.DoType, addToRedo.MyCell, addToRedo.MyCell.CellText);
                    this.item22.Text = "Redo text change";
                    this.sheet.RedostackPush(newRedo);
                    valueOnTop.Action();

                    // this.dataGridView1.Rows[addToRedo.MyCell.ColumnIndex].Cells[addToRedo.MyCell.RowIndex].Value = this.sheet.GetCell(addToRedo.MyCell.RowIndex, addToRedo.MyCell.ColumnIndex).Value;
                    this.dataGridView1.Rows[addToRedo.MyCell.RowIndex].Cells[addToRedo.MyCell.ColumnIndex].Value = this.sheet.GetCell(addToRedo.MyCell.RowIndex, addToRedo.MyCell.ColumnIndex).Value;
                }
                else if (addToRedo.DoType == TypeOfDo.Color)
                {
                    IDoAction newRedo = new Redo(addToRedo.DoType, addToRedo.MyCell, addToRedo.MyCell.Color.ToString());
                    this.sheet.RedostackPush(newRedo);
                    this.item22.Text = "Redo Color change";
                    valueOnTop.Action();

                    // this.dataGridView1.Rows[addToRedo.MyCell.RowIndex].Cells[addToRedo.MyCell.ColumnIndex].Style.BackColor = System.Drawing.Color.FromArgb(this.sheet.GetCell(addToRedo.MyCell.RowIndex, addToRedo.MyCell.ColumnIndex).Color);
                    this.dataGridView1.Rows[addToRedo.MyCell.ColumnIndex].Cells[addToRedo.MyCell.RowIndex].Style.BackColor = System.Drawing.Color.FromArgb(this.sheet.GetCell(addToRedo.MyCell.RowIndex, addToRedo.MyCell.ColumnIndex).Color);
                }

                this.item22.Enabled = true;
                this.sheet.UndostackPop();
                if (this.sheet.UndoStackCount() == -1)
                {
                    this.item21.Enabled = false;
                }
            }
            else
            {
                throw new Exception("Out of range");
            }
        }

        /// <summary>
        /// Redo event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Event args.</param>
        private void Event_Redo(object sender, EventArgs e)
        {
            if (this.sheet.RedoStackCount() > 0)
            {
                IDoAction valueOnTop = this.sheet.RedostackPop();

                Redo addToUndo = (Redo)valueOnTop;
                if (addToUndo.DoType == TypeOfDo.Text)
                {
                    IDoAction newUndo = new Undo(addToUndo.DoType, addToUndo.MyCell, addToUndo.MyCell.CellText);
                    this.sheet.UndostackPush(newUndo);
                    this.item21.Text = "Redo text change";
                    valueOnTop.Action();

                    // this.dataGridView1.Rows[addToUndo.MyCell.RowIndex].Cells[addToUndo.MyCell.ColumnIndex].Value = this.sheet.GetCell(addToUndo.MyCell.RowIndex, addToUndo.MyCell.ColumnIndex).Value;
                    this.dataGridView1.Rows[addToUndo.MyCell.RowIndex].Cells[addToUndo.MyCell.ColumnIndex].Value = this.sheet.GetCell(addToUndo.MyCell.RowIndex, addToUndo.MyCell.ColumnIndex).Value;
                }
                else if (addToUndo.DoType == TypeOfDo.Color)
                {
                    IDoAction newUndo = new Undo(addToUndo.DoType, addToUndo.MyCell, addToUndo.MyCell.Color.ToString());
                    this.sheet.UndostackPush(newUndo);
                    this.item21.Text = "Redo Color change";
                    valueOnTop.Action();

                    // this.dataGridView1.Rows[addToUndo.MyCell.RowIndex].Cells[addToUndo.MyCell.ColumnIndex].Style.BackColor = System.Drawing.Color.FromArgb(this.sheet.GetCell(addToUndo.MyCell.RowIndex, addToUndo.MyCell.ColumnIndex).Color);
                    this.dataGridView1.Rows[addToUndo.MyCell.ColumnIndex].Cells[addToUndo.MyCell.RowIndex].Style.BackColor = System.Drawing.Color.FromArgb(this.sheet.GetCell(addToUndo.MyCell.RowIndex, addToUndo.MyCell.ColumnIndex).Color);
                }

                this.item21.Enabled = true;
                this.sheet.UndostackPop();
                if (this.sheet.RedoStackCount() == -1)
                {
                    this.item22.Enabled = false;
                }
            }
            else
            {
                throw new Exception("Out of range");
            }
        }
    }
}
