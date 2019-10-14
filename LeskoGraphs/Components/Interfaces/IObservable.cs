namespace LeskoGraphs.Components.Interfaces {
    public interface IObservable<T> {
        event Update OnUpdate;

        void AddWaiter(IResultWaiter waiter);
        void RemoveWaiter(IResultWaiter waiter);
        void NotifyWaiters(string sMessage);
        void AddNode(Node<T> node);
    }
}
