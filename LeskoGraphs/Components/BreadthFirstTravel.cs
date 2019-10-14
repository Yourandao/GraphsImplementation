using LeskoGraphs.Components.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LeskoGraphs.Components {
    public class BreadthFirstTravel : ITraversal {
        public void Travel<T>(Graph<T> graph) {
            graph.bypass = new List<T>();

            Queue<Node<T>>   queue   = new Queue<Node<T>>();
            HashSet<Node<T>> visited = new HashSet<Node<T>>();

            queue.Enqueue(graph.nodes[0]);
            graph.bypass.Add(graph.nodes[0].tValue);

            visited.Add(graph.nodes[0]);

            while (queue.Any()) {
                Node<T> head = queue.First();
                queue.Dequeue();

                foreach (var child in head.lnNeighbours.Where(kid => !visited.Contains(kid))) {
                    queue.Enqueue(child);

                    graph.NotifyWaiters($"New node - { child.tValue } has been added to the path in BFS");

                    graph.bypass.Add(child.tValue);
                    visited.Add(child);
                }
            }
        }
    }
}
