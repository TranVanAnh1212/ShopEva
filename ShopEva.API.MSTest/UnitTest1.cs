namespace ShopEva.API.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(-1)]
        [DataRow(2)]
        public void TestMethod1(int value)
        {
            bool res = true;

            if (value < 2)
            {
                res = false;
            }

            Assert.IsFalse(res, $"{value} should not be prime");
        }
    }
}