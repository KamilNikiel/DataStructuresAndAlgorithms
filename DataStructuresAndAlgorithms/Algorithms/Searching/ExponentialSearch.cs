namespace DataStructuresAndAlgorithms.Algorithms.Searching
{
    internal static class ExponentialSearch
    {
        public static int Search(int[] array, int value)
        {
            var bound = 1;
            while (bound < array.Length && array[bound] < value)
                bound *= 2;

            var left = bound / 2;
            var right = Math.Min(bound, array.Length - 1);

            return BinarySearch.SearchRecursion(array, value, left, right);
        }
    }
}
