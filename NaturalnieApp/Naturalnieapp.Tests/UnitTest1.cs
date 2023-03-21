namespace Naturalnieapp.Tests
{
    using NaturalnieApp;
    using NUnit.Framework;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var result = ElzabRelated.BarcodeShortEquals("01203", "1203");
            Assert.True(result);
        }
    }
}