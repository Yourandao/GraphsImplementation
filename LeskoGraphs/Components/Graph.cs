using System.Collections;
using System.Collections.Generic;
using LeskoGraphs.Components.Interfaces;

namespace LeskoGraphs.Components {

    public delegate void Update(string message);
    public sealed class Graph<T> : IEnumerable<T>, IEnumerator<T>, IObservable<T> {

        //------------------------------------------
        public int iNodesCount = default;

        public readonly List<Node<T>> lnNodes = default;
        public readonly List<T> path = default;

        public event Update OnUpdate;

        private readonly List<IResultWaiter> lwWaiters = default;

        private ITraveler travelsar = default;
        private int iCurrentItemIndex = -1;

		//------------------------------------------

		public Graph(ITraveler travelsar) {
            this.lnNodes = new List<Node<T>>();
            this.path  = new List<T>();
            this.lwWaiters = new List<IResultWaiter>();

            this.travelsar = travelsar;
        }

		public void AddNode(Node<T> node) {
            this.lnNodes.Add(node);

            ++this.iNodesCount;
        }

        public void AddNeighbour(int iIndexFrom, params int[] neighbours) {
            for (int item = 0; item < neighbours.Length; item++) {
                this.lnNodes[iIndexFrom].AddNeighbour(this.lnNodes[neighbours[item]]);
            }
        }

        //------------------------------------------
        public void SetTraversal(ITraveler travelsal) => this.travelsar = travelsal;

        public void AddWaiter(IResultWaiter waiter) => this.lwWaiters.Add(waiter);

        public void RemoveWaiter(IResultWaiter waiter) => this.lwWaiters.Remove(waiter);

        public void NotifyWaiters(string sMessage) => OnUpdate?.Invoke(sMessage);

        //------------------------------------------

        public T Current {
	        get => this.path[this.iCurrentItemIndex];
        }

        object IEnumerator.Current {
	        get => this.path[this.iCurrentItemIndex];
        }

        public IEnumerator<T> GetEnumerator() {
            this.travelsar.Travel(this);

            return this;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void Dispose() {
	        this.iCurrentItemIndex = -1;
            this.path.Clear();
        }

        public bool MoveNext() => ++this.iCurrentItemIndex < this.path.Count;

        public void Reset() => this.iCurrentItemIndex = -1;
    }
}
