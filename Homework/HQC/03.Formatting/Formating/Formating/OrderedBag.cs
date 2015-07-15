// new ver

namespace EventHandler
{
    using System.Collections;
    using System.Collections.Generic;

    internal class OrderedBag<T>
    {
        internal void Add(Event newEvent)
        {
            throw new System.NotImplementedException();
        }

        internal OrderedBag<Event>.View RangeFrom(Event p1, bool p2)
        {
            throw new System.NotImplementedException();
        }

        internal void Remove(object eventToRemove)
        {
            throw new System.NotImplementedException();
        }

        public class View : IEnumerable<Event>
        {
            public IEnumerator<Event> GetEnumerator()
            {
                throw new System.NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}
