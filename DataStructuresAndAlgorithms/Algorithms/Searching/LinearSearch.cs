namespace DataStructuresAndAlgorithms.Algorithms.Searching
{
    internal static class LinearSearch
    {
        public static int Search(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == value)
                    return i;
                
            return -1;
        }
    }
}
