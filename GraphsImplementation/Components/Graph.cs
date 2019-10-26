using System.Collections;
using System.Collections.Generic;
using GraphsImplementation.Components.Interfaces;
using GraphsImplementation.Components.Observer;

namespace GraphsImplementation.Components {
	public class Graph<T> : IEnumerable {

		//----------------------------------------------------
		private ITraveler<T> TravelMethod { get; set; }

		public NodeProcessor<T> Notifier { get; }

		public List<Node<T>> Nodes { get; }

		public int Count { get; private set; }

		//----------------------------------------------------

		public Graph(ITraveler<T> aTravel) {
			this.TravelMethod = aTravel;

			this.Nodes = new List<Node<T>>();
			this.Notifier = new NodeProcessor<T>();
		}

		public void SetTraveler(ITraveler<T> rTravel) {
			this.TravelMethod = rTravel;
		}

		public void AddNode(Node<T> node) {
			this.Nodes.Add(node);

			++this.Count;
		}

		public void AddNeighbour(int iIndexFrom, params int[] neighbours) {
			for (int i = 0; i < neighbours.Length; i++) {
				this.Nodes[iIndexFrom].AddNeighbour(this.Nodes[neighbours[i]]);
			}
		}

		public IEnumerator GetEnumerator() {
			return this.TravelMethod.Travel(this);
		}
	}
}
