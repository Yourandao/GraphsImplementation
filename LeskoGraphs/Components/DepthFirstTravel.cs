using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeskoGraphs.Components {
    public class DepthFirstTravel : ITraversal {
        public void Travel<T>(Graph<T> graph) {
            Dictionary<Node<T>, int>  visited = new Dictionary<Node<T>, int>();
            graph.bypass  = new List<T>();

            for (int i = 0; i < graph.iNodesCount; i++) {
                visited.Add(graph.nodes[i], 0);
            }

            this.DepthFirstSearch(graph, visited, graph.nodes[0]);

            for (int i = 0; i < graph.iNodesCount; ++i) {
                if (visited[graph.nodes[i]] == 0) {
                    this.DepthFirstSearch(graph, visited, graph.nodes[i]);
                }
            }
        }

        private void DepthFirstSearch<T>(Graph<T> graph, Dictionary<Node<T>, int> visited, Node<T> node) {
            visited[node] = 1;

            foreach (var child in node.lnNeighbours.Where(x => visited[x] != 2)) {
                if (visited[child] == 0) {
                    this.DepthFirstSearch(graph, visited, child);
                }
            }

            graph.bypass.Add(node.tValue);
            visited[node] = 2;
        }
    }
}
