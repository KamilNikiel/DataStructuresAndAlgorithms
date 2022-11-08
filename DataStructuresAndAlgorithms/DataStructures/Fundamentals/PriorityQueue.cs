namespace DataStructuresAndAlgorithms.DataStructures.Fundamentals
{
    public class PriorityQueue
    {
        private int[] _array;
        private int _count;
        public PriorityQueue(int capacity)
        {
            _array = new int[capacity];
        }
        public void Add(int value)
        {
            if (IsFull())
                throw new InvalidOperationException();

            var i = ShiftItemsToInsert(value);

            _array[i] = value;
            _count++;
        }

        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _array[--_count];
        }
        public bool IsEmpty()
        {
            return _count == 0;
        }
        public override string ToString()
        {
            var tempArray = new int[_count];
            Array.Copy(_array, tempArray, _count);
            return string.Join(',', tempArray);
        }
        private bool IsFull()
        {
            return _count == _array.Length;
        }

        private int ShiftItemsToInsert(int value)
        {
            int i;
            for (i = _count - 1; i >= 0; i--)
            {
                if (_array[i] > value)
                    _array[i + 1] = _array[i];
                else
                    break;
            }

            return i + 1;
        }
    }
}
