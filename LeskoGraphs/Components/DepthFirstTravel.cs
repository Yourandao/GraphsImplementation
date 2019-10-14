using LeskoGraphs.Components.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LeskoGraphs.Components {
    public class DepthFirstTravel : ITraveler {
        private enum Colors : int {
            White,
            Gray,
            Black
        }

        public void Travel<T>(Graph<T> graph) {
            graph.path.Clear();
            Dictionary<Node<T>, int> visited = new Dictionary<Node<T>, int>();

            for (int iter = 0; iter < graph.iNodesCount; iter++) {
                visited.Add(graph.lnNodes[iter], (int)Colors.White);
            }

            this.DepthFirstSearch(graph, visited, graph.lnNodes[0]);
        }

        private void DepthFirstSearch<T>(Graph<T> graph, Dictionary<Node<T>, int> visited, Node<T> node) {
            visited[node] = (int)Colors.Gray;
            List<Node<T>> lnNotVisited = node.lnNeighbours.FindAll(item => visited[item] != (int)Colors.Black).ToList();

            for (int i = 0; i < lnNotVisited.Count; i++) {
                Node<T> child = lnNotVisited[i];

                if (visited[child] == (int)Colors.White) {
                    this.DepthFirstSearch(graph, visited, child);
                }
            }

            graph.NotifyWaiters($"New node - { node.tValue } has been added to the path in DFS");

            graph.path.Add(node.tValue);
            visited[node] = (int)Colors.Black;
        }
    }
}
