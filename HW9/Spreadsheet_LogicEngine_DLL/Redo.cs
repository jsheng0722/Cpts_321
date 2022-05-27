// *********************************************************
// Class: Cpts321
// Redo
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="Redo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// *********************************************************
namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Redo class.
    /// </summary>
    public class Redo : IDoAction
    {
        /// <summary>
        /// Redo type.
        /// </summary>
        private TypeOfDo doType;

        /// <summary>
        /// Redo cell.
        /// </summary>
        private Cell myCell;

        /// <summary>
        /// Undo content.
        /// </summary>
        private string redoContent;

        /// <summary>
        /// Initializes a new instance of the <see cref="Redo"/> class.
        /// </summary>
        /// <param name="type">The type of cell.</param>
        /// <param name="cell">The cell needs redo.</param>
        /// <param name="content">Content need to change.</param>
        public Redo(TypeOfDo type, Cell cell, string content)
        {
            this.doType = type;
            this.myCell = cell;
            this.redoContent = content;
        }

        /// <summary>
        /// Gets undo type.
        /// </summary>
        public TypeOfDo DoType
        {
            get
            {
                return this.doType;
            }
        }

        /// <summary>
        /// Gets cell.
        /// </summary>
        public Cell MyCell
        {
            get
            {
                return this.myCell;
            }
        }

        /// <summary>
        /// Gets undo content.
        /// </summary>
        public string RedoContent
        {
            get
            {
                return this.redoContent;
            }
        }

        /// <summary>
        /// Redo action.
        /// </summary>
        public void Action()
        {
            if (this.doType == TypeOfDo.Text)
            {
                this.myCell.CellText = this.redoContent;
            }
            else if (this.doType == TypeOfDo.Color)
            {
                this.myCell.Color = Convert.ToInt32(this.redoContent);
            }
        }
    }
}
