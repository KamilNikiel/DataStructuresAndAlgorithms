using DataStructuresAndAlgorithms.DataStructures.Fundamentals;
using DataStructuresAndAlgorithms.DataStructures.Advanced;
using DataStructuresAndAlgorithms.Algorithms.Sorting;
using DataStructuresAndAlgorithms.Algorithms.Searching;

namespace DataStructuresAndAlgorithms
{
    public static class Program
    {
        public static void Main()
        {

        }

        private static void ExponentialSearchAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            QuickSort.Sort(numbers);
            var index = ExponentialSearch.Search(numbers, 4);
            Console.WriteLine(index);
        }

        private static void JumpSearchAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            QuickSort.Sort(numbers);
            var index = JumpSearch.Search(numbers, 4);
            Console.WriteLine(index);
        }

        private static void TernarySearchAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            QuickSort.Sort(numbers);
            var index = TernarySearch.Search(numbers, 4);
            Console.WriteLine(index);
        }

        private static void BinarySearchAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            QuickSort.Sort(numbers);
            var index = BinarySearch.Search(numbers, 4);
            var indexRecursion = BinarySearch.SearchRecursion(numbers, 4);
            Console.WriteLine(index);
            Console.WriteLine(indexRecursion);
        }

        private static void LinearSearchAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            var index = LinearSearch.Search(numbers, 4);
            Console.WriteLine(index);
        }

        private static void BucketSortAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            BucketSort.Sort(numbers, 3);
            Console.WriteLine(String.Join(',', numbers));
        }

        private static void CountingSortAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            CountingSort.Sort(numbers, 12);
            Console.WriteLine(String.Join(',', numbers));
        }

        private static void QuickSortAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            QuickSort.Sort(numbers);
            Console.WriteLine(String.Join(',', numbers));
        }

        private static void MergeSortAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            MergeSort.Sort(numbers);
            Console.WriteLine(String.Join(',', numbers));
        }

        private static void InsertionSortAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            InsertionSort.Sort(numbers);
            Console.WriteLine(String.Join(',', numbers));
        }

        private static void SelectionSortAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            SelectionSort.Sort(numbers);
            Console.WriteLine(String.Join(',', numbers));
        }

        private static void BubbleSortAlgorithm()
        {
            int[] numbers = { 3, 4, 5, 6, 12, 1, 2, 1, 4, 6, 0 };
            BubbleSort.Sort(numbers);
            Console.WriteLine(String.Join(',', numbers));
        }

        private static void WeightedGraphMethods()
        {
            var weightedGraph = new WeightedGraph();

            weightedGraph.AddNode("a");
            weightedGraph.AddNode("b");
            weightedGraph.AddNode("c");
            weightedGraph.AddNode("d");
            weightedGraph.AddEdge("a", "b", 1);
            weightedGraph.AddEdge("b", "c", 2);
            weightedGraph.AddEdge("c", "a", 1);
            weightedGraph.AddEdge("c", "d", 1);
            weightedGraph.AddEdge("a", "d", 5);
            weightedGraph.Print();

            Console.WriteLine("Shortest Path:");
            Console.WriteLine(String.Join(',', weightedGraph.GetShortestPath("a", "d")));

            Console.WriteLine("Has cycle: " + weightedGraph.HasCycle());

            var tree = weightedGraph.GetMinimumSpanningTree();
            tree.Print();
        }

        private static void GraphMethods()
        {
            var graph = new Graph();
            graph.AddNode("a");
            graph.AddNode("b");
            graph.AddNode("c");
            graph.AddEdge("a", "b");
            graph.AddEdge("a", "c");
            graph.Print();
            graph.RemoveNode("c");
            graph.RemoveEdge("a", "b");
            graph.Print();

            graph.AddEdge("a", "b");
            graph.AddNode("c");
            graph.AddNode("d");
            graph.AddEdge("b", "d");
            graph.AddEdge("d", "c");
            graph.AddEdge("a", "d");
            graph.AddEdge("b", "a");
            graph.AddEdge("d", "a");

            Console.WriteLine("Depth first recursive");
            graph.TraverseDepthFirstRecursive("a");
            Console.WriteLine("Depth first iteration");
            graph.TraverseDepthFirstIteration("a");
            Console.WriteLine("Breath first iteration");
            graph.TraverseBreathFirstIteration("a");

            var topSortGraph = new Graph();

            topSortGraph.AddNode("X");
            topSortGraph.AddNode("A");
            topSortGraph.AddNode("B");
            topSortGraph.AddNode("P");

            topSortGraph.AddEdge("X", "A");
            topSortGraph.AddEdge("X", "B");
            topSortGraph.AddEdge("A", "P");
            topSortGraph.AddEdge("B", "P");

            Console.WriteLine("Topological sort:");
            Console.WriteLine(String.Join(',', topSortGraph.TopologicalSort()));

            Console.WriteLine("Cycles:");
            Console.WriteLine("Has cycle: " + topSortGraph.HasCycle());

            topSortGraph.AddEdge("P", "X");
            Console.WriteLine("Has cycle: " + topSortGraph.HasCycle());
        }

        private static void TrieMethods()
        {
            var trie = new Trie();

            trie.Insert("current");
            trie.Insert("word");
            trie.Insert("car");
            trie.Insert("cat");
            trie.Insert("cart");
            trie.Insert("card");
            trie.Insert("carnaval");
            Console.WriteLine(trie.Contains("cat"));
            Console.WriteLine(trie.Contains(""));
            trie.Remove("cart");

            var words = trie.FindWords("car");

            Console.WriteLine(String.Join(',', words));
        }

        private static void HeapMethods()
        {
            var heap = new Heap();
            heap.Insert(1);
            heap.Insert(3);
            heap.Insert(5);
            heap.Insert(12);
            heap.Insert(20);
            heap.Insert(4);
            heap.Remove();

            int[] numbers = { 5, 3, 8, 12, 4, 1, 2, 11 };

            Console.WriteLine(MaxHeap.GetKthLargest(numbers, 2));
            MaxHeap.Heapify(numbers);
            Console.WriteLine(String.Join(',', numbers));


            //int[] numbersInDescendingOrder = new int[heap.Length()];
            //int[] numbersInAsscendingOrder = new int[heap.Length()];

            //for (var i = 0; i < numbersInDescendingOrder.Length; i++)
            //    numbersInDescendingOrder[i] = heap.Remove();

            //for (var i = numbersInAsscendingOrder.Length -1; i >= 0; i--)
            //    numbersInAsscendingOrder[i] = heap.Remove();

            //Console.WriteLine(String.Join(',', numbersInDescendingOrder));
            //Console.WriteLine(String.Join(',', numbersInAsscendingOrder));
        }

        private static void AVLTreeMethods()
        {
            var avlTree = new AVLTree();
            avlTree.Insert(12);
            avlTree.Insert(1);
            avlTree.Insert(13);
            avlTree.Insert(14);
            avlTree.Insert(3);
            avlTree.Insert(2);
            avlTree.Insert(4);
            avlTree.Insert(5);
            avlTree.Insert(6);
            avlTree.Insert(0);
        }

        private static void BinaryTreeMethods()
        {
            var tree = new BinaryTree();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(12);
            tree.Insert(13);
            tree.Insert(12);
            tree.Insert(10);
            var tree2 = new BinaryTree();
            tree2.Insert(7);
            tree2.Insert(4);
            tree2.Insert(1);
            tree2.Insert(6);
            tree2.Insert(9);
            tree2.Insert(10);
            Console.Write("Tree1 = Tree2?: ");
            Console.WriteLine(tree.Equals(tree2));
            Console.Write("Contains 7: ");
            Console.WriteLine(tree.Find(7));
            Console.Write("\nPre Order: ");
            tree.TraversePreOrder();
            Console.Write("\nIn Order: ");
            tree.TraverseInOrder();
            Console.Write("\nPost Order: ");
            tree.TraversePostOrder();
            Console.Write("\nMin: ");
            Console.Write(tree.Min());
            Console.Write("\nMax: ");
            Console.Write(tree.Max());
            Console.Write("\nIs this binary search tree: ");
            Console.Write(tree.IsBinarySearchTree());
            Console.Write("\nPrinted nodes at distance 1: ");
            tree.PrintNodesAtDistance(1);
            var list = tree.GetNodesAtDistance(2);
            Console.Write("\nPrinted nodes at distance 2: ");
            foreach (var node in list)
                Console.Write(node.ToString() + " ");
            Console.Write("\nTree height: " + tree.Height());
            Console.Write("\nTraversed level order: ");
            tree.TraverseLeveLOrder();
        }

        private static void DictionaryMethods()
        {
            var dict = new Dictionary();
            dict.Put(1, "test1");
            dict.Put(2, "test2");
            dict.Put(6, "test6");
            dict.Put(6, "test6-revisit");
            dict.Remove(2);
            Console.WriteLine(dict.Get(6));
        }

        private static void CharFinderMethod()
        {
            var dictionary = new CharFinder();

            Console.WriteLine(dictionary.FindFirstNonRepeatingChar("a green apple"));
            Console.WriteLine(dictionary.FindFirstRepeatingChar("a green apple"));
        }

        private static void PriorityQueueMethods()
        {
            var priorityQueue = new PriorityQueue(10);
            priorityQueue.Add(5);
            priorityQueue.Add(4);
            priorityQueue.Add(7);
            priorityQueue.Add(2);
            priorityQueue.Add(3);
            Console.WriteLine(priorityQueue.Remove());
        }

        private static void StackQueueMethods()
        {
            var stackQueue = new StackQueue();
            stackQueue.Enqueue(1);
            stackQueue.Enqueue(2);
            stackQueue.Enqueue(3);
            stackQueue.Enqueue(4);
            Console.WriteLine(stackQueue.Dequeue());
        }

        private static void ArrayQueueMethods()
        {
            var arrayQueue = new ArrayQueue(10);
            arrayQueue.Enqueue(1);
            arrayQueue.Enqueue(2);
            arrayQueue.Enqueue(3);
            arrayQueue.Enqueue(4);
            arrayQueue.Enqueue(5);
            arrayQueue.Dequeue();
            arrayQueue.Dequeue();
            Console.WriteLine(arrayQueue.ToString());
        }

        private static void StackMethods()
        {
            var stack = new Stack();
            Console.WriteLine(stack.StringReverser("kajak hehe żart"));
            Console.WriteLine(stack.IsBalanced("()<>asd12323{}{asdsad{{asdasd}}}()(sdsdsd)()[][][]"));
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(30);
            stack.Pop();
            Console.WriteLine(stack);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.IsEmpty);
        }

        private static void LinkedLinksMethods()
        {
            var list = new LinkedList();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddFirst(-10);
            list.AddFirst(-20);
            list.AddFirst(-30);
            list.AddFirst(-40);
            list.RemoveLast();
            list.RemoveFirst();
            list.PrintMiddle();
            list.AddFirst(-40);
            list.PrintMiddle();
            Console.WriteLine(list.GetKthFromTheEnd(3));
            Console.WriteLine(String.Join(',', list.ToArray()));
            list.Reverse();
            Console.WriteLine(String.Join(',', list.ToArray()));
            Console.WriteLine(list.IndexOf(10));
            Console.WriteLine(list.IndexOf(0));
            Console.WriteLine(list.Contains(-10));
            Console.WriteLine(list.Contains(-9));
            Console.WriteLine(list.Size());
        }
    }
}