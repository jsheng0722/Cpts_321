// *********************************************************
// <copyright file="FibonacciTextReader.cs" company="My Company">
// Class: Cpts321
// WinForms “Notepad” Application / Fibonacci BigInt Text Reader
// Name: Jihui.Sheng
// Id: 11539324
// </copyright>
// *********************************************************
namespace HW3_Notepad
{
    using System.Collections.Generic;
    using System.IO;
    using System.Numerics;

    /// <summary>
    /// FibonacciTextReader class.
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        /// <summary>
        /// Private type of dictionary.
        /// </summary>
        private Dictionary<int, BigInteger> fb = new Dictionary<int, BigInteger>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader" /> class.
        /// </summary>
        /// <param name="number"> Count of the Fibonacci numbers.</param>
        public FibonacciTextReader(int number)
        {
            int num = number - 1;
            this.fb = new Dictionary<int, BigInteger>(number);
            BigInteger[] bigIntegerArray = new BigInteger[number];
            bigIntegerArray[0] = (BigInteger)0;
            this.fb.Add(1, bigIntegerArray[0]);
            bigIntegerArray[1] = (BigInteger)1;
            this.fb.Add(2, bigIntegerArray[1]);
            for (int index = 2; index <= num; ++index)
            {
                bigIntegerArray[index] = bigIntegerArray[index - 2] + bigIntegerArray[index - 1];
            }

            for (int index = 2; index <= num; ++index)
            {
                this.fb.Add(index + 1, bigIntegerArray[index]);
            }
        }

        /// <summary>
        /// Gets the dictionary from private type;
        /// </summary>
        public Dictionary<int, BigInteger> Fb
        {
            get { return this.fb; }
        }
    }
}
