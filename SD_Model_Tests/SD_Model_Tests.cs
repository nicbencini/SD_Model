using SD_Model;
using SD_Model.Vector;

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

    }

    [TestClass]
    public class SD_Plane_Tests
    {
        [TestMethod]
        public void UnitTest()
        {
            //TO BE IMPLEMENTED

            bool test_bool = true;

            Assert.IsTrue(test_bool);
        }

    }

    [TestClass]
    public class SD_Matrix_Tests
    {
        [TestMethod]
        public void UnitTest()
        {
            //TO BE IMPLEMENTED

            bool test_bool = true;

            Assert.IsTrue(test_bool);
        }

    }

    [TestClass]
    public class SD_Point_Tests
    {
        [TestMethod]
        public void UnitTest()
        {
            //TO BE IMPLEMENTED

            bool test_bool = true;

            Assert.IsTrue(test_bool);
        }

    }

    [TestClass]
    public class SD_Line_Tests
    {
        [TestMethod]
        public void UnitTest()
        {
            //TO BE IMPLEMENTED

            bool test_bool = true;

            Assert.IsTrue(test_bool);
        }

    }

}