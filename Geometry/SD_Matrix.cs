using System;


namespace SD_Vector.Geometry
{
    public class SD_Matrix
    {

        public double[][] Values { get; set; }

        public int RowCount { get; set; } // Rows are horizontal

        public int ColumnCount { get; set; } // Cols are vertical


        public SD_Matrix(double[][] matrix)
        {

            /// <summary>Create matrix from array of arrays</summary>

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


        public bool IsSquare()
        {
            /// <summary>Checks whether matrix column length and row length are the same</summary>

            bool result = false;

            if(this.RowCount == this.ColumnCount)
            {
                result = true;
            }

            return result;

        }


        public bool Equals (SD_Matrix other)
        {
            /// <summary>Checks whether matrix is equal to other matrix</summary>
            
            bool result = false;

            if((this.RowCount == other.RowCount)&& (this.ColumnCount == other.ColumnCount))
            {
                for (int i = 0; i < this.RowCount; i++)
                {
                    if (this.Values[i] == other.Values[i])
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

        public bool IsSameSize(SD_Matrix other)
        {

            /// <summary>Checks whether matrix is same size to other matrix</summary>
            
            bool result = false;

            if ((this.RowCount == other.RowCount) && (this.ColumnCount == other.ColumnCount))
            {
                result = true;
            }

            return result;
        }

        public void Scale(double value)
        {
            /// <summary>Scales a matrix by a value</summary>

            SD_Matrix scaledMatrix = this * value;

            this.Values = scaledMatrix.Values;
        }

        public SD_Matrix Transpose()
        {
            /// <summary>Swaps matrix rows and columns</summary>
            
            double[][] outArray = new double[this.RowCount][];

            if (this.IsSquare())
            {

                for (int i = 0; i < this.RowCount; i++)
                {
                    double[] column = new double[this.ColumnCount];

                    for (int j = 0; j < this.ColumnCount; j++)
                    {
                        column[j] = this.Values[j][i];
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

        public static SD_Matrix ZeroMatrix(int rowCount, int columnCount)
        {
            /// <summary>Creates an zero matrix of specified size</summary>

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

        public static SD_Matrix IdentityMatrix(int rowCount, int columnCount)
        {
            /// <summary>Creates an identity matrix of specified size</summary>

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

        public void AddRange(Tuple<int, int> rowTuple, Tuple<int, int> columnTuple, SD_Matrix otherMatrix)
        {
            
            
            
            if((otherMatrix.RowCount == rowTuple.Item2 - rowTuple.Item1) && (otherMatrix.ColumnCount == columnTuple.Item2 - columnTuple.Item1))
            {

                for (int i = 0; i < otherMatrix.RowCount; i++)
                {
                    for (int j = 0; j < otherMatrix.ColumnCount; j++)
                    {
                        this.Values[rowTuple.Item1 + i][columnTuple.Item1 + j] = otherMatrix.Values[i][j];
                    }
                }

            }
            else
            {
                throw new Exception("Matrix size does not match row and column range");
            }


        }

        public SD_Matrix GetRange(Tuple<int, int> rowTuple, Tuple<int, int> columnTuple)
        {

            int rowCount = rowTuple.Item2 - rowTuple.Item1;
            int columnCount = columnTuple.Item2 - columnTuple.Item1;

            double[][] outArray = new double[rowCount][];


            for (int i = 0; i < (rowCount); i++)
            {

                double[] column = new double[columnCount];

                for (int j = 0; j < (columnCount); j++)
                {
                    column[j] = this.Values[rowTuple.Item1 + i][columnTuple.Item1 + j];
                }

                outArray[i] = column;
                
            }

            return new SD_Matrix(outArray);


        }

        public double[][] ToArray()
        {
            return this.Values;
        }

        public void RemoveRow(int index)
        {
            double[][] outArray = new double[this.RowCount -1 ][];

            for (int i = 0; i < (RowCount); i++)
            {
                if (i < index)
                {
                    outArray[i] = this.Values[i];
                }
                else if(i> index)
                {
                    outArray[i-1] = this.Values[i];
                }
            }

            this.Values = outArray;

        }

        
        public void RemoveColumn(int index)
        {
            double[][] outArray = new double[this.RowCount][];

            for (int i = 0; i < (RowCount); i++)
            {

                double[] column = new double[ColumnCount - 1];

                for (int j = 0; j < ColumnCount; j++)
                {
                    if (j < index)
                    {
                        column[j] = this.Values[i][j];
                    }
                    else if (j > index)
                    {
                        column[j-1] = this.Values[i][j];
                    }
                }

                outArray[i] = column;
                
            }

            this.Values = outArray;
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
                        
                        for (int k= 0; k < left.ColumnCount; k++)
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
