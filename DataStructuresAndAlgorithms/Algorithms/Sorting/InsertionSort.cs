namespace DataStructuresAndAlgorithms.Algorithms.Sorting
{
    internal static class InsertionSort
    {
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var current = array[i];
                var j = i - 1;
                while (j >= 0 && current < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = current;
            }
        }
    }
}
