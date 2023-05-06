using NUnitLite;

using Numbers = System.Collections.Generic.Queue<int>;

namespace DS3
{
    public static class Combiner
    {
        public static List<int> GetUnionThroughBinaryHeap(int countElementsInUnion, List<Numbers> numbersList)
        {
            var result = new List<int>();
            var heap = new BinaryHeap<int>();
            for (int k = 0; k < numbersList.Count; k++)
            {
                heap.Add(numbersList[k].Dequeue(), k);
            }
            for (int i = 0; i < countElementsInUnion; i++)
            {
                if (heap.Count == 0)
                    throw new ArgumentException();
                var (key, value) = heap.GetMinValue();
                result.Add(key);
                if (numbersList[value].Count > 0)
                    heap.Add(numbersList[value].Dequeue(), value);
            }
            return result;
        }

        public static List<int> GetUnion(int countElementsInUnion, List<Numbers> numbersList)
        {
            var result = new List<int>();
            var allNumbers = new List<int>();
            foreach (var numbers in numbersList)
            {
                allNumbers.AddRange(numbers);
            }
            allNumbers.Sort();
            for (int i = 0; i < countElementsInUnion; i++)
            {
                result.Add(allNumbers[i]);
            }
            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            new AutoRun().Execute(args);

            var numbersList = new List<Numbers>()
            {
                NumbersConstructor(1, 6, 7),
                NumbersConstructor(9, 10, 12),
                NumbersConstructor(11, 44, 64),
                NumbersConstructor(1, 2, 3)
            };
            foreach (var number in Combiner.GetUnion(8, numbersList))
            {
                Console.WriteLine(number);
            }
        }

        public static Numbers NumbersConstructor(params int[] value)
        {
            var result = new Numbers();
            for (int i = 0; i < value.Length; i++)
            {
                result.Enqueue(value[i]);
            }
            return result;
        }
    }
}