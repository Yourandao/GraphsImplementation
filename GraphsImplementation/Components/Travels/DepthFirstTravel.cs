using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GraphsImplementation.Components.Interfaces;

namespace GraphsImplementation.Components.Travels {
	class DepthFirstTravel<T> : ITraveler<T> {
		public IEnumerable<Node<T>> aSupportContainer { get; set; }
		public HashSet<Node<T>> aSupportDiscovered { get; set; }

		public DepthFirstTravel() {
			this.aSupportContainer = new Stack<Node<T>>();
			this.aSupportDiscovered = new HashSet<Node<T>>();
		}

		public IEnumerator Travel(Graph<T> rGraph) {
			(this.aSupportContainer as Stack<Node<T>>)?.Push(rGraph.Nodes[0]);

			while (this.aSupportContainer.Any()) {
				Node<T> rPoppedNode = (this.aSupportContainer as Stack<Node<T>>)?.Pop();

				if (this.aSupportDiscovered.Contains(rPoppedNode)) {
					continue;
				}

				this.aSupportDiscovered.Add(rPoppedNode);

				rGraph.Notifier.Notify(rPoppedNode);

				yield return rPoppedNode.tValue;

				for (int i = 0; i < rPoppedNode.aNeighbours.Count; i++) {
					if (!this.aSupportDiscovered.Contains(rPoppedNode.aNeighbours[i])) {
						(this.aSupportContainer as Stack<Node<T>>)?.Push(rPoppedNode.aNeighbours[i]);
					}
				}
			}

			rGraph.Notifier.NotifyComplete();
		}
	}
}
