using System.Collections;
using System.Collections.Generic;
using LeskoGraphs.Components.Interfaces;

namespace LeskoGraphs.Components {

    public delegate void Update(string message);
    public sealed class Graph<T> : IEnumerable<T>, IObservable<T> {

        //------------------------------------------

        public  readonly List<Node<T>>       lnNodes   = default;
        private readonly List<IResultWaiter> lwWaiters = default;

        public int iNodesCount = default;
        public readonly List<T> path = default;

        private ITraveler travelsar = default;

        public event Update OnUpdate;

        //------------------------------------------

        public Graph(ITraveler travelsar) {
            this.lnNodes   = new List<Node<T>>();
            this.path  = new List<T>();
            this.lwWaiters = new List<IResultWaiter>();

            this.travelsar = travelsar;
        }

        public void SetTraversal(ITraveler travelsal) => this.travelsar = travelsal;

        public void AddNode(Node<T> node) {
            this.lnNodes.Add(node);

            ++this.iNodesCount;
        }

        public void AddNeighbour(int iIndexFrom, params int[] neighbours) {
            for (int i = 0; i < neighbours.Length; i++) {
                this.lnNodes[iIndexFrom].AddNeighbour(this.lnNodes[neighbours[i]]);
            }
        }

        //------------------------------------------

        public void AddWaiter(IResultWaiter waiter) {
            this.lwWaiters.Add(waiter);
        }

        public void RemoveWaiter(IResultWaiter waiter) {
            this.lwWaiters.Remove(waiter);
        }

        public void NotifyWaiters(string sMessage) {
            for (int i = 0; i < this.lwWaiters.Count; i++) {
                this.lwWaiters[i].Update(sMessage);
            }

            //OnUpdate?.Invoke(sMessage);
        }

        //------------------------------------------

        public IEnumerator<T> GetEnumerator() {
            this.travelsar.Travel(this);
            foreach (var item in this.path) {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
