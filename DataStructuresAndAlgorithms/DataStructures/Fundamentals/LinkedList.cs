namespace DataStructuresAndAlgorithms.DataStructures.Fundamentals
{
    public class LinkedList
    {
        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int value, Node next = null)
            {
                Value = value;
                Next = next;
            }
        }

        private Node _first { get; set; }
        private Node _last { get; set; }
        private int _size { get; set; }

        public void AddLast(int item)
        {
            var node = new Node(item);

            if (_first != null)
            {
                _last.Next = node;
                _last = node;
            }
            else
                _first = _last = node;

            _size++;
        }
        public void RemoveLast()
        {
            if (_first == null)
                throw new InvalidOperationException();

            if (_first == _last)
                _first = _last = null;
            else
            {
                var tempNode = _first;
                while (tempNode.Next != null)
                {
                    if (tempNode.Next == _last) break;
                    tempNode = tempNode.Next;
                }
                _last = tempNode;
                _last.Next = null;
            }
            _size--;
        }
        public void AddFirst(int item)
        {
            var node = new Node(item);

            if (_first != null)
            {
                node.Next = _first;
                _first = node;
            }
            else
                _first = _last = node;

            _size++;
        }
        public void RemoveFirst()
        {
            if (_first == null)
                throw new InvalidOperationException();

            if (_first == _last)
                _first = _last = null;
            else
            {
                var second = _first.Next;
                _first.Next = null;
                _first = second;
            }

            _size--;
        }
        public int IndexOf(int value)
        {
            var i = 0;
            var tempNode = _first;
            while (tempNode.Value != value)
            {
                if (tempNode.Next == null)
                    return -1;
                i++;
                tempNode = tempNode.Next;
            }
            return i;
        }
        public bool Contains(int value)
        {
            return IndexOf(value) != -1;
        }
        public int Size()
        {
            return _size;
        }
        public int[] ToArray()
        {
            var array = new int[_size];
            var tempNode = _first;

            for (int i = 0; i < _size; i++)
            {
                array[i] = tempNode.Value;
                tempNode = tempNode.Next;
            }

            return array;
        }
        public void Reverse()
        {
            if (_first == null)
                throw new InvalidOperationException();

            var previousNode = _first;
            var currentNode = _first.Next;

            while (currentNode != null)
            {
                var nextNode = currentNode.Next;
                currentNode.Next = previousNode;

                previousNode = currentNode;
                currentNode = nextNode;
            }

            _last = _first;
            _last.Next = null;
            _first = previousNode;
        }
        public int GetKthFromTheEnd(int k)
        {
            if (_first == null)
                throw new InvalidOperationException();

            var a = _first;
            var b = _first;
            for (int i = 0; i < k - 1; i++)
            {
                if (b == null)
                    throw new InvalidOperationException();

                b = b.Next;
            }
            while (b != _last)
            {
                a = a.Next;
                b = b.Next;
            }
            return a.Value;
        }
        public void PrintMiddle()
        {
            if (_first == null)
                throw new InvalidOperationException();

            var a = _first;
            var b = _first;

            while (b != _last && b.Next != _last)
            {
                a = a.Next;
                b = b.Next.Next;
            }
            if (b == _last)
                Console.WriteLine(a.Value); ;
            Console.WriteLine(a.Value + ", " + a.Next.Value);
        }
    }
}