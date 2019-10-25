using LeskoGraphs.Components.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LeskoGraphs.Components.Travels {
    public class BreadthFirstTravel : ITraveler {
        public void Travel<T>(Graph<T> graph) {
            Queue<Node<T>>   queue   = new Queue<Node<T>>();
            HashSet<Node<T>> visited = new HashSet<Node<T>>();

            graph.path.Clear();

            queue.Enqueue(graph.lnNodes[0]);
            graph.path.Add(graph.lnNodes[0].tValue);

            visited.Add(graph.lnNodes[0]);

            while (queue.Any()) {
                Node<T> head = queue.First();
                List<Node<T>> lnNotVisited = head.lnNeighbours.Where(kid => !visited.Contains(kid)).ToList();

                queue.Dequeue();

                for (int i = 0; i < lnNotVisited.Count; i++) {
                    Node<T> child = lnNotVisited[i];
                    queue.Enqueue(child);

                    graph.NotifyWaiters($"New node - { child.tValue } has been added to the path in BFS");

                    graph.path.Add(child.tValue);
                    visited.Add(child);
                }
            }
        }
    }
}
