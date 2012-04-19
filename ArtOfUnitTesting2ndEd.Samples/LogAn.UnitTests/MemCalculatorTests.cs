using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class MemCalculatorTests
    {
        [Test]
        public void Sum_ByDefault_ReturnsZero()
        {
            MemCalculator calc = MakeCalc();

            int lastSum = calc.Sum();

            Assert.AreEqual(0, lastSum);
        }
        
        [Test]
        public void Add_WhenCalled_ChangesSum()
        {
            MemCalculator calc = MakeCalc();

            calc.Add(1);
            int sum = calc.Sum();

            Assert.AreEqual(1, sum);
        }

        private static MemCalculator MakeCalc()
        {
            return new MemCalculator();
        }
    }
}
