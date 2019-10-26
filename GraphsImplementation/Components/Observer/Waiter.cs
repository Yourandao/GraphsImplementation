using System;
using System.IO;

namespace GraphsImplementation.Components.Observer {
	public class Waiter<T> : IObserver<Node<T>> {
		private readonly string sFileName = default;

		public Waiter() {
			this.sFileName = "log." + Path.GetRandomFileName().Replace(".", "");
			File.AppendAllText(this.sFileName, $"[{ DateTime.Now }] - Beginning of waiting for data" + Environment.NewLine);
		}

		public void OnCompleted() {
			File.AppendAllText(this.sFileName, $"[{ DateTime.Now }] - End." + Environment.NewLine);
		}

		public void OnError(Exception error) {
			File.AppendAllText(this.sFileName, $"[{ DateTime.Now }] Error. {error}" + Environment.NewLine);
		}

		public void OnNext(Node<T> value) {
			File.AppendAllText(this.sFileName, $"[{ DateTime.Now }] - {value.tValue} has been added to our business logic" + Environment.NewLine);
		}
	}
}
