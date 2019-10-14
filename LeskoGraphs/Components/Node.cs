using System.Collections.Generic;

namespace LeskoGraphs.Components {
    public sealed class Node<T> {
        public T tValue = default;
        public List<Node<T>> lnNeighbours = default;

        public Node() {
            this.lnNeighbours = new List<Node<T>>();
        }

        public Node(T value) {
            this.tValue = value;
            this.lnNeighbours = new List<Node<T>>();
        }

        public void AddNeighbour(Node<T> node) {
            this.lnNeighbours.Add(node);
        }
    }
}
