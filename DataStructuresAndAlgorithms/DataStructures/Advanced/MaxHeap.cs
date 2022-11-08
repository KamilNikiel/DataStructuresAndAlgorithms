namespace DataStructuresAndAlgorithms.DataStructures.Advanced
{
    public static class MaxHeap
    {
        public static void Heapify(int[] array)
        {
            var lastParentIndex = array.Length / 2 - 1;
            for (var i = lastParentIndex; i >= 0; i--)
                Heapify(array, i);
        }

        public static int GetKthLargest(int[] array, int k)
        {
            if (k == 0 || k > array.Length)
                throw new InvalidOperationException();

            var heap = new Heap();
            foreach (var number in array)
                heap.Insert(number);

            for (var i = 0; i < k - 1; i++)
                heap.Remove();

            return heap.Max();
        }

        private static void Heapify(int[] array, int index)
        {
            var largerIndex = index;

            var leftIndex = index * 2 + 1;
            if (leftIndex < array.Length &&
                array[leftIndex] > array[largerIndex])
                largerIndex = leftIndex;

            var rightIndex = index * 2 + 2;
            if (rightIndex < array.Length &&
                array[rightIndex] > array[largerIndex])
                largerIndex = rightIndex;

            if (index == largerIndex)
                return;

            Swap(array, index, largerIndex);
            Heapify(array, largerIndex);
        }

        private static void Swap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
