using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace automata_sharp
{
    public class UniqueSortedListInt : IList<int>
    {
        private List<int> list;

        public int this[int index] { get => list[index]; set => list[index] = value; }

        public int Count => list.Count;

        public bool IsReadOnly => false;


        public UniqueSortedListInt()
            : this(10)
        {

        }
        public UniqueSortedListInt(int capacity)
        {
            list = new List<int>(capacity);
        }
        public UniqueSortedListInt(IEnumerable<int> enumerable)
            : this(10)
        {
            foreach (var e in enumerable)
                Add(e);
        }

        public bool SetEquals(UniqueSortedListInt other)
        {
            if (other.list.Count != list.Count) return false;

            for (int i = 0; i < list.Count; i++)
                if (list[i] != other.list[i]) return false;

            return true;
        }

        public void Override(UniqueSortedListInt other)
        {
            list.Clear();
            var otherlist = other.list;
            for (int i = 0; i < otherlist.Count; i++)
                list.Add(otherlist[i]);
        }

        public bool Add(int item)
        {
            if (list.Contains(item)) return false;
            for (int i = 0; i < list.Count; i++)
                if (list[i] > item)
                {
                    list.Insert(i, item);
                    return true;
                }

            list.Add(item);

            return true;
        }

        void ICollection<int>.Add(int item)
        {
            Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(int item)
        {
            return list.Contains(item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(int item)
        {
            return list.IndexOf(item);
        }

        void IList<int>.Insert(int index, int item)
        {
            if (!list.Contains(item))
            {
                list.Insert(index, item);
            }
        }

        public bool Remove(int item)
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
