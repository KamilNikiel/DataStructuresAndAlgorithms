namespace DataStructuresAndAlgorithms.DataStructures.Fundamentals
{
    public class StackQueue
    {
        private Stack<int> _stack1 = new Stack<int>();
        private Stack<int> _stack2 = new Stack<int>();

        public void Enqueue(int newItem)
        {
            _stack1.Push(newItem);
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            MoveStack1ToStack2();

            return _stack2.Pop();
        }
        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            MoveStack1ToStack2();

            return _stack2.Peek();
        }

        private void MoveStack1ToStack2()
        {
            if (_stack2.Count == 0)
                while (_stack1.Count != 0)
                    _stack2.Push(_stack1.Pop());
        }

        public bool IsEmpty()
        {
            return _stack1.Count == 0 && _stack2.Count == 0;
        }
    }
}
