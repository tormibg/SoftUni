using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Tree_Data_Homework
{
	class Root_Node
	{
		static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
		static void Main(string[] args)
		{
			//int numbersOfNode = int.Parse(Console.ReadLine());

			//for (int i = 0; i < numbersOfNode-1; i++)
			//{
			//    int[] nodes = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			//    int parent = nodes[0];
			//    int child = nodes[1];

			//    if (!nodeByValue.ContainsKey(parent))
			//    {
			//        nodeByValue.Add(parent, new Tree<int>(parent));
			//    }

			//    if (!nodeByValue.ContainsKey(child))
			//    {
			//        nodeByValue.Add(child, new Tree<int>(child));
			//    }

			//    Tree<int> parentNode = nodeByValue[parent];
			//    Tree<int> childNode = nodeByValue[child];
			//    parentNode.Children.Add(childNode);
			//    childNode.Parent = parentNode;

			ReadTree();
			//Tree<int> root = GetRootNode();
			//Console.WriteLine($"Root node: {root.Value}");

			//List<int> leaf = GetLeafNode();
			//Console.WriteLine($"Leaf nodes: {string.Join(" ",leaf)}");

			//List<int> middleNodeList = GetMiddleNode();
			//Console.WriteLine($"Middle nodes: {string.Join(" ",middleNodeList)}");

			//Tree<int> deepestNode = GetDeepestNode();
			//Console.WriteLine($"Deepest node: {deepestNode.Value}");

			//Stack<int> nodespPath = GetLongestPath();
			//Console.WriteLine($"Longest path: {String.Join(" ",nodespPath)}");

			//GetAllPathsWithAGivenSum();

			GetAllSubtreesWithGivenSum();
		}

		private static void GetAllPathsWithAGivenSum()
		{
			int targetSum = Convert.ToInt32(Console.ReadLine());
			Tree<int> root = GetRootNode();
			Console.WriteLine($"Paths of sum {targetSum}: ");
			DFSTargetSum(root, targetSum);
		}

		private static void DFSTargetSum(Tree<int> node, int targetSum, int sum = 0)
		{
			sum += node.Value;
			if (targetSum == sum)
			{
				PrintPath(node);
			}

			foreach (Tree<int> child in node.Children)
			{
				DFSTargetSum(child, targetSum, sum);
			}
		}

		private static void PrintPath(Tree<int> node)
		{
			Stack<int> pathStack = new Stack<int>();
			while (node != null)
			{
				pathStack.Push(node.Value);
				node = node.Parent;
			}
			Console.WriteLine($"{String.Join(" ", pathStack)}");
		}

		private static void GetAllSubtreesWithGivenSum()
		{
			int targetSum = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine($"Subtrees of sum {targetSum}:");
			Tree<int> root = GetRootNode();
			List<Tree<int>> nodes = new List<Tree<int>>();
			DFS(root, nodes);

			foreach (Tree<int> node in nodes)
			{
				int sum = CalculateSumOfNodes(node);
				if (sum == targetSum)
				{
					List<int> subtree = new List<int>();
					GetSubTreeNodes(node, subtree);
					Console.WriteLine($"{String.Join(" ", subtree)}");
				}
			}

		}

		private static void GetSubTreeNodes(Tree<int> node, List<int> subtree)
		{
			subtree.Add(node.Value);
			foreach (Tree<int> child in node.Children)
			{
				GetSubTreeNodes(child, subtree);
			}
		}

		private static int CalculateSumOfNodes(Tree<int> node)
		{
			int sum = node.Value;
			foreach (Tree<int> child in node.Children)
			{
				sum += CalculateSumOfNodes(child);
			}

			return sum;
		}

		private static void DFS(Tree<int> root, List<Tree<int>> nodes)
		{
			foreach (Tree<int> child in root.Children)
			{
				DFS(child, nodes);
			}
			nodes.Add(root);
		}

		private static Stack<int> GetLongestPath()
		{
			Tree<int> deepestNode = GetDeepestNode();
			Stack<int> nodesPathStack = new Stack<int>();
			while (deepestNode != null)
			{
				nodesPathStack.Push(deepestNode.Value);
				deepestNode = deepestNode.Parent;
			}

			return nodesPathStack;
		}

		private static Tree<int> GetDeepestNode()
		{
			List<Tree<int>> leafs = nodeByValue.Values.Where(x => x.Children.Count == 0).ToList();
			Tree<int> deepestNode = GetRootNode();
			int maxDeep = 0;
			foreach (Tree<int> leaf in leafs)
			{
				Tree<int> currNode = leaf;
				int curDeep = 1;
				while (currNode.Parent != null)
				{
					curDeep++;
					currNode = currNode.Parent;
				}

				if (curDeep > maxDeep)
				{
					maxDeep = curDeep;
					deepestNode = leaf;
				}
			}

			return deepestNode;
		}


		private static List<int> GetMiddleNode()
		{
			List<int> nodes = nodeByValue.Values.Where(x => x.Children.Count != 0 && x.Parent != null)
				.OrderBy(x => x.Value).Select(x => x.Value).ToList();
			return nodes;
		}

		private static List<int> GetLeafNode()
		{
			List<int> leafs = nodeByValue.Values.Where(x => x.Children.Count == 0).OrderBy(x => x.Value)
				.Select(x => x.Value).ToList();
			return leafs;
		}

		private static Tree<int> GetRootNode()
		{
			Tree<int> root = nodeByValue.Values.FirstOrDefault(x => x.Parent == null);
			return root;
		}

		private static void ReadTree()
		{
			int nodeCount = int.Parse(Console.ReadLine());
			for (int i = 0; i < nodeCount - 1; i++)
			{
				int[] nodes = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
				AddEdge(nodes[0], nodes[1]);
			}
		}

		private static void AddEdge(int parent, int child)
		{
			Tree<int> parentNode = GetTreeNodeByValue(parent);
			Tree<int> childNode = GetTreeNodeByValue(child);

			parentNode.Children.Add(childNode);
			childNode.Parent = parentNode;
		}

		private static Tree<int> GetTreeNodeByValue(int node)
		{
			if (!nodeByValue.ContainsKey(node))
			{
				nodeByValue[node] = new Tree<int>(node);
			}

			return nodeByValue[node];
		}
	}
}
