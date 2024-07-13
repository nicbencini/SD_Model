using System;
using SD_Model.Geometry;


namespace SD_Model.Vector
{
    /// <summary>
    /// <c>SD_Plane</c> 
    /// Class for creating a 3D plane.
    /// </summary>
    public class SD_Vector
    {


        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        /// <summary>
        /// Returns a 3D vector from a 3 doubles.
        /// </summary>
        /// <param name="x"> (double) The value for the x coordinate of the vector.</param>
        /// <param name="y"> (double) The value for the y coordinate of the vector.</param>
        /// <param name="z"> (double) The value for the z coordinate of the vector.</param>
        /// <returns>
        /// A 3D vector.
        /// </returns>
        public SD_Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Returns a 3D vector from a double.
        /// </summary>
        /// <param name="value"> (double) The value for the x,y and z coordinate of the vector.</param>
        /// <returns>
        /// A 3D vector.
        /// </returns>
        public SD_Vector(double value)
        {
            X = value;
            Y = value;
            Z = value;
        }


        /// <summary>
        /// Returns a 3D vector from a string.
        /// </summary>
        /// <param name="vectorString"> (string) A string with the cooridnate information for the vector.</param>
        /// <returns>
        /// A 3D vector.
        /// </returns>

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


        /// <summary>
        /// Returns a 3d vector from a point.
        /// </summary>
        /// <param name="point"> (SD_Point) A point from which to construct the vector.</param>
        /// <returns>
        /// A 3d vector.
        /// </returns>
        public SD_Vector(SD_Point point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        /// <summary>
        /// Returns a 3d vector from a double array.
        /// </summary>
        /// <param name="arr"> (double []) A double array defining the coordinates of the 3d vector.</param>
        /// <returns>
        /// A 3d vector.
        /// </returns>
        public SD_Vector(double[] arr)
        {
            X = arr[0];
            Y = arr[1];
            Z = arr[2];
        }

        /// <summary>
        /// Returns a string representing the 3d vector.
        /// </summary>
        /// <returns>
        /// A string representing the 3d vector.
        /// </returns>
        public override string ToString()
        {
            return "{" + X + ", " + Y + ", " + Z + "}";
        }

        /// <summary>
        /// Returns an array representing the 3d vector.
        /// </summary>
        /// <returns>
        /// An array representing the 3d vector.
        /// </returns>
        public double[] ToArray()
        {
            return new double[] { X, Y, Z };
        }

        /// <summary>
        /// Converts the 3d vector to a point.
        /// </summary>
        /// <returns>
        /// A point representing the 3d vector.
        /// </returns>
        public SD_Point ToPoint()
        {
            return new SD_Point(X, Y, Z); ;
        }

        /// <summary>
        /// Updates the vector coordinates from an array.
        /// </summary>
        /// <param name="arr"> (double []) A double array defining the coordinates of the 3d vector.</param>
        /// <returns>
        /// The updated vector.
        /// </returns>
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

        /// <summary>
        /// Checks whether a vector is equal to another vector.
        /// </summary>
        /// <param name="other"> (SD_Vector) The vector to check against.</param>
        /// <returns>
        /// Retruns 'true' if the vectors are equal.
        /// </returns>
        public bool Equals(SD_Vector other)
        {

            bool result = X == other.X && Y == other.Y && Z == other.Z;

            return result;
        }

        /// <summary>
        /// Checks whether a vector is equal to another vector within a given tolerance.
        /// </summary>
        /// <param name="other"> (SD_Vector) The vector to check against.</param>
        /// <param name="tolerance"> (double) The tolerance between the 2 vectors.</param>
        /// <returns>
        /// Retruns 'true' if the vectors are equal.
        /// </returns>
        public bool Equals(SD_Vector other, int tolerance)
        {

            bool result = Math.Round(X, tolerance) == Math.Round(other.X, tolerance) && Math.Round(Y, tolerance) == Math.Round(other.Y, tolerance) && Math.Round(Z, tolerance) == Math.Round(other.Z, tolerance);

            return result;

        }

        /// <summary>
        /// Returns the magnitude of the vector.
        /// </summary>
        /// <returns>
        /// The magnitude of the vector.
        /// </returns>
        public double Magnitude()
        {

            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));

        }

