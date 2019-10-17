using System;
using System.Collections.Generic;
using LeskoGraphs.Components;

namespace LeskoGraphs {
    internal class Program {
        private static void Main(string[] args) {
            Graph<int> graph = new Graph<int>(new BreadthFirstTravel());

            Waiter<int> waiter = new Waiter<int>(graph);

            graph.AddWaiter(waiter);

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

            var a  = graph.GetEnumerator();
            Console.WriteLine(a.Current);
            a.MoveNext();
            Console.WriteLine(a.Current);


            //Console.WriteLine(string.Join("->", graph));

            //graph.SetTraversal(new DepthFirstTravel());

            //Console.WriteLine(string.Join("->", graph));
        }
    }
}
