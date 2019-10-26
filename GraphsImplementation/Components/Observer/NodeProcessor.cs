using System;
using System.Collections.Generic;

namespace GraphsImplementation.Components.Observer {
	public class NodeProcessor<T> : IObservable<Node<T>> {
		private readonly List<IObserver<Node<T>>> aWaiters = default;

		public NodeProcessor() {
			this.aWaiters = new List<IObserver<Node<T>>>();
		}

		public void Notify(Node<T> rNode) {
			for (int i = 0; i < this.aWaiters.Count; i++) {
				this.aWaiters[i].OnNext(rNode);
			}
		}

		public void NotifyComplete() {
			for (int i = 0; i < this.aWaiters.Count; i++) {
				this.aWaiters[i].OnCompleted();
			}
		}

		public IDisposable Subscribe(IObserver<Node<T>> observer) {
			if (!this.aWaiters.Contains(observer)) {
				this.aWaiters.Add(observer);
			}

			return new Unsubscriber<T>(this.aWaiters, observer);
		}
	}
}
