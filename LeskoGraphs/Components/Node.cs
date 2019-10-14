using System.Collections.Generic;

namespace LeskoGraphs.Components {
    public sealed class Node<T> {
        public readonly T tValue = default;
        public readonly List<Node<T>> lnNeighbours = default;

        public Node(T value) {
            this.tValue = value;
            this.lnNeighbours = new List<Node<T>>();
        }

        public void AddNeighbour(Node<T> node) {
            this.lnNeighbours.Add(node);
        }
    }
}
