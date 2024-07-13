
using System;
using SD_Model.Geometry;

namespace SD_Model.Vector
{
    /// <summary>
    /// <c>SD_Plane</c> 
    /// Class for creating a 3D plane.
    /// </summary>
    public class SD_Plane
    {
        public SD_Vector Origin { get; set; }
        public SD_Vector XVector { get; set; }
        public SD_Vector YVector { get; set; }
        public SD_Vector ZVector { get; set; }

        //The variables for cartisean equation of a plane ax + by + cz + d = 0
        private double a { get; set; }
        private double b { get; set; }
        private double c { get; set; }
        private double d { get; set; }

        /// <summary>
        /// Creates a 3d plane from the origin point and 3 vectors.
        /// </summary>
        /// <param name="origin"> (SD_Vector) Vector defining the origin point of the plane.</param>
        /// <param name="xVector"> (SD_Vector) Vector defining the x-axis of the plane.</param>
        /// <param name="yVector"> (SD_Vector) Vector defining the y-axis of the plane.</param>
        /// <param name="zVector"> (SD_Vector) Vector defining the z-axis of the plane.</param>
        /// <returns>
        /// The defined 3d plane.
        /// </returns>
        public SD_Plane(SD_Vector origin, SD_Vector xVector, SD_Vector yVector, SD_Vector zVector)
        {


            Origin = origin;
            XVector = xVector;
            YVector = yVector;
            ZVector = zVector;

            SD_Vector normal = ZVector;

            a = normal.X;
            b = normal.Y;
            c = normal.Z;
            d = (normal.X * origin.X + normal.Y * origin.Y + normal.Z * origin.Z) * -1;

        }

        /// <summary>
        /// Creates a 3d plane from the origin point and 2 vectors.
        /// </summary>
        /// <param name="origin"> (SD_Vector) Vector defining the origin point of the plane.</param>
        /// <param name="xAxis"> (SD_Vector) Vector defining the x-axis of the plane.</param>
        /// <param name="yAxis"> (SD_Vector) Vector defining the y-axis of the plane.</param>
        /// <returns>
        /// The defined 3d plane.
        /// </returns>
        public SD_Plane(SD_Point origin, SD_Vector xAxis, SD_Vector yAxis)
        {

            SD_Vector u = xAxis;
            SD_Vector v = yAxis;


            SD_Vector normal = SD_Vector.CrossProduct(u, v);

            a = normal.X;
            b = normal.Y;
            c = normal.Z;
            d = (normal.X * origin.X + normal.Y * origin.Y + normal.Z * origin.Z) * -1;

            Origin = origin.ToVector();
            XVector = u.Unit();
            YVector = SD_Vector.CrossProduct(XVector, normal).Unit().Reverse();
            ZVector = normal;

        }

        /// <summary>
        /// Creates a 3d plane from 3 points.
        /// </summary>
        /// <param name="pt1"> (SD_Point) Point defining the origin point of the plane.</param>
        /// <param name="pt2"> (SD_Point)) First point that lies on plane.</param>
        /// <param name="pt3"> (SD_Point)) Second point that lies on plane.</param>
        /// <returns>
        /// The defined 3d plane.
        /// </returns>
        public SD_Plane(SD_Point pt1, SD_Point pt2, SD_Point pt3)
        {

            SD_Vector u = pt2.ToVector() - pt1.ToVector();
            SD_Vector v = pt3.ToVector() - pt1.ToVector();


            SD_Vector normal = SD_Vector.CrossProduct(u, v);

            a = normal.X;
            b = normal.Y;
            c = normal.Z;
            d = (normal.X * pt1.X + normal.Y * pt1.Y + normal.Z * pt1.Z) * -1;

            Origin = pt1.ToVector();
            XVector = u.Unit();
            YVector = SD_Vector.CrossProduct(XVector, normal).Unit().Reverse();
            ZVector = normal;

        }

        /// <summary>
        /// Creates a 3d plane from an origin point and a normal vector.
        /// </summary>
        /// <param name="origin"> (SD_Point) Point defining the origin point of the plane.</param>
        /// <param name="normal"> (SD_Vector)) Vector defining normal orientation.</param>
        /// <returns>
        /// The defined 3d plane.
        /// </returns>
        public SD_Plane(SD_Point origin, SD_Vector normal)
        {


            Origin = origin.ToVector();
            ZVector = normal;


            SD_Vector u = SD_Vector.CrossProduct(normal, SD_Vector.UnitX());
            SD_Vector v = SD_Vector.CrossProduct(normal, u);

            XVector = u.Unit();
            YVector = v.Unit().Reverse();


            a = normal.X;
            b = normal.Y;
            c = normal.Z;
            d = (normal.X * origin.X + normal.Y * origin.Y + normal.Z * origin.Z) * -1;

        }

