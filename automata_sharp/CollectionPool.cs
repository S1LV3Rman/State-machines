using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata_sharp
{
    public sealed class CollectionPool<T, CollectionT> : IReadOnlyCollection<T> 
        where T : ICollection<CollectionT> 
        //where CollectionT : struct
    {
        Stack<T> pool;
        Func<T> factory;

        public int Count => pool.Count;

        public bool IsReadOnly => false;

        public CollectionPool(Func<T> factory)
            : this(10,factory)
        {

        }

        public CollectionPool(IEnumerable<T> enumerable, Func<T> factory)
            :this(10,factory)
        {
            foreach (var e in enumerable)
                Push(e);
        }

        public CollectionPool(int capacity, Func<T> factory)
        {
            pool = new Stack<T>(capacity);
            this.factory = factory ?? throw new ArgumentNullException();
        }
        public void Push(T collection)
        {
            collection.Clear();//Чистим коллекию
            pool.Push(collection);
        }
        public T Pop()
        {
            var collection = pool.Count > 0 ? pool.Pop() : factory.Invoke();
            return collection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return pool.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return pool.GetEnumerator();
        }
    }
}
