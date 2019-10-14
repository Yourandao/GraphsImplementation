using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeskoGraphs.Components {
    public sealed class Graph<T> : IEnumerable<T> {
        public int iNodesCount = default;
        private List<Node<T>> nodes = default;
        private List<T> bypass = default;

        private Dictionary<Node<T>, int> visited = default;

        public Graph() {
            this.nodes = new List<Node<T>>();
        }

        public Graph(int count) {
            this.iNodesCount = count;
            this.nodes = new List<Node<T>>();
        }

        public void AddNode(Node<T> node) {
            this.nodes.Add(node);
            ++this.iNodesCount;
        }

        public void AddNeighbour(int index, Node<T> node) {
            if (index >= this.nodes.Count)
                return;

            this.nodes[index].AddNeighbour(node);
        }

        public void AddNeighbour(int iIndexFrom, int iIndexTo) {
            this.nodes[iIndexFrom].AddNeighbour(this.nodes[iIndexTo]);
        }

        private void DepthFirstSearch() {
            this.visited = new Dictionary<Node<T>, int>();
            this.bypass = new List<T>();

            for (int i = 0; i < this.iNodesCount; i++) {
                this.visited.Add(this.nodes[i], 0);
            }

            this.DepthFirstSearch(this.nodes[0]);

            for (int i = 0; i < this.iNodesCount; ++i) {
                if (this.visited[this.nodes[i]] == 0) {
                    this.DepthFirstSearch(this.nodes[i]);
                }
            }
        }

        private void DepthFirstSearch(Node<T> node) {
            this.visited[node] = 1;

            foreach (var child in node.lnNeighbours.Where(x => this.visited[x] != 2)) {
                if (this.visited[child] == 0) {
                    this.DepthFirstSearch(child);
                }
            }

            this.bypass.Add(node.tValue);
            this.visited[node] = 2;
        }

        public IEnumerator<T> GetEnumerator() {
            DepthFirstSearch();
            foreach (var item in this.bypass) {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
