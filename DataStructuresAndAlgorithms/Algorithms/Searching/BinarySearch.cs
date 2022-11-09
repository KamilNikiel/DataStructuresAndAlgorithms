namespace DataStructuresAndAlgorithms.Algorithms.Searching
{
    internal static class BinarySearch
    {
        public static int Search(int[] array, int value)
        {
            var left = 0;
            var right = array.Length - 1;

            while (left <= right)
            {
                var middle = (left + right) / 2;

                if (array[middle] == value)
                    return middle;

                if (value < array[middle])
                    right = middle - 1;
                else
                    left = middle + 1;
            }
            return -1;
        }

        public static int SearchRecursion(int[] array, int value)
        {
            var left = 0;
            var right = array.Length - 1;
            return SearchRecursion(array, value, left, right);
        }

        public static int SearchRecursion(int[] array, int value, int left, int right)
        {
            if (right < left)
                return -1;

            var middle = (left + right) / 2;
            if (array[middle] == value)
                return middle;

            if (value < array[middle])
                return SearchRecursion(array, value, left, middle - 1);

            return SearchRecursion(array, value, middle + 1, right);
        }
    }
}
