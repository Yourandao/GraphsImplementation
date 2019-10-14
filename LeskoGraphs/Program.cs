using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeskoGraphs.Components;

namespace LeskoGraphs {
    class Program {
        static void Main(string[] args) {
            Graph<int> graph = new Graph<int>(new DepthFirstTravel());

            graph.AddNode(new Node<int>(0));
            graph.AddNode(new Node<int>(1));
            graph.AddNode(new Node<int>(2));
            graph.AddNode(new Node<int>(3));
            graph.AddNode(new Node<int>(4));
            graph.AddNode(new Node<int>(5));
            graph.AddNode(new Node<int>(6));

            graph.AddNeighbour(0, 1);
            graph.AddNeighbour(0, 4);
            graph.AddNeighbour(1, 0);
            graph.AddNeighbour(1, 2);
            graph.AddNeighbour(1, 3);
            graph.AddNeighbour(2, 1);
            graph.AddNeighbour(3, 1);
            graph.AddNeighbour(3, 4);
            graph.AddNeighbour(3, 5);
            graph.AddNeighbour(4, 0);
            graph.AddNeighbour(4, 3);
            graph.AddNeighbour(4, 5);
            graph.AddNeighbour(5, 3);
            graph.AddNeighbour(5, 4);

            Console.WriteLine(string.Join("->", graph));
        }
    }
}
