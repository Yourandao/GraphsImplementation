using LeskoGraphs.Components.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LeskoGraphs.Components.Travels {
    public class BreadthFirstTravel : ITraveler {
        public void Travel<T>(Graph<T> rGraph) {
            Queue<Node<T>>   queue   = new Queue<Node<T>>();
            HashSet<Node<T>> visited = new HashSet<Node<T>>();

            rGraph.aPath.Clear();

            queue.Enqueue(rGraph.aNodes[0]);
            rGraph.aPath.Add(rGraph.aNodes[0].tValue);

            visited.Add(rGraph.aNodes[0]);

            while (queue.Any()) {
                Node<T> head = queue.First();
                List<Node<T>> lnNotVisited = head.aNeighbours.Where(kid => !visited.Contains(kid)).ToList();

                queue.Dequeue();

                for (int i = 0; i < lnNotVisited.Count; i++) {
                    Node<T> child = lnNotVisited[i];
                    queue.Enqueue(child);

                    rGraph.NotifyWaiters($"New node - { child.tValue } has been added to the path in BFS");

                    rGraph.aPath.Add(child.tValue);
                    visited.Add(child);
                }
            }
        }
    }
}