        /// <summary>
        /// Returns the reverse of the vector.
        /// </summary>
        /// <returns>
        /// The reverse of the vector.
        /// </returns>
        public SD_Vector Reverse()
        {

            return new SD_Vector(X * -1, Y * -1, Z * -1);

        }

        /// <summary>
        /// Returns a unit vector of the current vector.
        /// </summary>
        /// <returns>
        /// The unit vector.
        /// </returns>
        public SD_Vector Unit()
        {

            return new SD_Vector(X / Magnitude(), Y / Magnitude(), Z / Magnitude());

        }

        /// <summary>
        /// Sets the legnth of the vector to a given amplitude.
        /// </summary>
        /// <param name="length"> (double) The amplitude of the vector.</param>
        /// <returns>
        /// The updated vector.
        /// </returns>
        public SD_Vector Amplitude(double length)
        {

            return Unit() * length;

        }

        /// <summary>
        /// Returns the cosines of the vector.
        /// </summary>
        /// <returns>
        /// The cosines of the vector.
        /// </returns>
        public SD_Vector Cosines()
        {



            /// <summary>Returns the directional cosines for a vector</summary>

            return new SD_Vector(X / Magnitude(), Y / Magnitude(), Z / Magnitude());

        }

        /// <summary>
        /// Returns the component of a vector when Projected onto another vector.
        /// </summary>
        /// <param name="other"> (SD_Vector) The vector to project onto.</param>
        /// <returns>
        /// The projected vector.
        /// </returns>
        public SD_Vector Project(SD_Vector other)
        {

            return other.Amplitude(DotProduct(this, other.Unit()) / other.Unit().Magnitude());

        }

        /// <summary>
        /// Checks whether the vector is parallel to another vector.
        /// </summary>
        /// <param name="other"> (SD_Vector) The vector to check agaisnt.</param>
        /// <returns>
        /// Returns 'true' if the vectors are parallel.
        /// </returns>
        public bool IsParallel(SD_Vector other)
        {

            return CrossProduct(this, other).Magnitude() == 0;

        }

        /// <summary>
        /// Checks whether the vector is orthogonal to another vector.
        /// </summary>
        /// <param name="other"> (SD_Vector) The vector to check agaisnt.</param>
        /// <returns>
        /// Returns 'true' if the vectors are orthogonal.
        /// </returns>
        public bool IsOrthogonal(SD_Vector other)
        {

            return DotProduct(this, other) == 0;

        }

        /// <summary>
        /// Returns the inverse of the vector.
        /// </summary>
        /// <returns>
        /// The inverse of the vector.
        /// </returns>
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


        /// <summary>
        /// Calculates the dot product between 2 vectors.
        /// </summary>
        /// <param name="vector1"> (SD_Vector) The first vector.</param>
        /// <param name="vector2"> (SD_Vector) The second vector.</param>
        /// <returns>
        /// The dot product of both vectors.
        /// </returns>
        public static double DotProduct(SD_Vector vector1, SD_Vector vector2)
        {

            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;

        }

        /// <summary>
        /// Calculates the cross product between 2 vectors.
        /// </summary>
        /// <param name="vector1"> (SD_Vector) The first vector.</param>
        /// <param name="vector2"> (SD_Vector) The second vector.</param>
        /// <returns>
        /// The cross product of both vectors.
        /// </returns>
        public static SD_Vector CrossProduct(SD_Vector vector1, SD_Vector vector2)
        {

            double x = vector1.Y * vector2.Z - vector1.Z * vector2.Y;
            double y = vector1.Z * vector2.X - vector1.X * vector2.Z;
            double z = vector1.X * vector2.Y - vector1.Y * vector2.X;

            return new SD_Vector(x, y, z);

        }

