// *********************************************************
// Class: Cpts321
// SpreadsheetEngine
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="SpreadSheetCell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// *********************************************************
namespace CptS321
{
    /// <summary>
    /// Spread sheet cell.
    /// </summary>
    public class SpreadSheetCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadSheetCell" /> class.
        /// </summary>
        /// <param name="row">Row of cell.</param>
        /// <param name="col">Col of cell.</param>
        public SpreadSheetCell(int row, int col)
            : base(row, col)
        {
            row = this.RowIndex;
            col = this.ColumnIndex;
        }
    }
}