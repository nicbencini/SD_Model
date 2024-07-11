using System;


namespace SD_Model.Vector
{
    /// <summary>
    /// Class <c>SD_Matrix</c> 
    /// Matrix library class.
    /// </summary>
    public class SD_Matrix
    {
        public double[][] Values { get; set; }

        public int RowCount { get; set; } // Rows are horizontal

        public int ColumnCount { get; set; } // Cols are vertical

        /// <summary>
        /// Create matrix from array of arrays.
        /// </summary>
        /// <param name="matrix"> (double[][]) Creates a matrix from a double array.</param>
        /// <returns>
        /// A 2-dimensional matrix.
        /// </returns>
        public SD_Matrix(double[][] matrix)
        {

            RowCount = matrix.Length;

            ColumnCount = matrix[0].Length;

            for (int i = 0; i < matrix.Length; i++)
            {

                if (matrix[i].Length != ColumnCount)
                {

                    throw new Exception("Irregular Matrix: Matrix column lengths are not equal");
                }

            }
            Values = matrix;
        }

        /// <summary>
        /// Checks whether matrix column length and row length are the same.
        /// </summary>
        /// <returns>
        /// 'True' if matrix is square.
        /// </returns>
        public bool IsSquare()
        {
            

            bool result = false;

            if (RowCount == ColumnCount)
            {
                result = true;
            }

            return result;

        }

        /// <summary>
        /// Checks whether matrix is equal to other matrix.
        /// </summary>
        /// <param name="other"> (SD_Matrix) The matrix to check against.</param>
        /// <returns>
        /// 'True' if matrices are equel.
        /// </returns>
        public bool Equals(SD_Matrix other)
        {
            
            bool result = false;

            if (RowCount == other.RowCount && ColumnCount == other.ColumnCount)
            {
                for (int i = 0; i < RowCount; i++)
                {
                    if (Values[i] == other.Values[i])
                    {
                        result = true;
                    }

                    else
                    {
                        result = false;
                        break;
                    }

                }
            }
            else
            {
                result = false;
            }

            return result;

        }

        /// <summary>
        /// Checks whether matrix is same size to other matrix.
        /// </summary>
        /// <param name="other"> (SD_Matrix) The matrix to check against.</param>
        /// <returns>
        /// 'True' if matrices are the same size.
        /// </returns>