        /// <summary>
        /// Creates a 3d plane from a line and an oreination vector.
        /// </summary>
        /// <param name="line"> (SD_Line) A line definig the x-axis ot y-axis of the plane.</param>
        /// <param name="orientationVector"> (SD_Vector)) Vector defining normal orientation.</param>
        /// <param name="xAxisOrientedToLine"> (bool)) If 'true', the x-axis will be orientated to the line, else the y-axis will be orientated to the line</param>
        /// <returns>
        /// The defined 3d plane.
        /// </returns>
        public SD_Plane(SD_Line line, SD_Vector orientationVector, bool xAxisOrientedToLine = false)
        {
            SD_Vector xVector = (line.EndPoint.ToVector() - line.StartPoint.ToVector()).Unit();


            if (xVector.IsParallel(orientationVector))
            {
                if (!xVector.IsParallel(SD_Vector.UnitZ()))
                {
                    orientationVector = SD_Vector.UnitZ();

                    //throw new Exception("Orientation vector parallel to line: rotation frame oriented to global Z");
                }

                else
                {
                    orientationVector = -SD_Vector.UnitX();

                    //throw new Exception("Orientation vector parallel to line: rotation frame oriented to global Z");
                }
            }


            SD_Vector yVector = SD_Vector.GramSchmit(xVector, orientationVector).Unit();

            SD_Vector zVector = SD_Vector.CrossProduct(xVector, yVector).Unit();


            if (xAxisOrientedToLine)
            {
                Origin = line.StartPoint.ToVector();
                XVector = xVector;
                YVector = yVector;
                ZVector = zVector;
            }

            else
            {

                Origin = line.StartPoint.ToVector();
                XVector = yVector;
                YVector = zVector;
                ZVector = xVector;
            }

        }

        /// <summary>
        /// Retrurns parameter 'a' of the plane as defined by the plane equation ax + by + cz + d = 0.
        /// </summary>
        /// <returns>
        /// The 'a' parameter of the plane.
        /// </returns>
        public double aValue()
        {
            return a;
        }

        /// <summary>
        /// Retrurns parameter 'b' of the plane as defined by the plane equation ax + by + cz + d = 0.
        /// </summary>
        /// <returns>
        /// The 'b' parameter of the plane.
        /// </returns>
        public double bValue()
        {
            return b;
        }

        /// <summary>
        /// Retrurns parameter 'c' of the plane as defined by the plane equation ax + by + cz + d = 0.
        /// </summary>
        /// <returns>
        /// The 'c' parameter of the plane.
        /// </returns>
        public double cValue()
        {
            return c;
        }

        /// <summary>
        /// Retrurns parameter 'd' of the plane as defined by the plane equation ax + by + cz + d = 0.
        /// </summary>
        /// <returns>
        /// The 'd' parameter of the plane.
        /// </returns>
        public double dValue()
        {
            return d;
        }

        /// <summary>
        /// Converts the plane to a rotation matrix.
        /// </summary>
        /// <returns>
        /// The rotation matrix for the plane.
        /// </returns>
        public SD_Matrix ToRotationMatrix()
        {


            return new SD_Matrix(new double[][] { XVector.ToArray(), YVector.ToArray(), ZVector.ToArray() });

        }

        /// <summary>
        /// Returns a string representing the plane.
        /// </summary>
        /// <returns>
        /// A string representing the plane.
        /// </returns>
        public override string ToString()
        {
            return "< O" + Origin.ToString() + ", X" + XVector.ToString() + ", Y" + YVector.ToString() + ", Z" + ZVector.ToString() + ">";
        }

        /// <summary>
        /// Returns an array representing the plane.
        /// </summary>
        /// <returns>
        /// An array representing the plane.
        /// </returns>
        public SD_Vector[] ToArray()
        {
            return new SD_Vector[] { Origin, XVector, YVector, ZVector };
        }

        /// <summary>
        /// Returns a string array representing the plane.
        /// </summary>
        /// <returns>
        /// A string array representing the plane.
        /// </returns>
        public string[] ToStringArray()
        {
            return new string[] { Origin.ToString(), XVector.ToString(), YVector.ToString(), ZVector.ToString() };
        }


        /// <summary>
        /// Returns a plane defined by the global x-axis and y-axis.
        /// </summary>
        /// <returns>
        /// The resulting x-y plane.
        /// </returns>
        public SD_Plane XY()
        {

            Origin = new SD_Vector(0, 0, 0);
            XVector = new SD_Vector(1, 0, 0);
            YVector = new SD_Vector(0, 1, 0);
            ZVector = new SD_Vector(0, 0, 1);

            a = ZVector.X;
            b = ZVector.Y;
            c = ZVector.Z;
            d = (ZVector.X * Origin.X + ZVector.Y * Origin.Y + ZVector.Z * Origin.Z) * -1;


            return this;

        }


        /// <summary>
        /// Returns a plane defined by the global y-axis and z-axis.
        /// </summary>
        /// <returns>
        /// The resulting y-z plane.
        /// </returns>
        public SD_Plane YZ()
        {

            Origin = new SD_Vector(0, 0, 0);
            XVector = new SD_Vector(0, 1, 0);
            YVector = new SD_Vector(0, 0, 1);
            ZVector = new SD_Vector(1, 0, 0);

            a = ZVector.X;
            b = ZVector.Y;
            c = ZVector.Z;
            d = (ZVector.X * Origin.X + ZVector.Y * Origin.Y + ZVector.Z * Origin.Z) * -1;

            return this;

        }


        /// <summary>
        /// Returns a plane defined by the global x-axis and z-axis.
        /// </summary>
        /// <returns>
        /// The resulting x-z plane.
        /// </returns>
        public SD_Plane XZ()
        {

            Origin = new SD_Vector(0, 0, 0);
            XVector = new SD_Vector(1, 0, 0);
            YVector = new SD_Vector(0, 0, 1);
            ZVector = new SD_Vector(0, -1, 0);

            a = ZVector.X;
            b = ZVector.Y;
            c = ZVector.Z;
            d = (ZVector.X * Origin.X + ZVector.Y * Origin.Y + ZVector.Z * Origin.Z) * -1;

            return this;

        }


    }




}

