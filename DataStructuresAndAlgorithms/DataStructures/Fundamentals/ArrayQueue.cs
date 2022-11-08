namespace DataStructuresAndAlgorithms.DataStructures.Fundamentals
{
    public class ArrayQueue
    {
        //FIFO
        private int[] _queue;
        private int _front;
        private int _rear;
        private int _count;

        public ArrayQueue(int capacity)
        {
            _queue = new int[capacity];
        }

        public void Enqueue(int newItem)
        {
            if (_count == _queue.Length)
                throw new InvalidOperationException();

            _queue[_rear] = newItem;
            _rear = (_rear + 1) % _queue.Length;
            _count++;
        }

        public int Dequeue()
        {
            var tempItem = _queue[_front];
            _queue[_front] = 0;
            _front = (_front + 1) % _queue.Length;
            _count--;
            return tempItem;
        }

        public override string ToString()
        {
            var tempArray = new int[_count];
            Array.Copy(_queue, _front, tempArray, 0, _count);
            return string.Join(',', tempArray);
        }
    }
}
