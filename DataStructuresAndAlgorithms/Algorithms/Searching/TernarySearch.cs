namespace DataStructuresAndAlgorithms.Algorithms.Searching
{
    internal static class TernarySearch
    {
        public static int Search(int[] array, int value)
        {
            var left = 0;
            var right = array.Length - 1;
            return Search(array, value, left, right);
        }

        private static int Search(int[] array, int value, int left, int right)
        {
            if (left > right)
                return -1;

            var partitionSize = (right - left) / 3;

            var mid1 = left + partitionSize;
            var mid2 = right - partitionSize;

            if (array[mid1] == value)
                return mid1;

            if (array[mid2] == value)
                return mid2;

            if (value < array[mid1])
                return Search(array, value, left, mid1 - 1);
            if (value > array[mid2])
                return Search(array, value, mid2 + 1, right);
            return Search(array, value, mid1 + 1, mid2 - 1);
        }
    }
}
