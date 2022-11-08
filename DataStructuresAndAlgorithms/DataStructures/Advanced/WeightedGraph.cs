namespace DataStructuresAndAlgorithms.DataStructures.Advanced
{
    internal class WeightedGraph
    {
        private class Node
        {
            public string Label { get; set; }
            private List<Edge> _edges = new List<Edge>();
            public Node(string label)
            {
                Label = label;
            }

            public override string ToString()
            {
                return Label;
            }

            public void AddEdge(Node to, int weight)
            {
                _edges.Add(new Edge(this, to, weight));
            }

            public List<Edge> GetEdges()
            {
                return _edges;
            }
        }

        private class Edge
        {
            public Node From { get; set; }
            public Node To { get; set; }
            public int Weight { get; set; }

            public Edge(Node from, Node to, int weight)
            {
                From = from;
                To = to;
                Weight = weight;
            }

            public override string ToString()
            {
                return From.Label + "->" + To.Label + " [weight: " + Weight + "]";
            }
        }

        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();

        public void AddNode(string label)
        {
            if (label == null)
                throw new InvalidOperationException();

            _nodes.Add(label, new Node(label));
        }

        public void AddEdge(string from, string to, int weight)
        {
            var fromNode = _nodes.GetValueOrDefault(from);

            if (fromNode == null)
                throw new InvalidOperationException();

            var toNode = _nodes.GetValueOrDefault(to);

            if (fromNode == null)
                throw new InvalidOperationException();

            var edge = new Edge(fromNode, toNode, weight);

            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        public void Print()
        {
            foreach (var source in _nodes.Values)
                if (source.GetEdges().Count != 0)
                    Console.WriteLine(source + " is connected to " + String.Join(',', source.GetEdges()));
        }

        private class Path
        {
            public List<string> Nodes = new List<string>();
        }

        public List<string> GetShortestPath(string from, string to)
        {
            //Dijkstra algorithm
            var fromNode = _nodes.GetValueOrDefault(from);

            if (fromNode == null)
                throw new InvalidOperationException();

            var toNode = _nodes.GetValueOrDefault(to);

            if (fromNode == null)
                throw new InvalidOperationException();

            var distances = new Dictionary<Node, int>();
            foreach (var node in _nodes.Values)
                distances.Add(node, int.MaxValue);
            distances[fromNode] = 0;

            var visited = new HashSet<Node>();
            var queue = new PriorityQueue<Node, int>();
            var previousNodes = new Dictionary<Node, Node>();

            queue.Enqueue(fromNode, 0);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                visited.Add(current);

                foreach (var edge in current.GetEdges())
                {
                    if (visited.Contains(edge.To))
                        continue;

                    var newDistance = distances.GetValueOrDefault(current) + edge.Weight;
                    if (newDistance < distances.GetValueOrDefault(edge.To))
                    {
                        distances[edge.To] = newDistance;
                        previousNodes[edge.To] = current;
                        queue.Enqueue(edge.To, newDistance);
                    }
                }
            }

            return GetShortestPathToNode(toNode, previousNodes);
        }

        private static List<string> GetShortestPathToNode(Node? toNode, Dictionary<Node, Node> previousNodes)
        {
            var stack = new Stack<string>();
            stack.Push(toNode.Label);
            var previous = previousNodes.GetValueOrDefault(toNode);

            while (previous != null)
            {
                stack.Push(previous.Label);
                previous = previousNodes.GetValueOrDefault(previous);
            }
            return stack.ToList();
        }

        public bool HasCycle()
        {
            var visited = new HashSet<Node>();

            foreach (var node in _nodes.Values)
            {
                if (!visited.Contains(node) && HasCycle(node, null, visited))
                    return true;
            }

            return false;
        }
        private bool HasCycle(Node node, Node parent, HashSet<Node> visited)
        {
            visited.Add(node);

            foreach (var edge in node.GetEdges())
            {
                if (edge.To == parent)
                    continue;

                if (visited.Contains(edge.To) || HasCycle(edge.To, node, visited))
                    return true;
            }
            return false;
        }

        public WeightedGraph GetMinimumSpanningTree()
        {
            WeightedGraph tree = new WeightedGraph();

            if (_nodes.Count == 0)
                return tree;

            var edges = new PriorityQueue<Edge, int>();

            foreach (var node in _nodes.Values)
                foreach (var edge in node.GetEdges())
                    edges.Enqueue(edge, edge.Weight);

            var startNode = _nodes.Values.First();
            tree.AddNode(startNode.Label);

            if (edges.Count == 0)
                return tree;

            while (tree._nodes.Count < edges.Count)
            {
                var minEdge = edges.Dequeue();
                var nextNode = minEdge.To;


                if (ContainsNode(tree, nextNode.Label))
                    continue;
                tree.AddNode(nextNode.Label);
                tree.AddEdge(minEdge.From.Label, minEdge.To.Label, minEdge.Weight);

                foreach (var edge in nextNode.GetEdges())
                    if (!tree.ContainsNode(tree, edge.To.Label))
                        edges.Enqueue(edge, edge.Weight);
            }

            return tree;
        }

        private bool ContainsNode(WeightedGraph tree, string label)
        {
            return tree._nodes.ContainsKey(label);
        }
    }
}
