using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Student : IObservable
    {
        private String firstName;
        private String lastName;

        public String FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                Notify();
            }
        }
        public String LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                Notify();
            }
        }

        private List<IObserver> observersList = new List<IObserver>();

        public void Notify()
        {
            foreach (var observer in observersList)
            {
                observer.Update(this);
            }
        }

        public void Subscribe(IObserver observer)
        {
            observersList.Add(observer);
        }
    }
}
