// new ver

namespace EventHandler
{
    using System.Collections;

    internal class MultiDictionary<T1, T2>
    {
        private bool p;

        public MultiDictionary(bool p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public IEnumerable this[string title]
        {
            get { throw new System.NotImplementedException(); }
        }

        internal void Add(string p, Event newEvent)
        {
            throw new System.NotImplementedException();
        }

        internal void Remove(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}
