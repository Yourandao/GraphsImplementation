using System.Collections.Generic;
using System.Linq;

using Queue<T> = System.Collections.Generic.Queue<LeskoGraphs.Components.Node<T>>

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

                    graph.bypass.Add(child.tValue);
                    visited.Add(child);
                }
            }
        }
    }
}
