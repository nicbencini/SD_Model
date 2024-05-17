
using System;
using SD_Vector_Library.Geometry;
using SD_Vector_Library.Vector;

namespace SD_Vector_Library.Vector
{
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

        public double aValue()
        {
            return a;
        }

        public double bValue()
        {
            return b;
        }

        public double cValue()
        {
            return c;
        }

        public double dValue()
        {
            return d;
        }
        public SD_Matrix ToRotationMatrix()
        {


            return new SD_Matrix(new double[][] { XVector.ToArray(), YVector.ToArray(), ZVector.ToArray() });

        }


        public override string ToString()
        {
            return "< O" + Origin.ToString() + ", X" + XVector.ToString() + ", Y" + YVector.ToString() + ", Z" + ZVector.ToString() + ">";
        }

        public SD_Vector[] ToArray()
        {
            return new SD_Vector[] { Origin, XVector, YVector, ZVector };
        }

        public string[] ToStringArray()
        {
            return new string[] { Origin.ToString(), XVector.ToString(), YVector.ToString(), ZVector.ToString() };
        }



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

