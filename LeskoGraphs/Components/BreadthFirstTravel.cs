using System.Collections.Generic;
using System.Linq;

namespace LeskoGraphs.Components {
    public class BreathFirstTravel : ITraversal {
        public void Travel<T>(Graph<T> graph) {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(graph.nodes[0]);

            while (queue.Any()) {

            }
        }
    }
}
