// *********************************************************
// Class: Cpts321
// Undo
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="Undo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// *********************************************************
namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Undo class.
    /// </summary>
    public class Undo : IDoAction
    {
        /// <summary>
        /// Undo type.
        /// </summary>
        private TypeOfDo doType;

        /// <summary>
        /// Undo cell.
        /// </summary>
        private Cell myCell;

        /// <summary>
        /// Undo content.
        /// </summary>
        private string undoContent;

        /// <summary>
        /// Initializes a new instance of the <see cref="Undo"/> class.
        /// </summary>
        /// <param name="type">The type of cell.</param>
        /// <param name="cell">The cell needs undo.</param>
        /// <param name="content">Content need to change.</param>
        public Undo(TypeOfDo type, Cell cell, string content)
        {
            this.doType = type;
            this.myCell = cell;
            this.undoContent = content;
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
        public string UndoContent
        {
            get
            {
                return this.undoContent;
            }
        }

        /// <summary>
        /// Action undo.
        /// </summary>
        public void Action()
        {
            if (this.doType == TypeOfDo.Text)
            {
                this.myCell.CellText = this.undoContent;
            }
            else if (this.doType == TypeOfDo.Color)
            {
                this.myCell.Color = Convert.ToInt32(this.undoContent);
            }
        }
    }
}
