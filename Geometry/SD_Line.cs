
using System;
using System.Collections.Generic;
using SD_Model.Vector;

namespace SD_Model.Geometry
{

    /// <summary>
    /// <c>SD_Line</c> 
    /// Class for creating a 3D line.
    /// </summary>

    public class SD_Line 
    {
        public SD_Point StartPoint { get; set; }
        public SD_Point EndPoint { get; set; }

        // Cartesian equation of a line defined by StPt + t (endPt - StPt)

        internal double _x(double t)
        {
            return StartPoint.X + (EndPoint.X - StartPoint.X) * t;

        }
        internal double _y(double t)
        {
            return StartPoint.Y + (EndPoint.Y - StartPoint.Y) * t;
        }
        internal double _z(double t)
        {
            return StartPoint.Z + (EndPoint.Z - StartPoint.Z) * t;
        }

        /// <summary>
        /// Returns a 3D line from 2 points.
        /// </summary>
        /// <param name="pt1"> (SD_Point) The start point of the line.</param>
        /// <param name="pt2"> (SD_Point) The end point of the line.</param>
        /// <returns>
        /// A line in 3D space connecting the 2 points.
        /// </returns>
        public SD_Line(SD_Point pt1, SD_Point pt2)
        {

            StartPoint = pt1;
            EndPoint = pt2;


        }

        /// <summary>
        /// Returns a 3D line from a point and a vector.
        /// </summary>
        /// <param name="pt1"> (SD_Point) The start point of the line.</param>
        /// <param name="vec1"> (SD_Vector) Vector defining direction of the line.</param>
        /// <returns>
        /// A line in 3D space connecting the 2 points.
        /// </returns>

        public SD_Line(SD_Point pt1, SD_Vector vec1)
        {
            StartPoint = pt1;
            EndPoint = (pt1.ToVector() + vec1).ToPoint();

        }

        /// <summary>
        /// Returns a string representing the line.
        /// </summary>
        /// <returns>
        /// A string representing the line.
        /// </returns>
        public override string ToString()
        {
            return StartPoint.ToString() + "," + EndPoint.ToString();
        }

        /// <summary>
        /// Returns an array representing the line.
        /// </summary>
        /// <returns>
        /// An array representing the line.
        /// </returns>
        public SD_Point[] ToArray()
        {
            return new SD_Point[] { StartPoint, EndPoint };
        }

        /// <summary>
        /// Returns the legth of the line.
        /// </summary>
        /// <returns>
        /// The length of the line.
        /// </returns>
        public double Length()
        {
            return StartPoint.Distance(EndPoint);
        }

        /// <summary>
        /// Returns a vector from the line.
        /// </summary>
        /// <returns>
        /// A vector representing the length and direction of the line.
        /// </returns>
        public SD_Vector ToVector()

        {
            return StartPoint.VectorToPoint(EndPoint);
        }

        /// <summary>
        /// Returns a point on the line defined by parameter t where 0 is the StartPoint and 1 is the EndPoint of the line.
        /// </summary>
        /// <param name="t"> (double) Parameter t ranging from 0 (start point) to 1 (end point).</param>
        /// <returns>
        /// A point on the line.
        /// </returns>
        public SD_Point PointOnLine(double t)
        {

            return new SD_Point(_x(t), _y(t), _z(t));
        }


        /// <summary>
        /// Returns a point at the mid point of the line.
        /// </summary>
        /// <returns>
        /// A point representing the mid point of the line.
        /// </returns>
        public SD_Point MidPoint()
        {

            //Gets a midpoint of a line

            return new SD_Point(_x(0.5), _y(0.5), _z(0.5));
        }


        /// <summary>
        /// Checks whether the line is parallel to another line.
        /// </summary>
        /// <param name="other"> (SD_Line) The other line to compare against.</param>
        /// <returns>
        /// 'True' if the lines are parallel and 'False' if not.
        /// </returns>
        public bool IsParallel(SD_Line other)
        {

            return SD_Vector.CrossProduct(ToVector(), other.ToVector()).Magnitude() == 0;

        }

        /// <summary>
        /// Checks whether a defined point is on the line.
        /// </summary>
        /// <param name="point"> (SD_Point) The point to check against.</param>
        /// <returns>
        /// 'True' if point is on line and 'False' if not.
        /// </returns>
        public bool IsPointOnLine(SD_Point point)
        {
            bool result = false;

            if (point.Distance(StartPoint) + point.Distance(EndPoint) == Length())
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Returns the intersersection parameter t for a point on the line
        /// </summary>
        /// <param name="point"> (SD_Point) The point to check against.</param>
        /// <returns>
        /// The parameter t representing the location on the line.
        /// </returns>
        public double? GetParameter(SD_Point point)
        {

            double? t = null;

            if (point.Distance(StartPoint) + point.Distance(EndPoint) == Length())
            {

                t = (point.X - StartPoint.X) / (EndPoint.X - StartPoint.X);

            }

            return t;
        }

        /// <summary>
        /// Returns a list of division points on a line and their t paramaters.
        /// </summary>
        /// <param name="n"> (Double) The number of divisions of the line.</param>
        /// <returns>
        /// The divisions of the line.
        /// </returns>
        public Tuple<List<SD_Point>, List<double>> Divide(double n)
        {
            

            List<SD_Point> pointList = new List<SD_Point>();
            List<double> tList = new List<double>();

            for (int i = 0; i < n + 1; i++)
            {
                double t = i / (n + 1);

                tList.Add(t);
                pointList.Add(new SD_Point(_x(t), _y(t), _z(t)));

            }

            return new Tuple<List<SD_Point>, List<double>>(pointList, tList);
        }

    }



}
