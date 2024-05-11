using System;
using System.Collections.Generic;


namespace SD_Vector.Geometry
{

    public class SD_Point 
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Z { get; set; }


        public SD_Point(double value)
        {
            X = value;
            Y = value;
            Z = value;

        }

        public SD_Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;

        }


        public SD_Point(SD_Point SD_Point)
        {
            X = SD_Point.X;
            Y = SD_Point.Y;
            Z = SD_Point.Z;

        }

        public SD_Point(SD_Vector vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;

        }

        public SD_Point(double[] arr)
        {
            X = arr[0];
            Y = arr[1];
            Z = arr[2];


        }

        public SD_Point(double[] arr, int startIndex)
        {
            if (startIndex > arr.Length - 3) { throw new Exception("start index doesnt leave enough space to fill all vector parameters"); }
            else
            {
                X = arr[startIndex];
                Y = arr[startIndex + 1];
                Z = arr[startIndex + 2];

            }


        }


        public override string ToString()
        {
            return "{" + X + ", " + Y + ", " + Z + "}";
        }

        public double[] ToArray()
        {
            return new double[] { X, Y, Z };
        }



        public SD_Point UpdateFromArray(double[] arr)
        {
            if (arr.Length < 3) throw new Exception("Array is too small to convert to vector");
            else
            {
                X = arr[0];
                Y = arr[1];
                Z = arr[2];

            }


            return this;
        }

        public SD_Point UpdateFromArray(double[] arr, int startIndex)
        {
            if (startIndex + 2 > arr.Length - 1) throw new Exception("startindex is too high to fill vector");
            else
            {
                X = arr[startIndex];
                Y = arr[startIndex + 1];
                Z = arr[startIndex + 2];

            }

            return this;
        }


        public bool Equals(SD_Point other)
        {
            throw new NotImplementedException();
        }

        public double Distance(SD_Point other)
        {
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2) + Math.Pow(Z - other.Z, 2));
        }



        public SD_Vector ToVector()
        {



            return new SD_Vector(X, Y, Z);


        }

        public SD_Vector VectorToPoint(SD_Point other)
        {

            return ToVector() - other.ToVector();

        }

        public bool Planar4Points(SD_Point point1, SD_Point point2, SD_Point point3, SD_Point point4)
        {

            SD_Vector vec1 = point2.ToVector() - point1.ToVector();
            SD_Vector vec2 = point3.ToVector() - point1.ToVector();
            SD_Vector vec3 = point4.ToVector() - point1.ToVector();

            return SD_Vector.Coplanar(vec1, vec2, vec3);
        }

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


