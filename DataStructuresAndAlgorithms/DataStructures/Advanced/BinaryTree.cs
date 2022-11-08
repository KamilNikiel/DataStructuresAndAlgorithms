namespace DataStructuresAndAlgorithms.DataStructures.Advanced
{
    internal class BinaryTree
    {
        private class Node
        {
            public int Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public Node(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return "Node: " + Value;
            }
        }

        private Node _root;

        public bool Insert(int value)
        {
            var node = new Node(value);

            if (_root == null)
            {
                _root = node;
                return true;
            }

            var searchNode = _root;
            while (true)
            {
                if (value < searchNode.Value)
                {
                    if (searchNode.LeftChild == null)
                    {
                        searchNode.LeftChild = node;
                        return true;
                    }
                    searchNode = searchNode.LeftChild;
                }
                else if (value > searchNode.Value)
                {
                    if (searchNode.RightChild == null)
                    {
                        searchNode.RightChild = node;
                        return true;
                    }
                    searchNode = searchNode.RightChild;
                }
                else
                    return false;
            }
        }

        public bool Find(int value)
        {
            var searchNode = _root;

            while (searchNode != null)
            {
                if (value < searchNode.Value)
                    searchNode = searchNode.LeftChild;
                else if (value > searchNode.Value)
                    searchNode = searchNode.RightChild;
                else
                    return true;
            }
            return false;
        }

        public void TraverseLeveLOrder()
        {
            for (var i = 0; i <= Height(); i++)
            {
                foreach (var value in GetNodesAtDistance(i))
                    Console.Write(value.ToString() + " ");
            }
        }
        public int Height()
        {
            return Height(_root);
        }

        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (IsLeaf(root))
                return 0;

            return 1 + Math.Max(
                Height(root.LeftChild),
                Height(root.RightChild));
        }

        public List<int> GetNodesAtDistance(int distance)
        {
            var list = new List<int>();
            GetNodesAtDistance(distance, _root, list);
            return list;
        }
        private void GetNodesAtDistance(int distance, Node root, List<int> list)
        {
            if (root == null)
                return;

            if (distance == 0)
            {
                list.Add(root.Value);
                return;
            }

            GetNodesAtDistance(distance - 1, root.LeftChild, list);
            GetNodesAtDistance(distance - 1, root.RightChild, list);
        }

        public void PrintNodesAtDistance(int distance)
        {
            PrintNodesAtDistance(distance, _root);
        }

        private void PrintNodesAtDistance(int distance, Node root)
        {
            if (root == null)
                return;

            if (distance == 0)
            {
                Console.Write(root.Value + " ");
                return;
            }

            PrintNodesAtDistance(distance - 1, root.LeftChild);
            PrintNodesAtDistance(distance - 1, root.RightChild);
        }
        
        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(_root, int.MinValue, int.MaxValue);
        }

        private bool IsBinarySearchTree(Node root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.Value < min || root.Value > max)
                return false;
            return IsBinarySearchTree(root.LeftChild, min, root.Value - 1)
                && IsBinarySearchTree(root.RightChild, root.Value + 1, max);
        }

        public int Min()
        {
            if (_root == null)
                throw new InvalidOperationException();

            var currentNode = _root;
            var lastNode = currentNode;

            while (currentNode != null)
            {
                lastNode = currentNode;
                currentNode = currentNode.LeftChild;
            }

            return lastNode.Value;
        }
        public int Max()
        {
            if (_root == null)
                throw new InvalidOperationException();

            var currentNode = _root;
            var lastNode = currentNode;

            while (currentNode != null)
            {
                lastNode = currentNode;
                currentNode = currentNode.RightChild;
            }

            return lastNode.Value;
        }

        public bool Equals(BinaryTree tree)
        {
            if (tree == null)
                return false;

            return Equals(this._root, tree._root);
        }

        private bool Equals(Node firstNode, Node secondNode)
        {
            if (firstNode == null && secondNode == null)
                return true;

            if (firstNode != null && secondNode != null)
                return firstNode.Value == secondNode.Value
                    && Equals(firstNode.LeftChild, secondNode.LeftChild)
                    && Equals(firstNode.RightChild, secondNode.RightChild);

            return false;
        }
        public void TraversePreOrder()
        {
            TraversePreOrder(_root);
        }

        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;

            Console.Write(root.Value + " ");
            TraversePreOrder(root.LeftChild);
            TraversePreOrder(root.RightChild);
        }
        public void TraverseInOrder()
        {
            TraverseInOrder(_root);
        }

        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;

            TraverseInOrder(root.LeftChild);
            Console.Write(root.Value + " ");
            TraverseInOrder(root.RightChild);
        }
        public void TraversePostOrder()
        {
            TraversePostOrder(_root);
        }

        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;

            TraversePostOrder(root.LeftChild);
            TraversePostOrder(root.RightChild);
            Console.Write(root.Value + " ");
        }

        private bool IsLeaf(Node node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }
    }
}
