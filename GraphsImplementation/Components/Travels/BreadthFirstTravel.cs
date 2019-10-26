using GraphsImplementation.Components.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GraphsImplementation.Components.Travels {
	internal class BreadthFirstTravel<T> : ITraveler<T> {
		public IEnumerable<Node<T>> aSupportContainer { get; set; }
		public HashSet<Node<T>> aSupportDiscovered { get; set; }

		public BreadthFirstTravel() {
			this.aSupportContainer = new Queue<Node<T>>();
			this.aSupportDiscovered = new HashSet<Node<T>>();
		}

		public IEnumerator Travel(Graph<T> rGraph) {
			(this.aSupportContainer as Queue<Node<T>>)?.Enqueue(rGraph.Nodes[0]);
			this.aSupportDiscovered.Add(rGraph.Nodes[0]);

			rGraph.Notifier.Notify(rGraph.Nodes[0]);

			yield return rGraph.Nodes[0].tValue;

			while (this.aSupportContainer.Any()) {
				Node<T> head = (this.aSupportContainer as Queue<Node<T>>)?.Dequeue();
				List<Node<T>> lnNotVisited = head.aNeighbours.Where(kid => !this.aSupportDiscovered.Contains(kid)).ToList();

				for (int i = 0; i < lnNotVisited.Count; i++) {
					Node<T> child = lnNotVisited[i];

					(this.aSupportContainer as Queue<Node<T>>)?.Enqueue(child);
					this.aSupportDiscovered.Add(child);

					rGraph.Notifier.Notify(child);

					yield return child.tValue;
				}
			}

			rGraph.Notifier.NotifyComplete();
		}
	}
}
