using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Algorithms.Sorting
{
    internal class InsertionSort
    {
        public void Sort(int[] array)
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
