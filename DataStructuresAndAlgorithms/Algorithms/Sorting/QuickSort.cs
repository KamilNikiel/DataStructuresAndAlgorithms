namespace DataStructuresAndAlgorithms.Algorithms.Sorting
{
    internal static class QuickSort
    {
        public static void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }
        private static void Sort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            var boundary = Partition(array, start, end);
            
            Sort(array, start, boundary - 1);
            Sort(array, boundary + 1, end);
        }

        private static int Partition(int[] array, int start, int end)
        {
            var pivot = array[end];
            var boundary = start - 1;
            for (var i = start; i <= end; i++)
                if (array[i] <= pivot)
                    Swap(array, i, ++boundary);

            return boundary;
        }

        private static void Swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
