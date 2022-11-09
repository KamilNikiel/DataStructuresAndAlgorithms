namespace DataStructuresAndAlgorithms.Algorithms.Sorting
{
    internal static class BucketSort
    {
        public static void Sort(int[] array, int numberOfBuckets)
        {
            var index = 0;
            foreach (var bucket in CreateBuckets(array, numberOfBuckets))
            {
                bucket.Sort();
                foreach (var item in bucket)
                    array[index++] = item;
            }
        }

        private static List<List<int>> CreateBuckets(int[] array, int numberOfBuckets)
        {
            var buckets = new List<List<int>>();
            for (var i = 0; i < numberOfBuckets; i++)
                buckets.Add(new List<int>());

            for (var i = 0; i < array.Length; i++)
            {
                if (buckets.Count < array[i] / numberOfBuckets)
                    buckets[numberOfBuckets -1].Add(array[i]);
                else
                buckets[array[i] / numberOfBuckets].Add(array[i]);
            }

            return buckets;
        }
    }
}
