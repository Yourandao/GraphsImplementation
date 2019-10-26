using System.Collections;
using System.Collections.Generic;

namespace GraphsImplementation.Components.Interfaces {
	public interface ITraveler<T> {
		IEnumerable<Node<T>> aSupportContainer { get; set; }

		HashSet<Node<T>> aSupportDiscovered { get; set; }

		IEnumerator Travel(Graph<T> rGraph);
	}
}
