using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeskoGraphs.Components {
    public sealed class Graph<T> : IEnumerable<T> {
        public int iNodesCount = default;
        public List<Node<T>> nodes = default;
        public List<T> bypass = default;

        public Dictionary<Node<T>, int> visited = default;

        public ITraversal travelMethod = default;

        public Graph(ITraversal method) {
            this.nodes = new List<Node<T>>();
            this.travelMethod = method;
        }

        public void AddNode(Node<T> node) {
            this.nodes.Add(node);
            ++this.iNodesCount;
        }

        public void AddNeighbour(int iIndexFrom, int iIndexTo) {
            this.nodes[iIndexFrom].AddNeighbour(this.nodes[iIndexTo]);
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
