using System.Collections.Generic;

namespace GraphsImplementation.Components {
	public class Node<T> {
		public readonly T tValue = default;
		public readonly List<Node<T>> aNeighbours = default;

		public Node(T value) {
			this.tValue = value;
			this.aNeighbours = new List<Node<T>>();
		}

		public void AddNeighbour(Node<T> rNode) {
			this.aNeighbours.Add(rNode);
		}
	}
}
