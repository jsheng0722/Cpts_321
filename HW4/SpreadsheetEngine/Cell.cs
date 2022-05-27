// *********************************************************
// <copyright file="Cell.cs" company="My Company">
// Class: Cpts321
// Abstract cell class
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace CptS321
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Cell class that implement INotify Property Changed.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Row in cell.
        /// </summary>
        protected int row;

        /// <summary>
        /// Col in cell.
        /// </summary>
        protected int col;

        /// <summary>
        /// Text in cell.
        /// </summary>
        protected string textInCell;

        /// <summary>
        /// Value in cell.
        /// </summary>
        protected string valueInCell;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell" /> class.
        /// </summary>
        public Cell()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell" /> class.
        /// </summary>
        /// <param name="rowIndex">Index of row.</param>
        /// <param name="colIndex">>Index of col.</param>
        protected Cell(int rowIndex, int colIndex)
        {
            this.row = rowIndex;
            this.col = colIndex;
        }

        /// <summary>
        /// PropertyChangedEventHandler event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// Gets the rowIndex.
        /// </summary>
        public int RowIndex 
        { 
            get { return this.row; } 
        }

        /// <summary>
        /// Gets the columnIndex.
        /// </summary>
        public int ColumnIndex 
        { 
            get { return this.col; }
        }

        /// <summary>
        /// Gets or sets text in cell.
        /// </summary>
        public string CellText
        {
            get 
            { 
                return this.textInCell;
            }

            set
            {
                if (this.textInCell == value)
                {
                    return;
                }

                this.textInCell = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets value in cell.
        /// </summary>
        public string Value
        {
            get
            {
                return this.valueInCell;
            }
        }

        /// <summary>
        /// Change value to new value
        /// </summary>
        /// <param name="newValue">New value.</param>
        public void ChangeValue(string newValue)
        {
            this.valueInCell = newValue;
        }

        /// <summary>
        /// OnPropertyChanged event.
        /// </summary>
        /// <param name="name">Caller Member Name.</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
