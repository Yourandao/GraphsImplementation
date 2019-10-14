using System;
using LeskoGraphs.Components.Interfaces;

namespace LeskoGraphs.Components {
    public class Waiter<T> : IResultWaiter {
        public Waiter(Interfaces.IObservable<T> @object) {
            @object.OnUpdate += this.Update;
        }

        public void Update(string sMessage) => Console.WriteLine(sMessage);
    }
}
