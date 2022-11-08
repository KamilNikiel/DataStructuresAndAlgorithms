namespace DataStructuresAndAlgorithms.Algorithms.Sorting
{
    internal class CountingSort
    {
        public void Sort(int[] array, int max)
        {
            var counts = new int[max + 1];
            for (var i = 0; i < array.Length; i++)
                counts[array[i]]++;

            var k = 0;
            for (var i = 0; i < counts.Length; i++)
                for (var j = 0; j < counts[i]; j++)
                    array[k++] = i; 
        }
    }
}
