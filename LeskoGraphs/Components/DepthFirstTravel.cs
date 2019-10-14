using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeskoGraphs.Components {
    public class DepthFirstTravel : ITraversal {
        public void Travel<T>(Graph<T> graph) {
            graph.visited = new Dictionary<Node<T>, int>();
            graph.bypass  = new List<T>();

            for (int i = 0; i < graph.iNodesCount; i++) {
                graph.visited.Add(graph.nodes[i], 0);
            }

            this.DepthFirstSearch(graph, graph.nodes[0]);

            for (int i = 0; i < graph.iNodesCount; ++i) {
                if (graph.visited[graph.nodes[i]] == 0) {
                    this.DepthFirstSearch(graph, graph.nodes[i]);
                }
            }
        }

        private void DepthFirstSearch<T>(Graph<T> graph, Node<T> node) {
            graph.visited[node] = 1;

            foreach (var child in node.lnNeighbours.Where(x => graph.visited[x] != 2)) {
                if (graph.visited[child] == 0) {
                    this.DepthFirstSearch(graph, child);
                }
            }

            graph.bypass.Add(node.tValue);
            graph.visited[node] = 2;
        }
    }
}
