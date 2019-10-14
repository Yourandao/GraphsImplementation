using System.Collections;
using System.Collections.Generic;
using LeskoGraphs.Components.Interfaces;

namespace LeskoGraphs.Components {

    public delegate void Update(string message);
    public sealed class Graph<T> : IEnumerable<T>, IObservable<T> {

        //------------------------------------------

        public  readonly List<Node<T>>       nodes   = default;
        private readonly List<IResultWaiter> waiters = default;

        public  int        iNodesCount = default;
        public  List<T>    bypass      = default;

        private ITraversal travelsar = default;

        public event Update OnUpdate;

        //------------------------------------------

        public Graph(ITraversal travelsar) {
            this.nodes = new List<Node<T>>();
            this.waiters = new List<IResultWaiter>();

            this.travelsar = travelsar;
        }

        public void SetTraversal(ITraversal travelsal) {
            this.travelsar = travelsal;
        }

        public void AddNode(Node<T> node) {
            this.nodes.Add(node);

            ++this.iNodesCount;
        }

        public void AddNeighbour(int iIndexFrom, params int[] neighbours) {
            for (int i = 0; i < neighbours.Length; i++) {
                this.nodes[iIndexFrom].AddNeighbour(this.nodes[neighbours[i]]);
            }
        }

        //------------------------------------------

        public void AddWaiter(IResultWaiter waiter) {
            this.waiters.Add(waiter);
        }

        public void RemoveWaiter(IResultWaiter waiter) {
            this.waiters.Remove(waiter);
        }

        public void NotifyWaiters(string sMessage) {
            for (int i = 0; i < this.waiters.Count; i++) {
                this.waiters[i].Update(sMessage);
            }

            //OnUpdate?.Invoke(sMessage);
        }

        //------------------------------------------

        public IEnumerator<T> GetEnumerator() {
            this.travelsar.Travel(this);
            foreach (var item in this.bypass) {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
