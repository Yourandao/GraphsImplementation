using System.Collections.Generic;
using System.Linq;

namespace LeskoGraphs.Components {
    public class DepthFirstTravel : ITraversal {
        private enum Colors : int {
            White,
            Gray,
            Black
        }

        public void Travel<T>(Graph<T> graph) {
            Dictionary<Node<T>, int> visited = new Dictionary<Node<T>, int>();
            graph.bypass = new List<T>();

            for (int iter = 0; iter < graph.iNodesCount; iter++) {
                visited.Add(graph.nodes[iter], (int)Colors.White);
            }

            this.DepthFirstSearch(graph, visited, graph.nodes[0]);
        }

        private void DepthFirstSearch<T>(Graph<T> graph, Dictionary<Node<T>, int> visited, Node<T> node) {
            visited[node] = (int)Colors.Gray;

            foreach (var child in node.lnNeighbours.Where(item => visited[item] != (int)Colors.Black)) {
                if (visited[child] == (int)Colors.White) {
                    this.DepthFirstSearch(graph, visited, child);
                }
            }

            graph.bypass.Add(node.tValue);
            visited[node] = (int)Colors.Black;
        }
    }
}
