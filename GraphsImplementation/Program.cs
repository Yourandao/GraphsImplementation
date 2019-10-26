using System;
using GraphsImplementation.Components;
using GraphsImplementation.Components.Observer;
using GraphsImplementation.Components.Travels;

namespace GraphsImplementation {
	class Program {
		static void Main(string[] args) {
			Graph<int> graph = new Graph<int>(new BreadthFirstTravel<int>());

			graph.Notifier.Subscribe(new Waiter<int>());

			graph.AddNode(new Node<int>(0));
			graph.AddNode(new Node<int>(1));
			graph.AddNode(new Node<int>(2));
			graph.AddNode(new Node<int>(3));
			graph.AddNode(new Node<int>(4));
			graph.AddNode(new Node<int>(5));
			graph.AddNode(new Node<int>(6));

			graph.AddNeighbour(0, 1, 4);
			graph.AddNeighbour(1, 0, 2, 3);
			graph.AddNeighbour(2, 1);
			graph.AddNeighbour(3, 1, 4, 5);
			graph.AddNeighbour(4, 0, 3, 5);
			graph.AddNeighbour(5, 3, 4);

			foreach (var node in graph) {
				Console.Write(node + "->");
			}

			Console.WriteLine();

			graph.SetTraveler(new DepthFirstTravel<int>());

			foreach (var node in graph) {
				Console.Write(node + "->");
			}

			Console.WriteLine();
		}
	}
}