        public bool IsSameSize(SD_Matrix other)
        {

            bool result = false;

            if (RowCount == other.RowCount && ColumnCount == other.ColumnCount)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Scales a matrix by a value.
        /// </summary>
        /// <param name="value"> (double) The scalar value.</param>
        /// <returns>
        /// The scaled matrix.
        /// </returns>
        public void Scale(double value)
        {
            

            SD_Matrix scaledMatrix = this * value;

            Values = scaledMatrix.Values;
        }

        /// <summary>
        /// Swaps matrix rows and columns.
        /// </summary>
        /// <returns>
        /// The transposed matrix.
        /// </returns>
        public SD_Matrix Transpose()
        {

            double[][] outArray = new double[RowCount][];

            if (IsSquare())
            {

                for (int i = 0; i < RowCount; i++)
                {
                    double[] column = new double[ColumnCount];

                    for (int j = 0; j < ColumnCount; j++)
                    {
                        column[j] = Values[j][i];
                    }

                    outArray[i] = column;

                }
            }
            else
            {
                throw new Exception("Transpose is only possible for square matrixes");
            }

            return new SD_Matrix(outArray);

        }

        /// <summary>
        /// Creates an zero matrix of specified size.
        /// </summary>
        /// <param name="rowCount"> (int) The number of rows of the matrix.</param>
        /// <param name="columnCount"> (int) The number of columns of the matrix.</param>
        /// <returns>
        /// The resultant zero matrix.
        /// </returns>
        public static SD_Matrix ZeroMatrix(int rowCount, int columnCount)
        {
            

            double[][] outArray = new double[rowCount][];


            for (int i = 0; i < rowCount; i++)
            {
                double[] column = new double[columnCount];

                for (int j = 0; j < columnCount; j++)
                {
                    column[j] = 0;
                }

                outArray[i] = column;

            }

            return new SD_Matrix(outArray);

        }

        /// <summary>
        /// Creates an identity matrix of specified size.
        /// </summary>
        /// <param name="rowCount"> (int) The number of rows of the matrix.</param>
        /// <param name="columnCount"> (int) The number of columns of the matrix.</param>
        /// <returns>
        /// The resultant identity matrix.
        /// </returns>
        public static SD_Matrix IdentityMatrix(int rowCount, int columnCount)
        {

            double[][] outArray = new double[rowCount][];


            for (int i = 0; i < rowCount; i++)
            {
                double[] column = new double[columnCount];

                for (int j = 0; j < columnCount; j++)
                {
                    if (i == j) { column[j] = 1; }
                    else { column[j] = 0; }


                }

                outArray[i] = column;

            }

            return new SD_Matrix(outArray);

        }

        /// <summary>
        /// Adds a range of values to a matrix.
        /// </summary>
        /// <param name="rowTuple"> (int) A tuple defining the row data and index.</param>
        /// <param name="columnTuple"> (int) A tuple defining the column data and index</param>
        /// /// <param name="otherMatrix"> (SD_Matrix) Matrix to add values to.</param>
        /// <returns>
        /// The updated matrix.
        /// </returns>
        public void AddRange(Tuple<int, int> rowTuple, Tuple<int, int> columnTuple, SD_Matrix otherMatrix)
        {

            if (otherMatrix.RowCount == rowTuple.Item2 - rowTuple.Item1 && otherMatrix.ColumnCount == columnTuple.Item2 - columnTuple.Item1)
            {

                for (int i = 0; i < otherMatrix.RowCount; i++)
                {
                    for (int j = 0; j < otherMatrix.ColumnCount; j++)
                    {
                        Values[rowTuple.Item1 + i][columnTuple.Item1 + j] = otherMatrix.Values[i][j];
                    }
                }

            }
            else
            {
                throw new Exception("Matrix size does not match row and column range");
            }


        }

        /// <summary>
        /// Gets a range of values to a matrix.
        /// </summary>
        /// <param name="rowTuple"> (int) A tuple defining the row data and index.</param>
        /// <param name="columnTuple"> (int) A tuple defining the column data and index</param>
        /// <returns>
        /// The data matrix.
        /// </returns>
        public SD_Matrix GetRange(Tuple<int, int> rowTuple, Tuple<int, int> columnTuple)
        {

            int rowCount = rowTuple.Item2 - rowTuple.Item1;
            int columnCount = columnTuple.Item2 - columnTuple.Item1;

            double[][] outArray = new double[rowCount][];


            for (int i = 0; i < rowCount; i++)
            {

                double[] column = new double[columnCount];

                for (int j = 0; j < columnCount; j++)
                {
                    column[j] = Values[rowTuple.Item1 + i][columnTuple.Item1 + j];
                }

                outArray[i] = column;

            }

            return new SD_Matrix(outArray);


        }

        /// <summary>
        /// Converts a matrix to an array.
        /// </summary>
        /// <returns>
        /// The 2 dimensionsal double array representing the matix.
        /// </returns>
        public double[][] ToArray()
        {
            return Values;
        }

        /// <summary>
        /// Removes a row from a matix.
        /// </summary>
        /// <param name="index"> (int) The index of the row to remove.</param>
        /// <returns>
        /// The updated matix.
        /// </returns>
        public void RemoveRow(int index)
        {
            double[][] outArray = new double[RowCount - 1][];

            for (int i = 0; i < RowCount; i++)
            {
                if (i < index)
                {
                    outArray[i] = Values[i];
                }
                else if (i > index)
                {
                    outArray[i - 1] = Values[i];
                }
            }

            Values = outArray;

        }

        /// <summary>
        /// Removes a column from a matix.
        /// </summary>
        /// <param name="index"> (int) The index of the column to remove.</param>
        /// <returns>
        /// The updated matix.
        /// </returns>
        public void RemoveColumn(int index)
        {
            double[][] outArray = new double[RowCount][];

            for (int i = 0; i < RowCount; i++)
            {

                double[] column = new double[ColumnCount - 1];

                for (int j = 0; j < ColumnCount; j++)
                {
                    if (j < index)
                    {
                        column[j] = Values[i][j];
                    }
                    else if (j > index)
                    {
                        column[j - 1] = Values[i][j];
                    }
                }

                outArray[i] = column;

            }

            Values = outArray;
        }


        //______________________________OPERATORS______________________________//

        public static SD_Matrix operator +(SD_Matrix left, SD_Matrix right)
        {
            double[][] outArray = new double[left.RowCount][];

            if (left.IsSameSize(right))
            {
                for (int i = 0; i < left.RowCount; i++)
                {
                    double[] column = new double[left.ColumnCount];

                    for (int j = 0; j < left.ColumnCount; j++)
                    {
                        column[j] = left.Values[i][j] + right.Values[i][j];
                    }

                    outArray[i] = column;

                }

            }
            else
            {
                throw new Exception("Addition is not possible for matrixes of different sizes");
            }

            return new SD_Matrix(outArray);
        }

        public static SD_Matrix operator -(SD_Matrix left, SD_Matrix right)
        {
            double[][] outArray = new double[left.RowCount][];

            if (left.IsSameSize(right))
            {
                for (int i = 0; i < left.RowCount; i++)
                {
                    double[] column = new double[left.ColumnCount];

                    for (int j = 0; j < left.ColumnCount; j++)
                    {
                        column[j] = left.Values[i][j] - right.Values[i][j];
                    }

                    outArray[i] = column;

                }

            }
            else
            {
                throw new Exception("Subtraction is not possible for matrixes of different sizes");
            }

            return new SD_Matrix(outArray);
        }

        public static SD_Matrix operator *(SD_Matrix left, double right)
        {

            double[][] outArray = new double[left.RowCount][];


            for (int i = 0; i < left.RowCount; i++)
            {
                double[] column = new double[left.ColumnCount];

                for (int j = 0; j < left.ColumnCount; j++)
                {
                    column[j] = left.Values[i][j] * right;
                }

                outArray[i] = column;

            }



            return new SD_Matrix(outArray);
        }


        public static SD_Matrix operator *(SD_Matrix left, SD_Matrix right)
        {
            double[][] outArray = new double[left.RowCount][];

            if (left.ColumnCount == right.RowCount)
            {
                for (int i = 0; i < left.RowCount; i++)
                {
                    double[] column = new double[right.ColumnCount];

                    for (int j = 0; j < right.ColumnCount; j++)
                    {

                        double value = 0;

                        for (int k = 0; k < left.ColumnCount; k++)
                        {
                            value += left.Values[i][k] * right.Values[k][j];
                        }

                        column[j] = value;
                    }

                    outArray[i] = column;

                }

            }
            else
            {
                throw new Exception("Multiplication is not possible for matrixes of non corresponding row and column lengths");
            }

            return new SD_Matrix(outArray);
        }






    }



}
