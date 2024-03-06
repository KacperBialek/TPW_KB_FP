using konsola;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Cow mycow = new Cow(2, "Jerry", Animal.gender.female, 35.55, 10);
            Assert.AreEqual(355.5, mycow.value());
            mycow.Obtained_milk = 100;
            Assert.AreEqual(100, mycow.Obtained_milk);
        }
    }
}