using System;
using System.Collections.Generic;
using SD_Model.Vector;


namespace SD_Model.Geometry
{
    /// <summary>
    /// <c>SD_Point</c> 
    /// Class for creating a 3D point.
    /// </summary>
    public class SD_Point 
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        /// <summary>
        /// Returns a 3D point from a double.
        /// </summary>
        /// <param name="value"> (double) The value for the x,y and z coordinate of the point.</param>
        /// <returns>
        /// A 3D point in space.
        /// </returns>
        public SD_Point(double value)
        {
            X = value;
            Y = value;
            Z = value;

        }

        /// <summary>
        /// Returns a 3D point from a 3 doubles.
        /// </summary>
        /// <param name="x"> (double) The value for the x coordinate of the point.</param>
        /// <param name="y"> (double) The value for the y coordinate of the point.</param>
        /// <param name="z"> (double) The value for the z coordinate of the point.</param>
        /// <returns>
        /// A 3D point in space.
        /// </returns>
        public SD_Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;

        }

        /// <summary>
        /// Returns a 3D point from vector.
        /// </summary>
        /// <param name="vector"> (SD_Vector) A vector from which to generate the point.</param>
        /// <returns>
        /// A 3D point in space.
        /// </returns>

        public SD_Point(SD_Vector vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;

        }

        /// <summary>
        /// Returns a 3D point from an array.
        /// </summary>
        /// <param name="arr"> (double[]) A array containing the x,y and z coordinates.</param>
        /// <returns>
        /// A 3d point in space.
        /// </returns>
        public SD_Point(double[] arr)
        {
            X = arr[0];
            Y = arr[1];
            Z = arr[2];


        }

        /// <summary>
        /// Returns a string representing the point.
        /// </summary>
        /// <returns>
        /// A string representing the 3d point.
        /// </returns>
        public override string ToString()
        {
            return "{" + X + ", " + Y + ", " + Z + "}";
        }

        /// <summary>
        /// Returns an array representing the point.
        /// </summary>
        /// <returns>
        /// An array representing the 3d point.
        /// </returns>
        public double[] ToArray()
        {
            return new double[] { X, Y, Z };
        }

        /// <summary>
        /// Updates a points coordinates from an array.
        /// </summary>
        /// <returns>
        /// A 3d point in space.
        /// </returns>
        public SD_Point UpdateFromArray(double[] arr)
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
        /// Calculates the distance between 2 points.
        /// </summary>
        /// <param name="other"> (SD_Point) The point to compare against.</param>
        /// <returns>
        /// The distance between the 2 points.
        /// </returns>

        public double Distance(SD_Point other)
        {
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2) + Math.Pow(Z - other.Z, 2));
        }


        /// <summary>
        /// Converts the point to a vector.
        /// </summary>
        /// <returns>
        /// The vector generated from the point.
        /// </returns>
        public SD_Vector ToVector()
        {

            return new SD_Vector(X, Y, Z);
        }

        /// <summary>
        /// Checks whether 4 points lie within the same plane.
        /// </summary>
        /// <param name="point1"> (SD_Point) The point to check.</param>
        /// <param name="point2"> (SD_Point) The point to check.</param>
        /// <param name="point3"> (SD_Point) The point to check.</param>
        /// <param name="point4"> (SD_Point) The point to check.</param>
        /// <returns>
        /// 'True' if the points lie on the same plane.
        /// </returns>
        public bool Planar4Points(SD_Point point1, SD_Point point2, SD_Point point3, SD_Point point4)
        {

            SD_Vector vec1 = point2.ToVector() - point1.ToVector();
            SD_Vector vec2 = point3.ToVector() - point1.ToVector();
            SD_Vector vec3 = point4.ToVector() - point1.ToVector();

            return SD_Vector.Coplanar(vec1, vec2, vec3);
        }

        /// <summary>
        /// Calcualtes the area of a triangle defined by 3 points.
        /// </summary>
        /// <param name="point1"> (SD_Point) The point to check.</param>
        /// <param name="point2"> (SD_Point) The point to check.</param>
        /// <param name="point3"> (SD_Point) The point to check.</param>
        /// <returns>
        /// Area between the points.
        /// </returns>
        public double Area3Points(SD_Point point1, SD_Point point2, SD_Point point3)
        {

            SD_Vector vec1 = point2.ToVector() - point1.ToVector();
            SD_Vector vec2 = point3.ToVector() - point1.ToVector();

            return SD_Vector.TriangularArea(vec1, vec2);

        }


        public static SD_Point Average(List<SD_Point> pointList)
        {

            SD_Point point = new SD_Point(0, 0, 0);
            int count = 0;

            for (var i = 0; i < pointList.Count; i++)
            {

                point += pointList[i];
                count++;

            }

            return point / count;

        }

        /// <summary>
        /// Moves a point by a given translation.
        /// </summary>
        /// <param name="translation"> (SD_Vector) The translation vector of the point.</param>
        /// <returns>
        /// The moved point.
        /// </returns>
        public SD_Point Move(SD_Vector translation)
        {
            return this + translation;
        }



      
        //______________________________OPERATORS______________________________//

        public static SD_Point operator +(SD_Point left, double value)
        {

            double x = left.X + value;
            double y = left.Y + value;
            double z = left.Z + value;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator +(double value, SD_Point left)
        {

            double x = left.X + value;
            double y = left.Y + value;
            double z = left.Z + value;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator +(SD_Point left, SD_Point right)
        {

            double x = left.X + right.X;
            double y = left.Y + right.Y;
            double z = left.Z + right.Z;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator +(SD_Point left, SD_Vector right)
        {

            double x = left.X + right.X;
            double y = left.Y + right.Y;
            double z = left.Z + right.Z;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator -(SD_Point left)
        {
            left.X = -left.X;
            left.Y = -left.Y;
            left.Z = -left.Z;
            return left;
        }

        public static SD_Point operator -(SD_Point left, double value)
        {
            double x = left.X - value;
            double y = left.Y - value;
            double z = left.Z - value;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator -(double value, SD_Point left)
        {
            double x = value - left.X;
            double y = value - left.Y;
            double z = value - left.Z;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator -(SD_Point left, SD_Point right)
        {
            double x = left.X - right.X;
            double y = left.Y - right.Y;
            double z = left.Z - right.Z;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator -(SD_Point left, SD_Vector right)
        {
            double x = left.X - right.X;
            double y = left.Y - right.Y;
            double z = left.Z - right.Z;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator /(SD_Point left, double value)
        {
            double x = left.X / value;
            double y = left.Y / value;
            double z = left.Z / value;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator /(double value, SD_Point left)
        {
            double x = value / left.X;
            double y = value / left.Y;
            double z = value / left.Z;

            return new SD_Point(x, y, z);
        }



        public static SD_Point operator /(SD_Point left, SD_Point right)
        {
            double x = left.X / right.X;
            double y = left.Y / right.Y;
            double z = left.Z / right.Z;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator /(SD_Point left, SD_Vector right)
        {
            double x = left.X / right.X;
            double y = left.Y / right.Y;
            double z = left.Z / right.Z;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator *(SD_Point left, double value)
        {
            double x = left.X * value;
            double y = left.Y * value;
            double z = left.Z * value;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator *(double value, SD_Point left)
        {
            double x = left.X * value;
            double y = left.Y * value;
            double z = left.Z * value;

            return new SD_Point(x, y, z);
        }


        public static SD_Point operator *(SD_Point left, SD_Point right)
        {
            double x = left.X * right.X;
            double y = left.Y * right.Y;
            double z = left.Z * right.Z;

            return new SD_Point(x, y, z);
        }

        public static SD_Point operator *(SD_Point left, SD_Vector right)
        {
            double x = left.X * right.X;
            double y = left.Y * right.Y;
            double z = left.Z * right.Z;

            return new SD_Point(x, y, z);
        }


    }
}


