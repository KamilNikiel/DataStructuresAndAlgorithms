namespace DataStructuresAndAlgorithms.Algorithms.Sorting
{
    internal class BubbleSort
    {
        public void Sort(int[] array)
        {
            bool isSorted;
            for (var i = 0; i < array.Length; i++)
            {
                isSorted = true;
                for (var j = 1; j < array.Length - i; j++)
                    if (array[j] < array[j - 1])
                    {
                        Swap(array, j - 1, j);
                        isSorted = false;
                    }
                if (isSorted)
                    return;
            }
        }

        private static void Swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
