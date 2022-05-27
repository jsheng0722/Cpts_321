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
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

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
        /// Undo stack.
        /// </summary>
        private Stack<IDoAction> undoStack = new Stack<IDoAction>();

        /// <summary>
        /// Redo stack.
        /// </summary>
        private Stack<IDoAction> redoStack = new Stack<IDoAction>();

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
        /// Get Variable names from given expression.
        /// </summary>
        /// <param name="expression">Given expression.</param>
        /// <returns>Queue with variable name.</returns>
        public Queue<string> GetVariable(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                // if the given expression is empty or null
                throw new System.ArgumentNullException("expression", "Invalid empty argument");
            }

            Queue<string> variableQueue = new Queue<string>();
            string currentPart = string.Empty;

            for (int i = 0; i < expression.Length; ++i)
            {
                if (char.IsLetterOrDigit(expression[i]))
                {
                    // If current reading is a letter or digit
                    currentPart += expression[i];
                }
                else
                {
                    // read to the operator
                    if (char.IsLetter(currentPart[0]))
                    {
                        // if the currentPart is a variable
                        variableQueue.Enqueue(currentPart);
                    }

                    currentPart = string.Empty;
                }
            }

            // handle the end part
            if (char.IsLetter(currentPart[0]))
            {
                // if the end part is a valid variable name
                variableQueue.Enqueue(currentPart);
            }

            return variableQueue;
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
        /// Cell text property changed.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event args.</param>
        public void CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell changeCell = sender as Cell;
            if (e.PropertyName == "Color")
            {
                if (changeCell.Color == 0)
                {
                    unchecked
                    {
                        this.spreadSheet[changeCell.RowIndex, changeCell.ColumnIndex].Color = (int)0xFFFFFFFF;
                    }
                }
                else
                {
                    this.spreadSheet[changeCell.RowIndex, changeCell.ColumnIndex].Color = changeCell.Color;
                }

                // this.AddUndo(changeCell.RowIndex, changeCell.ColumnIndex, TypeOfDo.Color, this.spreadSheet[changeCell.RowIndex, changeCell.ColumnIndex].Value);
            }
            else if (e.PropertyName == "CellText")
            {
                Cell spreadSheetCell = this.spreadSheet[changeCell.RowIndex, changeCell.ColumnIndex];
                ExpressionTree expressionString;
                if (string.IsNullOrEmpty(spreadSheetCell.CellText))
                {
                    spreadSheetCell.ChangeValue(string.Empty);
                }
                else if (spreadSheetCell.CellText[0] != '=')
                {
                    spreadSheetCell.ChangeValue("0");
                    for (int i = 0; i < spreadSheetCell.VariableList.Count; ++i)
                    {
                        string indexInCell = spreadSheetCell.VariableList[i];
                        int col = Convert.ToInt32(indexInCell[0]) - 65;
                        int row = Convert.ToInt32(indexInCell.Substring(1)) - 1;
                        Cell currentCell = this.spreadSheet[row, col];
                        string cellIndex = Convert.ToChar(spreadSheetCell.ColumnIndex + 65) + Convert.ToString(spreadSheetCell.RowIndex + 1);
                        string currentCellText = currentCell.CellText;
                        if (currentCellText.Contains(cellIndex))
                        {
                            Queue<string> variableQueue = this.GetVariable(currentCellText.Substring(1));
                            expressionString = new ExpressionTree(currentCellText.Substring(1));
                            while (variableQueue.Count > 0)
                            {
                                string variableInQueue = variableQueue.Dequeue();
                                col = Convert.ToInt32(variableInQueue[0]) - 65;
                                row = Convert.ToInt32(variableInQueue.Substring(1)) - 1;
                                string sheetValue = this.spreadSheet[row, col].Value;

                                if (string.IsNullOrEmpty(sheetValue))
                                {
                                    throw new Exception("Value is empty or null");
                                }

                                string sheetIndex = Convert.ToChar(spreadSheetCell.ColumnIndex + 65) + Convert.ToString(spreadSheetCell.RowIndex + 1);
                                if (!this.spreadSheet[row, col].VariableList.Contains(sheetIndex) && variableInQueue != sheetIndex)
                                {
                                    this.spreadSheet[row, col].VariableList.Add(sheetIndex);
                                }

                                double cellValue = Convert.ToDouble(this.spreadSheet[row, col].Value);
                                expressionString.SetVariable(variableInQueue, cellValue);
                            }

                            currentCell.ChangeValue(expressionString.Evaluate().ToString());

                            // this.AddUndo(row, col, TypeOfDo.Text, this.spreadSheet[row, col].Value);
                        }
                    }
                }
                else
                {
                    string expression = spreadSheetCell.CellText.Substring(1);
                    Queue<string> variableQueue = this.GetVariable(expression);
                    expressionString = new ExpressionTree(expression);
                    while (variableQueue.Count > 0)
                    {
                        string variableInQueue = variableQueue.Dequeue();
                        int col = Convert.ToInt32(variableInQueue[0]) - 65;
                        int row = Convert.ToInt32(variableInQueue.Substring(1)) - 1;
                        string sheetValue = this.spreadSheet[row, col].Value;
                        if (string.IsNullOrEmpty(sheetValue))
                        {
                            throw new Exception("The value is empty or null");
                        }

                        string sheetIndex = Convert.ToChar(spreadSheetCell.ColumnIndex + 65) + Convert.ToString(spreadSheetCell.RowIndex + 1);
                        if (!this.spreadSheet[row, col].VariableList.Contains(sheetIndex) && variableInQueue != sheetIndex)
                        {
                            this.spreadSheet[row, col].VariableList.Add(sheetIndex);
                        }

                        double cellValue = Convert.ToDouble(this.spreadSheet[row, col].Value);
                        expressionString.SetVariable(variableInQueue, cellValue);
                    }

                    spreadSheetCell.ChangeValue(expressionString.Evaluate().ToString());
                }

                // this.AddUndo(changeCell.RowIndex, changeCell.ColumnIndex, TypeOfDo.Text, this.spreadSheet[changeCell.RowIndex, changeCell.ColumnIndex].Value);
            }
            else
            {
                throw new Exception("No such type");
            }
        }

        /// <summary>
        /// Event handler for changing background color.
        /// </summary>
        /// <param name="newColor">The color.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The column.</param>
        public void ChangeBackgroundColor(int newColor, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return;
            }

            this.spreadSheet[row, col].Color = newColor;
        }

        /// <summary>
        /// A public AddUndo function in the spreadsheet class.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The column.</param>
        /// <param name="doType">The type of change.</param>
        /// <param name="content">The content in.</param>
        public void AddUndo(int row, int col, TypeOfDo doType, string content)
        {
            IDoAction newUndo = new Undo(doType, this.spreadSheet[row, col], content);
            this.undoStack.Push(newUndo);
        }

        /// <summary>
        /// Pop undo stack.
        /// </summary>
        /// <returns>Pop value.</returns>
        public IDoAction UndostackPop()
        {
            return this.undoStack.Pop();
        }

        /// <summary>
        /// Pop redo stack.
        /// </summary>
        /// <returns>Pop value.</returns>
        public IDoAction RedostackPop()
        {
            return this.redoStack.Pop();
        }

        /// <summary>
        /// Push redo stack.
        /// </summary>
        /// <param name="doAction">Push value.</param>
        public void RedostackPush(IDoAction doAction)
        {
            this.redoStack.Push(doAction);
        }

        /// <summary>
        /// Push undo stack.
        /// </summary>
        /// <param name="doAction">Push value.</param>
        public void UndostackPush(IDoAction doAction)
        {
            this.undoStack.Push(doAction);
        }

        /// <summary>
        /// Count undo stack.
        /// </summary>
        /// <returns>The count.</returns>
        public int UndoStackCount()
        {
            return this.undoStack.Count;
        }

        /// <summary>
        /// Count redo stack.
        /// </summary>
        /// <returns>The count.</returns>
        public int RedoStackCount()
        {
            return this.redoStack.Count;
        }

        /// <summary>
        /// Top of redo stack.
        /// </summary>
        /// <returns>The peek.</returns>
        public IDoAction RedoStackPeek()
        {
            return this.redoStack.Peek();
        }

        /// <summary>
        /// Top of undo stack.
        /// </summary>
        /// <returns>The peek.</returns>
        public IDoAction UndoStackPeek()
        {
            return this.undoStack.Peek();
        }

        /// <summary>
        /// Save stream into file.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void Save(Stream stream)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(stream, settings);

            writer.WriteStartElement("spreadsheet");

            foreach (Cell cells in this.spreadSheet)
            {
                if (!string.IsNullOrEmpty(cells.CellText))
                {
                    string cellIndex = Convert.ToChar(cells.RowIndex + 65) + Convert.ToString(cells.ColumnIndex + 1);
                    writer.WriteStartElement("cell");
                    writer.WriteAttributeString("name", cellIndex);
                    writer.WriteElementString("bgcolor", cells.Color.ToString("x8"));
                    writer.WriteElementString("text", cells.CellText.ToString());
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Close();
        }

        /// <summary>
        /// Load stream from file.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void Load(Stream stream)
        {
            XDocument xd = XDocument.Load(stream);
            foreach (XElement elem in xd.Root.Elements("cell"))
            {
                string name = elem.Attribute("name").Value;

                Cell cells = this.spreadSheet[Convert.ToInt32(name[0]) - 65, Convert.ToInt32(name[1]) - 49];

                if (elem.Element("bgcolor") != null)
                {
                    cells.Color = (int)uint.Parse(elem.Element("bgcolor").Value, System.Globalization.NumberStyles.HexNumber);
                }

                if (elem.Element("text") != null)
                {
                    cells.CellText = elem.Element("text").Value.ToString();
                }
            }
        }

        /// <summary>
        /// Clear the spreadsheet.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < this.spreadSheet.GetLength(0); ++i)
            {
                for (int j = 0; j < this.spreadSheet.GetLength(1); ++j)
                {
                    this.spreadSheet[i, j].CellText = string.Empty;
                    this.spreadSheet[i, j].Color = 0;
                }
            }
        }
        
        /// <summary>
        /// Clear undo stack.
        /// </summary>
        public void ClearUndoStack()
        {
            this.undoStack.Clear();
        }

        /// <summary>
        /// Clear redo stack.
        /// </summary>
        public void ClearRedoStack()
        {
            this.redoStack.Clear();
        }
    }
}
