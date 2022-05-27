// *********************************************************
// Class: Cpts321
// SpreadsheetEngine
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="SpreadSheet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// *********************************************************
namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using CptS321;

    /// <summary>
    /// SpreadSheet that implement Cell.
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
        public SpreadSheet(int row, int col)
            : base(row, col)
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
        /// Number of row.
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
        /// Get the cell info.
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
        /// Cell property changed.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event args.</param>
        public void CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell changeCell = sender as Cell;
            Cell spreadSheetCell = this.spreadSheet[changeCell.RowIndex, changeCell.ColumnIndex];
            ExpressionTree expressionString;
            if (spreadSheetCell.CellText[0] != '=')
            {
                string expression1 = spreadSheetCell.CellText;
                double doubleNumber = 0.0;
                expressionString = new ExpressionTree(expression1);
                char col = (char)(spreadSheetCell.ColumnIndex + 65);
                int row = Convert.ToInt32(spreadSheetCell.RowIndex) + 1;
                string indexOfCell = col.ToString() + row.ToString();
                if (double.TryParse(spreadSheetCell.CellText, out doubleNumber))
                {
                    if (this.VariableDictionary.ContainsKey(indexOfCell))
                    {
                        this.VariableDictionary[indexOfCell] = Convert.ToDouble(expression1);
                    }
                    else
                    {
                        this.VariableDictionary.Add(indexOfCell, Convert.ToDouble(expression1));
                    }

                    expressionString.SetVariable(indexOfCell, Convert.ToDouble(expression1));
                    spreadSheetCell.ChangeValue(expression1);
                }
                else
                {
                    spreadSheetCell.ChangeValue("0");
                }
            }
            else
            {
                string expression1 = spreadSheetCell.CellText.Substring(1);
                expressionString = new ExpressionTree(expression1);
                char col = (char)(spreadSheetCell.ColumnIndex + 65);
                int row = Convert.ToInt32(spreadSheetCell.RowIndex) + 1;
                string indexOfCell = col.ToString() + row.ToString();
                foreach (string key in this.VariableDictionary.Keys)
                {
                    expressionString.SetVariable(key, this.VariableDictionary[key]);
                }

                if (this.VariableDictionary.ContainsKey(indexOfCell))
                {
                    this.VariableDictionary[indexOfCell] = Convert.ToDouble(expressionString.Evaluate().ToString());
                }
                else
                {
                    this.VariableDictionary.Add(indexOfCell, Convert.ToDouble(expressionString.Evaluate().ToString()));
                }

                spreadSheetCell.ChangeValue(expressionString.Evaluate().ToString());
            }
        }
    }
}
