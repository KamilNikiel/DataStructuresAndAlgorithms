using System.Text;

namespace DataStructuresAndAlgorithms.DataStructures.Fundamentals
{
    public class Stack
    {
        //LIFO
        private readonly List<char> _rightBrackets = new List<char> { ')', '>', '}', ']' };
        private readonly List<char> _leftBrackets = new List<char> { '(', '<', '{', '[' };
        private int[]? _stack = new int[256];
        private static int _count;

        public void Push(int value)
        {
            if (_count == _stack.Length)
                throw new StackOverflowException();

            _stack[_count++] = value;
        }

        public int Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException();

            return _stack[--_count];
        }

        public int Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException();

            return _stack[_count - 1];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public override string ToString()
        {
            var tempArray = new int[_count];
            Array.Copy(_stack, tempArray, _count);
            return string.Join(',', tempArray);
        }

        //Other - not connected with stack implementation

        public string StringReverser(string str)
        {
            if (str == null)
                throw new ArgumentNullException("str");

            var stringBuilder = new StringBuilder();
            var stack = new Stack<char>();

            foreach (char c in str)
                stack.Push(c);

            for (int i = 0; i < str.Length; i++)
                stringBuilder.Append(stack.Pop());

            return stringBuilder.ToString();
        }

        public bool IsBalanced(string str)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (IsLeftBraket(str, i))
                {
                    stack.Push(str[i]);
                }
                if (IsRightBracket(str, i))
                {
                    var topOfStack = stack.Pop();
                    if (!BracketMatch(str, i, topOfStack))
                        return false;
                }
            }
            if (stack.Any())
                return false;

            return true;
        }

        private bool BracketMatch(string str, int i, char topOfStack)
        {
            return _leftBrackets.IndexOf(str[i]) == _rightBrackets.IndexOf(topOfStack);
        }

        private bool IsRightBracket(string str, int i)
        {
            return _rightBrackets.Contains(str[i]);
        }

        private bool IsLeftBraket(string str, int i)
        {
            return _leftBrackets.Contains(str[i]);
        }
    }
}
