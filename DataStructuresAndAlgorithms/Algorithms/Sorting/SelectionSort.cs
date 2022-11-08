namespace DataStructuresAndAlgorithms.Algorithms.Sorting
{
    internal class SelectionSort
    {
        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = FindMinIndex(array, i);
                Swap(array, minIndex, i);
            }
        }

        private static int FindMinIndex(int[] array, int i)
        {
            var minIndex = i;
            for (var j = i; j < array.Length; j++)
                if (array[j] < array[minIndex])
                    minIndex = j;
            return minIndex;
        }

        private static void Swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
