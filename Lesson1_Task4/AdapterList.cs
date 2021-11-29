using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_Task4
{
    public class AdapterList<T> : List<T>
    {
        private readonly object _lock = new();

        public AdapterList(int capacity = 0) : base(capacity)
        {
        }

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
                try
                {
                    return Remove(item);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public int RemoveAllWithLock(Predicate<T> match)
        {
            lock(_lock)
            {
                try
                {
                    return RemoveAll(match);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Debug.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public void RemoveAtWithLock(int index)
        {
            lock (_lock)
            {
                try
                {
                    RemoveAt(index);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public void RemoveRangeWithLock(int index, int count)
        {
            lock (_lock)
            {
                try
                {
                    RemoveRange(index, count);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
