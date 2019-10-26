using LeskoGraphs.Components.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LeskoGraphs.Components.Travels {
    public class DepthFirstTravel : ITraveler {
        private enum Colors : int {
            White,
            Gray,
            Black
        }

        public void Travel<T>(Graph<T> rGraph) {
            rGraph.aPath.Clear();
            Dictionary<Node<T>, int> visited = new Dictionary<Node<T>, int>();

            for (int iter = 0; iter < rGraph.iNodesCount; iter++) {
                visited.Add(rGraph.aNodes[iter], (int)Colors.White);
            }

            this.DepthFirstSearch(rGraph, visited, rGraph.aNodes[0]);
        }

        private void DepthFirstSearch<T>(Graph<T> rGraph, Dictionary<Node<T>, int> visited, Node<T> rNode) {
            visited[rNode] = (int)Colors.Gray;
            List<Node<T>> lnNotVisited = rNode.aNeighbours.Where(item => visited[item] != (int)Colors.Black).ToList();

            for (int i = 0; i < lnNotVisited.Count; i++) {
                Node<T> child = lnNotVisited[i];

                if (visited[child] == (int)Colors.White) {
                    this.DepthFirstSearch(rGraph, visited, child);
                }
            }

            rGraph.NotifyWaiters($"New node - { rNode.tValue } has been added to the path in DFS");

            rGraph.aPath.Add(rNode.tValue);
            visited[rNode] = (int)Colors.Black;
        }
    }
}
