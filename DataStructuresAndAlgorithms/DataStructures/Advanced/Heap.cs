namespace DataStructuresAndAlgorithms.DataStructures.Advanced
{
    internal class Heap
    {
        private int[] _heap = new int[256];
        private static int _size { get; set; }

        public void Insert(int value)
        {
            if(IsFull())
                throw new InvalidOperationException();

            _heap[_size++] = value;
            BubbleUp();
        }
        
        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var root = _heap[0];
            _heap[0] = _heap[--_size];

            BubbleDown();

            return root;
        }

        public int Length()
        {
            return _size;
        }

        public bool IsFull()
        {
            return _heap.Length == _size;
        }
        public static bool IsEmpty()
        {
            return _size == 0;
        }

        public int Max()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _heap[0];
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= _size;
        }
        
        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= _size;
        }

        private int GetLargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;

            if (!HasRightChild(index))
                return (LeftChildIndex(index));

            return (LeftChild(index) > RightChild(index)) ? LeftChildIndex(index) : RightChildIndex(index);
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = _heap[index] >= LeftChild(index);

            if (!HasRightChild(index))
                isValid &= isValid & _heap[index] >= RightChild(index);

            return isValid;
        }

        private int LeftChild(int index)
        {
            return _heap[LeftChildIndex(index)];
        }
        
        private int RightChild(int index)
        {
            return _heap[RightChildIndex(index)];
        }

        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private int Parent(int index)
        {
            return (index - 1)/2;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var tempValue = _heap[firstIndex];
            _heap[firstIndex] = _heap[secondIndex];
            _heap[secondIndex] = tempValue;
        }

        private void BubbleUp()
        {
            var index = _size - 1;

            while (index > 0 && _heap[index] > _heap[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private void BubbleDown()
        {
            var index = 0;
            while (index <= _size && !IsValidParent(index))
            {
                var largerChildIndex = GetLargerChildIndex(index);
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }
    }
}
