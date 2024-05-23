
using System;
using System.Collections.Generic;
using SD_Model.Vector;

namespace SD_Model.Geometry
{

    public class SD_Line 
    {
        public SD_Point StartPoint { get; set; }
        public SD_Point EndPoint { get; set; }


        // Cartesian equation of a line defined by       StPt + t (endPt - StPt)

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

        public SD_Line(SD_Point pt1, SD_Point pt2)
        {

            StartPoint = pt1;
            EndPoint = pt2;


        }

        public SD_Line(SD_Point pt1, SD_Vector vec1)
        {
            StartPoint = pt1;
            EndPoint = (pt1.ToVector() + vec1).ToPoint();

        }

        public override string ToString()
        {
            return StartPoint.ToString() + "," + EndPoint.ToString();
        }

        public SD_Point[] ToArray()
        {
            return new SD_Point[] { StartPoint, EndPoint };
        }

        public double Length()
        {
            return StartPoint.Distance(EndPoint);
        }

        public SD_Vector ToVector()

        {

            return StartPoint.VectorToPoint(EndPoint);


        }


        public SD_Point PointOnLine(double t)
        {

            //Gets a point on the line defined by parameter t where 0 is the StartPoint and 1 is the EndPoint of the line

            return new SD_Point(_x(t), _y(t), _z(t));
        }



        public SD_Point MidPoint()
        {

            //Gets a midpoint of a line

            return new SD_Point(_x(0.5), _y(0.5), _z(0.5));
        }

        /*
        public bool overlap (SD_Line other)
        {

        }
        */

        public bool IsParallel(SD_Line other)
        {
            //Checks whether vector is parallel to other vector


            return SD_Vector.CrossProduct(ToVector(), other.ToVector()).Magnitude() == 0;

        }

        public bool IsPointOnLine(SD_Point point)
        {
            bool result = false;

            if (point.Distance(StartPoint) + point.Distance(EndPoint) == Length())
            {
                result = true;
            }

            return result;
        }

        public double? GetParameter(SD_Point point)
        {
            //Gets the intersersection parameter t for a point on the line

            double? t = null;

            if (point.Distance(StartPoint) + point.Distance(EndPoint) == Length())
            {

                t = (point.X - StartPoint.X) / (EndPoint.X - StartPoint.X);

            }

            return t;
        }

        public Tuple<List<SD_Point>, List<double>> Divide(double n)
        {

            List<SD_Point> pointList = new List<SD_Point>();
            List<double> tList = new List<double>();

            //Returns a list of division points on a line and their t paramaters
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
