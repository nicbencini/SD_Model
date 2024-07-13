using SD_Model.Vector;
using SD_Model.Geometry;

namespace SD_Model_Tests
{
    [TestClass]
    public class SD_Vector_Tests
    {
        [TestMethod]
        public void VectorEqualsTest()
        {
            SD_Vector vector_1 = new SD_Vector(1,2,3);
            SD_Vector vector_2 = new SD_Vector(1, 2, 3);

            bool test_bool = vector_1.Equals(vector_2);

            Assert.IsTrue(test_bool);
        }

        [TestMethod]
        public void VectorMagnitudeTest()
        {
            SD_Vector vector_1 = new SD_Vector(11, 23, 2);

            double magnitude = vector_1.Magnitude();

            Assert.AreEqual(magnitude, 25.573423705088842);
        }

        [TestMethod]
        public void VectorGramSchmitTest()
        {
            SD_Vector vector_1 = new SD_Vector(11, 23, 2);
            SD_Vector vector_2 = new SD_Vector(2, 5, 6);

            SD_Vector new_vector = SD_Vector.GramSchmit(vector_1, vector_2);

            SD_Vector control_vector = new SD_Vector(-1637, -3422, -292);

            Assert.IsTrue(new_vector.Equals(control_vector));
        }
         
        [TestMethod]
        public void VectorUnitTest()
        {
            SD_Vector vector_1 = new SD_Vector(11, 23, 2);

            SD_Vector unit_vector = vector_1.Unit();

            SD_Vector control_vector = new SD_Vector(0.4301340378531763, 0.8993711700566414, 0.07820618870057751);

            Assert.IsTrue(unit_vector.Equals(control_vector));
        }

    }

    [TestClass]
    public class SD_Plane_Tests
    {
        [TestMethod]
        public void PlaneFromPointsTest()
        {
            SD_Point point_1 = new SD_Point(0.5, 0.5, 1);
            SD_Point point_2 = new SD_Point(1, 0, 0);
            SD_Point point_3 = new SD_Point(0, 0, 1);
            
            SD_Plane new_plane = new SD_Plane(point_1, point_2, point_3);

            SD_Vector plane_origin = new_plane.Origin;
            SD_Vector plane_x_vec = new_plane.XVector;
            SD_Vector plane_y_vec = new_plane.YVector;
            SD_Vector plane_z_vec = new_plane.ZVector;

            SD_Vector control_origin = new SD_Vector(0.5, 0.5, 1);
            SD_Vector control_x_vec = new SD_Vector(0.4082482904638631, -0.4082482904638631, -0.8164965809277261);
            SD_Vector control_z_vec = new SD_Vector(0.5773502691896258, -0.5773502691896258, 0.5773502691896254);
            SD_Vector control_y_vec = new SD_Vector(-0.7071067811865476, -0.7071067811865476, 0);

            bool test_bool_1 = plane_origin.Equals(control_origin);
            bool test_bool_2 = plane_x_vec.Equals(control_x_vec);
            bool test_bool_3 = plane_y_vec.Equals(control_y_vec);
            bool test_bool_4 = plane_z_vec.Equals(control_z_vec);

            Assert.IsTrue(test_bool_1);
            Assert.IsTrue(test_bool_2);
        }

    }

}