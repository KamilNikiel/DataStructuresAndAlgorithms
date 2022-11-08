namespace DataStructuresAndAlgorithms.DataStructures.Advanced
{
    internal class Graph
    {
        private class Node
        {
            public string Label { get; set; }
            public Node(string label)
            {
                Label = label;
            }

            public override string ToString()
            {
                return Label;
            }
        }

        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        private Dictionary<Node, List<Node>> _adjacencyList = new Dictionary<Node, List<Node>>();
        public void AddNode(string label)
        {
            if (label == null)
                return;

            var node = new Node(label);
            _nodes.Add(label, node);
            _adjacencyList.Add(node, new List<Node>());
        }

        public void AddEdge(string from, string to)
        {
            var fromNode = _nodes.GetValueOrDefault(from);

            if (fromNode == null)
                throw new InvalidOperationException();

            var toNode = _nodes.GetValueOrDefault(to);

            if (fromNode == null)
                throw new InvalidOperationException();

            _adjacencyList.GetValueOrDefault(fromNode).Add(toNode);
        }

        public void RemoveNode(string label)
        {
            var node = _nodes.GetValueOrDefault(label);
            if (node == null)
                return;

            foreach (var n in _adjacencyList.Keys)
                _adjacencyList.GetValueOrDefault(n).Remove(node);

            _adjacencyList.Remove(node);
            _nodes.Remove(label);
        }

        public void RemoveEdge(string from, string to)
        {
            var fromNode = _nodes.GetValueOrDefault(from);
            var toNode = _nodes.GetValueOrDefault(to);

            if (fromNode == null || toNode == null)
                return;

            _adjacencyList.GetValueOrDefault(fromNode).Remove(toNode);
        }

        public void Print()
        {
            foreach (var source in _adjacencyList.Keys)
            {
                var targets = _adjacencyList.GetValueOrDefault(source);

                if (targets.Count != 0)
                    Console.WriteLine(source + " is connected to " + string.Join(',', targets));
            }
        }

        public void TraverseDepthFirstIteration(string root)
        {
            var node = _nodes.GetValueOrDefault(root);
            if (node == null)
                return;

            var visited = new HashSet<Node>();

            var stack = new Stack<Node>();
            stack.Push(node);

            while (stack.Count != 0)
            {
                var current = stack.Pop();
            
                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current);
                visited.Add(current);

                foreach (var neighbour in _adjacencyList.GetValueOrDefault(current))
                    if (!visited.Contains(neighbour))
                        stack.Push(neighbour);
            }
        }

        public void TraverseBreathFirstIteration(string root)
        {
            var node = _nodes.GetValueOrDefault(root);
            if (node == null)
                return;

            var visited = new HashSet<Node>();

            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
            
                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current);
                visited.Add(current);

                foreach (var neighbour in _adjacencyList.GetValueOrDefault(current))
                    if (!visited.Contains(neighbour))
                        queue.Enqueue(neighbour);
            }
        }

        public void TraverseDepthFirstRecursive(string root)
        {
            var node = _nodes.GetValueOrDefault(root);
            if (node == null)
                return;
            var visited = new HashSet<Node>();
            TraverseDepthFirstRecursive(node, visited);
        }

        private void TraverseDepthFirstRecursive(Node root, HashSet<Node> visited)
        {
            Console.WriteLine(root.Label);
            visited.Add(root);
             
            foreach (var adj in _adjacencyList.GetValueOrDefault(root))
                if (!visited.Contains(adj))
                    TraverseDepthFirstRecursive(adj, visited);
        }

        public List<string> TopologicalSort()
        {
            var visited = new HashSet<Node>();
            var stack = new Stack<string>();

            foreach (var node in _nodes.Values)
                TopologicalSort(node, visited, stack);

            return stack.ToList();
        }

        private void TopologicalSort(Node root, HashSet<Node> visited, Stack<string> stack)
        {
            if (!visited.Contains(root))
            {
                visited.Add(root);

                foreach (var adj in _adjacencyList.GetValueOrDefault(root))
                    TopologicalSort(adj, visited, stack);

                stack.Push(root.Label);
            }
        }

        public bool HasCycle()
        {
            var all = new HashSet<Node>();
            foreach (var node in _nodes.Values)
                all.Add(node);
            
            var visiting = new HashSet<Node>();
            var visited = new HashSet<Node>();
            
            while (all.Count != 0)
            {
                var current = all.ToArray()[0];
                if (HasCycle(current, all, visiting, visited))
                    return true;
            }

            return false;
        }

        private bool HasCycle(Node node, HashSet<Node> all,
            HashSet<Node> visiting, HashSet<Node> visited)
        {
            all.Remove(node);
            visiting.Add(node);

            foreach (var neighbour in _adjacencyList.GetValueOrDefault(node))
            {
                if (visited.Contains(neighbour))
                    continue;

                if (visiting.Contains(neighbour))
                    return true;

                if (HasCycle(neighbour, all, visiting, visited))
                    return true;
            }

            visiting.Remove(node);
            visited.Add(node);
            return false;
        }
    }
}
