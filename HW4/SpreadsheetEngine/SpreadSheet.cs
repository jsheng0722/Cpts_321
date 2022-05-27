// *********************************************************
// <copyright file="SpreadSheet.cs" company="My Company">
// Class: Cpts321
// SpreadsheetEngine
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using CptS321;

    /// <summary>
    /// SpreadSheet that implement Cell
    /// </summary>
    public class SpreadSheet : Cell
    {
        /// <summary>
        /// Cell 2D array.
        /// </summary>
        private Cell[,] spreadSheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadSheet" /> class.
        /// </summary>
        public SpreadSheet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadSheet" /> class.
        /// </summary>
        /// <param name="row">Number of row.</param>
        /// <param name="col">Number of col.</param>
        public SpreadSheet(int row, int col) : base(row, col)
        {
            this.spreadSheet = new Cell[row, col];
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    this.spreadSheet[x, y] = new SpreadSheetCell(x, y);
                    this.spreadSheet[x, y].PropertyChanged += this.CellPropertyChanged;
                }
            }
        }

        /// <summary>
        /// CellPropertyChanged
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event args.</param>
        public void CellPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (this.spreadSheet[row, col].CellText[0] != '=')
            {
            }
            else
            {
            }
        }

        /// <summary>
        /// get the cell info.
        /// </summary>
        /// <param name="row">The row of cell.</param>
        /// <param name="col">The col of cell.</param>
        /// <returns>The cell.</returns>
        public Cell GetCell(int row, int col)
        {
            Cell takeCell = null;
            if ((col >= this.ColumnCount() || col < 0) && (row >= this.RowCount() || row < 0))
            {
                return null;
            }

            takeCell = this.spreadSheet[row, col];
            return takeCell;
        }

        /// <summary>
        /// Number of row
        /// </summary>
        /// <returns>Row number of cell.</returns>
        public int RowCount()
        {
            return this.spreadSheet.GetLength(0);
        }

        /// <summary>
        /// Number of col.
        /// </summary>
        /// <returns>The col.</returns>
        public int ColumnCount()
        {
            return this.spreadSheet.GetLength(1);
        }

        /// <summary>
        /// Class of new cell.
        /// </summary>
        public class SpreadSheetCell : Cell
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SpreadSheetCell" /> class.
            /// </summary>
            /// <param name="row">Row of cell.</param>
            /// <param name="col">Col of cell.</param>
            public SpreadSheetCell(int row, int col) : base(row, col)
            {
                this.row = this.RowIndex;
                this.col = this.ColumnIndex;
            }
        }
    }
}
