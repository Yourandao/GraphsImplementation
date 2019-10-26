using LeskoGraphs.Components;
using LeskoGraphs.Components.Travels;
using System;

namespace LeskoGraphs {
	internal class Program {
		private static void Main(string[] args) {
			Graph<int> rGraph = new Graph<int>(new BreadthFirstTravel());

			Waiter<int> waiter = new Waiter<int>(rGraph);

			rGraph.AddWaiter(waiter);

			rGraph.AddNode(new Node<int>(0));
			rGraph.AddNode(new Node<int>(1));
			rGraph.AddNode(new Node<int>(2));
			rGraph.AddNode(new Node<int>(3));
			rGraph.AddNode(new Node<int>(4));
			rGraph.AddNode(new Node<int>(5));
			rGraph.AddNode(new Node<int>(6));

			rGraph.AddNeighbour(0, 1, 4);
			rGraph.AddNeighbour(1, 0, 2, 3);
			rGraph.AddNeighbour(2, 1);
			rGraph.AddNeighbour(3, 1, 4, 5);
			rGraph.AddNeighbour(4, 0, 3, 5);
			rGraph.AddNeighbour(5, 3, 4);

			using (var aGraphEnum = rGraph.GetEnumerator()) {
				while (aGraphEnum.MoveNext()) {
					Console.Write(aGraphEnum.Current + "->");
				}
				Console.WriteLine();
			}

			rGraph.SetTraversal(new DepthFirstTravel());

			Console.WriteLine(string.Join("->", rGraph));
		}
	}
}
