// *********************************************************
// Class: OperatorNodeFactory
// CptS321_HW6
// Name: Jihui.Sheng
// Id: 11539324
// <copyright file="OperatorNodeFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// *********************************************************
namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// OperatorNodeFactory class that has 4 operators.
    /// </summary>
    public class OperatorNodeFactory : Expression
    {
        /// <summary>
        /// Add class.
        /// </summary>
        public class Add : OperatorNode
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Add"/> class.
            /// </summary>
            public Add()
                : base('+')
            {
            }

            /// <inheritdoc/>
            public override double Evaluate()
            {
                return this.Left.Evaluate() + this.Right.Evaluate();
            }
        }

        /// <summary>
        /// Minus class.
        /// </summary>
        public class Minus : OperatorNode
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Minus"/> class.
            /// </summary>
            public Minus()
                : base('-')
            {
            }

            /// <inheritdoc/>
            public override double Evaluate()
            {
                return this.Left.Evaluate() - this.Right.Evaluate();
            }
        }

        /// <summary>
        /// Multiple class.
        /// </summary>
        public class Multiple : OperatorNode
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Multiple"/> class.
            /// </summary>
            public Multiple()
                : base('*')
            {
            }

            /// <inheritdoc/>
            public override double Evaluate()
            {
                return this.Left.Evaluate() * this.Right.Evaluate();
            }
        }

        /// <summary>
        /// Divide class.
        /// </summary>
        public class Divide : OperatorNode
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Divide"/> class.
            /// </summary>
            public Divide()
                : base('/')
            {
            }

            /// <inheritdoc/>
            public override double Evaluate()
            {
                return this.Left.Evaluate() / this.Right.Evaluate();
            }
        }
    }
}
