namespace DataStructuresAndAlgorithms.DataStructures.Advanced
{
    public class Trie
    {
        private class Node
        {
            public char? Value { get; set; }
            public Dictionary<char, Node> Children = new Dictionary<char, Node>();
            public bool IsEndOfWord { get; set; }
            public Node(char? value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return "value = " + Value;
            }

            public Node[] GetChildren()
            {
                return Children.Values.ToArray();
            }

            public Node? GetChild(char currentChar)
            {
                return Children.GetValueOrDefault(currentChar);
            }

            public void AddChild(char currentChar)
            {
                Children.Add(currentChar, new Node(currentChar));
            }

            public void RemoveChild(char character)
            {
                Children.Remove(character);
            }

            public bool HasChildren()
            {
                return GetChildren().Length != 0;
            }

            public bool HasChild(char currentChar)
            {
                return Children.GetValueOrDefault(currentChar) != null;
            }
        }

        private Node _root { get; set; }

        public Trie()
        {
            _root = new Node(null);
        }

        public void Insert(string word)
        {
            if (word == null)
                throw new ArgumentNullException(word);

            var current = _root;

            for (var i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];
                if (!current.HasChild(currentChar))
                    current.AddChild(currentChar);

                current = current.GetChild(currentChar);
            }
            current.IsEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (word == null)
                throw new ArgumentNullException(word);

            var current = _root;

            for (var i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];
                if (!current.HasChild(currentChar))
                    return false;

                current = current.GetChild(currentChar);
            }
            if (current.IsEndOfWord == true)
                return true;
            return false;
        }

        public void Remove(string word)
        {
            if (word == null)
                throw new ArgumentNullException();

            Remove(_root, word, 0);
        }

        private void Remove(Node node, string word, int index)
        {
            if (index == word.Length)
            {
                node.IsEndOfWord = false;
                return;
            }

            var currentChar = word[index];
            var child = node.GetChild(currentChar);

            if (child == null)
                return;

            Remove(child, word, index + 1);

            if (!child.HasChildren() && !child.IsEndOfWord)
                node.RemoveChild(currentChar);
        }

        public List<string> FindWords(string prefix)
        {
            var words = new List<string>();
            var lastNode = FindLastNodeOf(prefix);
            FindWords(lastNode, prefix, words);

            return words;
        }

        private void FindWords(Node node, string prefix, List<string> words)
        {
            if (node == null)
                throw new ArgumentNullException();

            if (node.IsEndOfWord)
                words.Add(prefix);

            foreach (var child in node.GetChildren())
                FindWords(child, prefix + child.Value, words);
        }

        private Node FindLastNodeOf(string prefix)
        {
            var current = _root;
            foreach (var currentChar in prefix.ToCharArray())
            {
                var child = current.GetChild(currentChar);
                if (child == null)
                    return null;
                current = child;
            }
            return current;
        }

        public void Traverse()
        {
            PreOrderTraverse(_root);
        }

        private void PreOrderTraverse(Node root)
        {
            Console.WriteLine(root.Value);

            foreach (var child in _root.GetChildren())
                PreOrderTraverse(child);
        }
        
        private void PostOrderTraverse(Node root)
        {
            foreach (var child in _root.GetChildren())
                PostOrderTraverse(child);
            
            Console.WriteLine(root.Value);
        }
    }
}