        /// <summary>
        /// Calculates the angle between 2 vectors.
        /// </summary>
        /// <param name="vector1"> (SD_Vector) The first vector.</param>
        /// <param name="vector2"> (SD_Vector) The second vector.</param>
        /// <returns>
        /// The angle between the vectors.
        /// </returns>
        public static double Angle(SD_Vector vector1, SD_Vector vector2)
        {

            return Math.Acos(DotProduct(vector1, vector2) / (vector1.Magnitude() * vector2.Magnitude()));

        }

        /// <summary>
        /// Calculates the triangular area between 2 vectors.
        /// </summary>
        /// <param name="vector1"> (SD_Vector) The first vector.</param>
        /// <param name="vector2"> (SD_Vector) The second vector.</param>
        /// <returns>
        /// The triangular area between the vectors.
        /// </returns>
        public static double TriangularArea(SD_Vector vector1, SD_Vector vector2)
        {

            return CrossProduct(vector1, vector2).Magnitude() / 2;
        }


        /// <summary>
        /// Subtracts 2 vectors.
        /// </summary>
        /// <param name="vector1"> (SD_Vector) The first vector.</param>
        /// <param name="vector2"> (SD_Vector) The second vector.</param>
        /// <returns>
        /// The resultant vector.
        /// </returns>
        public static SD_Vector Subtract(SD_Vector vector1, SD_Vector vector2)
        {

            return new SD_Vector(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);

        }

        /// <summary>
        /// Adds 2 vectors.
        /// </summary>
        /// <param name="vector1"> (SD_Vector) The first vector.</param>
        /// <param name="vector2"> (SD_Vector) The second vector.</param>
        /// <returns>
        /// The resultant vector.
        /// </returns>
        public static SD_Vector Add(SD_Vector vector1, SD_Vector vector2)
        {

            return new SD_Vector(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);

        }

        /// <summary>
        /// Checks whether 3 vectors are coplanar.
        /// </summary>
        /// <param name="vector1"> (SD_Vector) The first vector.</param>
        /// <param name="vector2"> (SD_Vector) The second vector.</param>
        /// <param name="vector3"> (SD_Vector) The third vector.</param>
        /// <returns>
        /// Returns 'true' if the vectors are coplanar.
        /// </returns>
        public static bool Coplanar(SD_Vector vector1, SD_Vector vector2, SD_Vector vector3)
        {

            return DotProduct(vector1, CrossProduct(vector2, vector3)) == 0;

        }

        /// <summary>
        /// Creates an orthogonal vector to the first vector in a plane defined by both vectors.
        /// </summary>
        /// <param name="vector1"> (SD_Vector) The first vector.</param>
        /// <param name="vector2"> (SD_Vector) The second vector.</param>
        /// <returns>
        /// Resultant orthogonal vector.
        /// </returns>
        public static SD_Vector GramSchmit(SD_Vector vector1, SD_Vector vector2)
        {

            return vector2 - DotProduct(vector2, vector1) * vector1;

        }

        /// <summary>
        /// Creates a unit vector in the x-direction.
        /// </summary>
        /// <returns>
        /// Unit vector aligned with the global x-axis.
        /// </returns>
        public static SD_Vector UnitX()
        {

            return new SD_Vector(1, 0, 0);

        }

        /// <summary>
        /// Creates a unit vector in the y-direction.
        /// </summary>
        /// <returns>
        /// Unit vector aligned with the global y-axis.
        /// </returns>
        public static SD_Vector UnitY()
        {

            return new SD_Vector(0, 1, 0);

        }


        /// <summary>
        /// Creates a unit vector in the z-direction.
        /// </summary>
        /// <returns>
        /// Unit vector aligned with the global z-axis.
        /// </returns>
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

