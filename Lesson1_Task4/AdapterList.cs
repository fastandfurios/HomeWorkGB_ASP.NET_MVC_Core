using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_Task4
{
    public class AdapterList<T> : List<T>
    {
        private readonly object _lock = new();

        public void AddWithLock(T obj)
        {
            lock (_lock)
            {
                Add(obj);
            }
        }

        public void AddRangeWithLock(IEnumerable<T> collection)
        {
            lock (_lock)
            {
                AddRange(collection);
            }
        }

        public bool RemoveWithLock(T item)
        {
            lock(_lock)
            {
               return Remove(item);
            }
        }

        public int RemoveAllWithLock(Predicate<T> match)
        {
            lock(_lock)
            {
                return RemoveAll(match);
            }
        }

        public void RemoveAtWithLock(int index)
        {
            lock (_lock)
            {
                RemoveAt(index);
            }
        }

        public void RemoveRangeWithLock(int index, int count)
        {
            lock (_lock)
            {
                RemoveRange(index, count);
            }
        }
    }
}
