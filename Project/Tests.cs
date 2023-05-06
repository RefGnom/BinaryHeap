using NUnit.Framework;

using Numbers = System.Collections.Generic.Queue<int>;

namespace DS3
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [Repeat(1000)]
        public void TestOnRandomData() 
        { 
            var random = new Random();
            var numbersList = new List<Numbers>();
            var k = random.Next(0, 100);
            var lenNumbers = random.Next(1, 100);
            var numbers = new int[lenNumbers];
            for (int i = 0; i < k; i++)
            {
                numbers[0] = random.Next(0, 100);
                for (int j = 1; j < lenNumbers; j++)
                    numbers[j] = numbers[j - 1] + random.Next(0, 100);
                numbersList.Add(Program.NumbersConstructor(numbers));
            }
            var n = random.Next(0, k * lenNumbers);
            var expected = Combiner.GetUnion(n, numbersList);
            var actual = Combiner.GetUnionThroughBinaryHeap(n, numbersList);
            Assert.AreEqual(n, actual.Count);
            Assert.AreEqual(expected, actual);
        }
    }
}