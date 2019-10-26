using System.Collections;
using System.Collections.Generic;
using LeskoGraphs.Components.Interfaces;

namespace LeskoGraphs.Components {

    public delegate void Update(string message);
    public sealed class Graph<T> : IEnumerable<T>, IEnumerator<T>, IObservable<T> {

        //------------------------------------------
        public  int iNodesCount = default;

        public  readonly List<Node<T>> aNodes = default;
        public  readonly List<T> aPath = default;

        public  event Update OnUpdate;

        private readonly List<IResultWaiter> aWaiters = default;

        private ITraveler travelsar = default;
        private int iCurrentItemIndex = -1;

		//------------------------------------------

		public Graph(ITraveler rTravelsar) {
            this.aNodes = new List<Node<T>>();
            this.aPath  = new List<T>();
            this.aWaiters = new List<IResultWaiter>();

            this.travelsar = rTravelsar;
        }

		public void AddNode(Node<T> rNode) {
            this.aNodes.Add(rNode);

            ++this.iNodesCount;
        }

        public void AddNeighbour(int iIndexFrom, params int[] aNeighbours) {
            for (int item = 0; item < aNeighbours.Length; item++) {
                this.aNodes[iIndexFrom].AddNeighbour(this.aNodes[aNeighbours[item]]);
            }
        }

        //------------------------------------------
        public void SetTraversal(ITraveler rTravelsal) => this.travelsar = rTravelsal;

        public void AddWaiter(IResultWaiter rWaiter) => this.aWaiters.Add(rWaiter);

        public void RemoveWaiter(IResultWaiter rWaiter) => this.aWaiters.Remove(rWaiter);

        public void NotifyWaiters(string sMessage) => OnUpdate?.Invoke(sMessage);

        //------------------------------------------

        public T Current {
	        get => this.aPath[this.iCurrentItemIndex];
        }

        object IEnumerator.Current {
	        get => this.aPath[this.iCurrentItemIndex];
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
            this.aPath.Clear();
        }

        public bool MoveNext() => ++this.iCurrentItemIndex < this.aPath.Count;

        public void Reset() => this.iCurrentItemIndex = -1;
    }
}
