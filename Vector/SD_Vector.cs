using System;
using SD_Model.Geometry;


namespace SD_Model.Vector
{
    /// <summary>
    /// Vector object
    /// </summary>
    /// <param name="test"></param>
    /// <returns></returns>
    public class SD_Vector
    {


        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public SD_Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public SD_Vector(double value)
        {
            X = value;
            Y = value;
            Z = value;
        }




        public SD_Vector(string vectorString)
        {
            try
            {

                vectorString = vectorString.Replace("{", "").Replace("}", "");

                string[] stringList = vectorString.Split(",");

                if (stringList.Length == 3)
                {
                    X = Convert.ToDouble(stringList[0]);
                    Y = Convert.ToDouble(stringList[1]);
                    Z = Convert.ToDouble(stringList[2]);
                }

            }
            catch
            {

                throw new InvalidOperationException("Incorrect string format");

            }
        }





        public SD_Vector(SD_Point point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }


        public SD_Vector(double[] arr)
        {
            X = arr[0];
            Y = arr[1];
            Z = arr[2];
        }


        public override string ToString()
        {
            return "{" + X + ", " + Y + ", " + Z + "}";
        }

        public double[] ToArray()
        {
            return new double[] { X, Y, Z };
        }

        public SD_Point ToPoint()
        {
            return new SD_Point(X, Y, Z); ;
        }


        public SD_Vector UpdateFromArray(double[] arr)
        {
            if (arr.Length < 3) throw new Exception("Array is too small. A minimum of 3 characters is required.");
            else
            {
                X = arr[0];
                Y = arr[1];
                Z = arr[2];
            }
            return this;
        }


        public bool Equals(SD_Vector other)
        {

            bool result = X == other.X && Y == other.Y && Z == other.Z;

            return result;
        }


        public bool Equals(SD_Vector other, int tolerance)
        {

            bool result = Math.Round(X, tolerance) == Math.Round(other.X, tolerance) && Math.Round(Y, tolerance) == Math.Round(other.Y, tolerance) && Math.Round(Z, tolerance) == Math.Round(other.Z, tolerance);

            return result;

        }

