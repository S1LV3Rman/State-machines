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
        private int[] list;
        int count;

        public int this[int index] { get => list[index]; set => list[index] = value; }

        public int Count => count;

        public bool IsReadOnly => false;


        public UniqueSortedListInt()
            : this(10)
        {

        }
        public UniqueSortedListInt(int capacity)
        {
            list = new int[capacity];
            count = 0;
        }
        public UniqueSortedListInt(IEnumerable<int> enumerable)
            : this(10)
        {
            foreach (var e in enumerable)
                Add(e);
        }

        public bool SetEquals(UniqueSortedListInt other)
        {
            if (other.count != count)
                return false;

            for (int i = 0; i < count; i++)
                if (list[i] != other.list[i])
                    return false;

            return true;
        }

        public void Override(UniqueSortedListInt other)
        {
            if (count < other.count)
                list = new int[other.count];

            count = other.count;

            var otherlist = other.list;
            
            for (int i = 0; i < count; i++)
                list[i] = otherlist[i];
        }

        public bool Add(int item)
        {
            if (Contains(item)) return false;

            if (count + 1 >= list.Length)
                Array.Resize(ref list, count * 2 + 1);

            for (int i = 0; i < count; i++)
                if (list[i] > item)
                {
                    InsertPrivate(i, item);
                    count++;
                    return true;
                }

            list[count] = item;
            count++;

            return true;
        }

        

        void ICollection<int>.Add(int item)
        {
            Add(item);
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < count; i++)
                if (list[i] == item)
                    return true;
            return false;
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return list[i];
        }

        public int IndexOf(int item)
        {
            return Array.IndexOf(list, item, 0, count);
        }

        void IList<int>.Insert(int index, int item)
        {
            throw new InvalidOperationException();
        }

        void InsertPrivate(int index, int item)
        {
            for (int i = count ; i > index; i--)
                list[i] = list[i - 1];
            list[index] = item;
        }

        public bool Remove(int item)
        {
            var index = Array.IndexOf(list, item,0,count);
            if (index < 0) return false;

            for (int i = index + 1; i < count; i++)
                list[i - 1] = list[i];

            return true;
        }

        public void RemoveAt(int index)
        {
            for (int i = index + 1; i < count; i++)
                list[i - 1] = list[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
