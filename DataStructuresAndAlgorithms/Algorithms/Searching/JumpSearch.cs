namespace DataStructuresAndAlgorithms.Algorithms.Searching
{
    internal static class JumpSearch
    {
        public static int Search(int[] array, int value)
        {
            var blockSize = (int)Math.Sqrt(array.Length);
            var start = 0;
            var next = blockSize;

            while (start >= array.Length && array[next - 1] < value)
            {
                start = next;
                next += blockSize;

                if (next > array.Length)
                    next = array.Length;
            }
            for (var i = start; i < array.Length; i++)
                if (array[i] == value)
                    return i;

            return -1;
        }
    }
}
