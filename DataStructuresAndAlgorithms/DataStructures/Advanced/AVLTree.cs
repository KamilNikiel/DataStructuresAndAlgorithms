namespace DataStructuresAndAlgorithms.DataStructures.Advanced
{
    internal class AVLTree
    {
        private class Node
        {
            public int Value { get; set; }
            public int Height { get; set; }
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

        private Node? _root;

        public void Insert(int value)
        {
            _root = Insert(value, _root);
        }
        private Node Insert(int value, Node? node)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (value < node.Value)
            {
                node.LeftChild = Insert(value, node.LeftChild);
            }
            else if (value > node.Value)
            {
                node.RightChild = Insert(value, node.RightChild);
            }

            SetHeight(node);

            return Balance(node);
        }

        private Node Balance(Node node)
        {
            if (IsLeftHeavy(node))
            {
                if (BalanceFactor(node.LeftChild) < 0)
                    node.LeftChild = RotateLeft(node.LeftChild);
                return RotateRight(node);
            }
            else if (IsRightHeavy(node))
            {
                if (BalanceFactor(node.RightChild) > 0)
                    node.RightChild = RotateRight(node.RightChild);
                return RotateLeft(node);
            }
            return node;
        }

        private int Height(Node node)
        {
            return (node == null) ? -1 : node.Height;
        }

        private void SetHeight(Node node)
        {
            node.Height = Math.Max(Height(node.LeftChild), Height(node.RightChild)) + 1;
        }
        
        private Node RotateLeft(Node node)
        {
            var newNode = node.RightChild;

            node.RightChild = newNode.LeftChild;
            newNode.LeftChild = node;

            SetHeight(node);
            SetHeight(newNode);

            return newNode;
        }
        
        private Node RotateRight(Node node)
        {
            var newNode = node.LeftChild;

            node.LeftChild = newNode.RightChild;
            newNode.RightChild = node;

            SetHeight(node);
            SetHeight(newNode);

            return newNode;
        }

        private int BalanceFactor(Node node)
        {
            return (node == null) ? 0 : Height(node.LeftChild) - Height(node.RightChild);
        }

        private bool IsLeftHeavy(Node node)
        {
            return BalanceFactor(node) > 1;
        }

        private bool IsRightHeavy(Node node)
        {
            return BalanceFactor(node) < -1;
        }
    }
}
