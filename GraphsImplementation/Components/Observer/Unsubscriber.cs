using System;
using System.Collections.Generic;

namespace GraphsImplementation.Components.Observer {
	internal class Unsubscriber<T> : IDisposable {
		private readonly List<IObserver<Node<T>>> aObservers = default;
		private readonly IObserver<Node<T>> rObserver = default;

		public Unsubscriber(List<IObserver<Node<T>>> aObservers, IObserver<Node<T>> rObserver) {
			this.aObservers = aObservers;
			this.rObserver = rObserver;
		}

		public void Dispose() {
			if (this.aObservers.Contains(this.rObserver)) {
				this.aObservers.Remove(this.rObserver);
			}
		}
	}
}
