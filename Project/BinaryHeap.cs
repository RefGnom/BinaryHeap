namespace DS3
{
    public class BinaryHeap<T>
    {
        private (int Key, T Value)[] heap;
        private int count;

        public int Count => count;

        public BinaryHeap()
        {
            heap = new (int Key, T Value)[1];
        }

        public void Add(int key, T value)
        {
            count++;
            if (count == heap.Length)
            {
                heap = Resize(heap, count * 2);
            }
            heap[count] = (key, value);
            HeapifyUp();
        }

        public (int Key, T Value) GetMinValue()
        {
            if (count == 0)
                throw new IndexOutOfRangeException();
            var result = heap[1];
            heap[1] = heap[count];
            count--;
            HeapifyDown(1);
            return result;
        }

        private void HeapifyUp()
        {
            var itemIndex = count;
            while (itemIndex != 1)
            {
                var parentIndex = itemIndex / 2;
                if (heap[parentIndex].Key <= heap[itemIndex].Key)
                    break;
                Swap(itemIndex, parentIndex);
                itemIndex = parentIndex;
            }
        }

        private void HeapifyDown(int parentIndex)
        {
            if (parentIndex * 2 > count)
                return;
            if (heap[parentIndex].Key > heap[parentIndex * 2].Key)
            {
                Swap(parentIndex, parentIndex * 2);
                HeapifyDown(parentIndex * 2);
            }
            if (heap[parentIndex].Key > heap[parentIndex * 2 + 1].Key)
            {
                Swap(parentIndex, parentIndex * 2 + 1);
                HeapifyDown(parentIndex * 2 + 1);
            }
        }

        private void Swap(int index1, int index2)
        {
            (heap[index1], heap[index2]) = (heap[index2], heap[index1]);
        }

        private static TData[] Resize<TData>(TData[] data, int newSize)
        {
            var newData = new TData[newSize];
            for (int i = 0; i < data.Length; i++)
            {
                newData[i] = data[i];
            }
            return newData;
        }
    }
}