        public double Magnitude()
        {

            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));

        }

        public SD_Vector Reverse()
        {

            return new SD_Vector(X * -1, Y * -1, Z * -1);

        }

        public SD_Vector Unit()
        {

            return new SD_Vector(X / Magnitude(), Y / Magnitude(), Z / Magnitude());

        }


        public SD_Vector Amplitude(double length)
        {

            return Unit() * length;

        }

        public SD_Vector Cosines()
        {



            /// <summary>Returns the directional cosines for a vector</summary>

            return new SD_Vector(X / Magnitude(), Y / Magnitude(), Z / Magnitude());

        }

        public SD_Vector Project(SD_Vector other)
        {


            /// <summary>Returns the component of a vector when Projected onto another vector</summary>

            return other.Amplitude(DotProduct(this, other.Unit()) / other.Unit().Magnitude());

        }

        public bool IsParallel(SD_Vector other)
        {

            /// <summary>Checks whether vector is parallel to other vector</summary>

            return CrossProduct(this, other).Magnitude() == 0;

        }

        public bool IsOrthogonal(SD_Vector other)
        {

            return DotProduct(this, other) == 0;

        }

        public SD_Vector Inverse()
        {

            double invX = 0;
            double invY = 0;
            double invZ = 0;

            if (X != 0)
            {
                invX = X * -1;
            }

            if (Y != 0)
            {
                invX = Y * -1;
            }

            if (Z != 0)
            {
                invX = Z * -1;
            }

            SD_Vector invVector = new SD_Vector(invX, invY, invZ);

            return invVector;

        }

        //______________________________STATIC CLASSES______________________________//


        public static double DotProduct(SD_Vector vector1, SD_Vector vector2)
        {

            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;

        }

        public static SD_Vector CrossProduct(SD_Vector vector1, SD_Vector vector2)
        {

            double x = vector1.Y * vector2.Z - vector1.Z * vector2.Y;
            double y = vector1.Z * vector2.X - vector1.X * vector2.Z;
            double z = vector1.X * vector2.Y - vector1.Y * vector2.X;

            return new SD_Vector(x, y, z);

        }

        public static double Angle(SD_Vector vector1, SD_Vector vector2, SD_Plane NOTIMPLEMENTED)
        {

            return Math.Acos(DotProduct(vector1, vector2) / (vector1.Magnitude() * vector2.Magnitude()));

        }

        public static double TriangularArea(SD_Vector vector1, SD_Vector vector2)
        {

            return CrossProduct(vector1, vector2).Magnitude() / 2;
        }



        public static SD_Vector Subtract(SD_Vector vector1, SD_Vector vector2)
        {

            return new SD_Vector(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);

        }


        public static SD_Vector Add(SD_Vector vector1, SD_Vector vector2)
        {

            return new SD_Vector(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);

        }

        public static bool Coplanar(SD_Vector vector1, SD_Vector vector2, SD_Vector vector3)
        {

            return DotProduct(vector1, CrossProduct(vector2, vector3)) == 0;

        }

        public static SD_Vector GramSchmit(SD_Vector vector1, SD_Vector vector2)
        {
            /// <summary>Creates an orthogonal vector to the first vector in a plane defined by both vectors</summary>

            return vector2 - DotProduct(vector2, vector1) * vector1;

        }


        public static SD_Vector UnitX()
        {

            return new SD_Vector(1, 0, 0);

        }

        public static SD_Vector UnitY()
        {

            return new SD_Vector(0, 1, 0);

        }

        public static SD_Vector UnitZ()
        {

            return new SD_Vector(0, 0, 1);

        }

        //______________________________OPERATORS______________________________//

        public static SD_Vector operator +(SD_Vector left, double value)
        {

            double x = left.X + value;
            double y = left.Y + value;
            double z = left.Z + value;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator +(double value, SD_Vector left)
        {

            double x = left.X + value;
            double y = left.Y + value;
            double z = left.Z + value;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator +(SD_Vector left, SD_Vector right)
        {

            double x = left.X + right.X;
            double y = left.Y + right.Y;
            double z = left.Z + right.Z;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator +(SD_Vector left, SD_Point right)
        {

            double x = left.X + right.X;
            double y = left.Y + right.Y;
            double z = left.Z + right.Z;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator -(SD_Vector left)
        {
            left.X = -left.X;
            left.Y = -left.Y;
            left.Z = -left.Z;
            return left;
        }

        public static SD_Vector operator -(SD_Vector left, double value)
        {
            double x = left.X - value;
            double y = left.Y - value;
            double z = left.Z - value;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator -(double value, SD_Vector left)
        {
            double x = value - left.X;
            double y = value - left.Y;
            double z = value - left.Z;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator -(SD_Vector left, SD_Vector right)
        {
            double x = left.X - right.X;
            double y = left.Y - right.Y;
            double z = left.Z - right.Z;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator -(SD_Vector left, SD_Point right)
        {
            double x = left.X - right.X;
            double y = left.Y - right.Y;
            double z = left.Z - right.Z;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator /(SD_Vector left, double value)
        {
            double x = left.X / value;
            double y = left.Y / value;
            double z = left.Z / value;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator /(double value, SD_Vector left)
        {
            double x = value / left.X;
            double y = value / left.Y;
            double z = value / left.Z;

            return new SD_Vector(x, y, z);
        }



        public static SD_Vector operator /(SD_Vector left, SD_Vector right)
        {
            double x = left.X / right.X;
            double y = left.Y / right.Y;
            double z = left.Z / right.Z;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator /(SD_Vector left, SD_Point right)
        {
            double x = left.X / right.X;
            double y = left.Y / right.Y;
            double z = left.Z / right.Z;

            return new SD_Vector(x, y, z);
        }

        //CLEAN NEGATIVE ZEROS!!
        public static SD_Vector operator *(SD_Vector left, double value)
        {
            double x = left.X * value;
            double y = left.Y * value;
            double z = left.Z * value;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator *(double value, SD_Vector left)
        {
            double x = left.X * value;
            double y = left.Y * value;
            double z = left.Z * value;

            return new SD_Vector(x, y, z);
        }


        public static SD_Vector operator *(SD_Vector left, SD_Vector right)
        {
            double x = left.X * right.X;
            double y = left.Y * right.Y;
            double z = left.Z * right.Z;

            return new SD_Vector(x, y, z);
        }

        public static SD_Vector operator *(SD_Vector left, SD_Point right)
        {
            double x = left.X * right.X;
            double y = left.Y * right.Y;
            double z = left.Z * right.Z;

            return new SD_Vector(x, y, z);
        }




    }
}

