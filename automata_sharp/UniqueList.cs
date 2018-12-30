using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata_sharp
{
    public class UniqueList<T> : IList<T>
    {
        private List<T> list;

        public T this[int index] { get => list[index]; set => list[index] = value; }

        public int Count => list.Count;

        public bool IsReadOnly => false;


        public UniqueList()
            : this(10)
        {

        }
        public UniqueList(int capacity)
        {
            list = new List<T>(capacity);
        }
        public UniqueList(IEnumerable<T> enumerable)
            : this(10)
        {
            foreach (var e in enumerable)
                Add(e);
        }

        public bool SetEquals(UniqueList<T> other)
        {
            if (other.list.Count != list.Count) return false;

            list.Sort();
            other.list.Sort();

            for(int i = 0; i < list.Count; i++)
                if (!list[i].Equals(other.list[i])) return false;

            return true;
        }

        public void Override(UniqueList<T> other)
        {
            list.Clear();
            var otherlist = other.list;
            for (int i = 0; i < otherlist.Count; i++)
                list.Add(otherlist[i]);
        }

        public bool Add(T item)
        {
            if (list.Contains(item)) return false;
            list.Add(item);
            return true;
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        void IList<T>.Insert(int index, T item)
        {
            if (!list.Contains(item))
                list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
