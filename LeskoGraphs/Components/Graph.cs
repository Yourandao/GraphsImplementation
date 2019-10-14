using System.Collections;
using System.Collections.Generic;

namespace LeskoGraphs.Components {
    public sealed class Graph<T> : IEnumerable<T> {
        public readonly List<Node<T>> nodes = default;

        public int        iNodesCount = default;
        public List<T>    bypass      = default;

        public ITraversal travelMethod = default;

        public Graph(ITraversal travelMethod) {
            this.nodes = new List<Node<T>>();
            this.travelMethod = travelMethod;
        }

        public void AddNode(Node<T> node) {
            this.nodes.Add(node);
            ++this.iNodesCount;
        }

        public void AddNeighbour(int iIndexFrom, params int[] neighbours) {
            for (int i = 0; i < neighbours.Length; i++) {
                this.nodes[iIndexFrom].AddNeighbour(this.nodes[neighbours[i]]);
            }
        }

        public IEnumerator<T> GetEnumerator() {
            this.travelMethod.Travel(this);
            foreach (var item in this.bypass) {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
