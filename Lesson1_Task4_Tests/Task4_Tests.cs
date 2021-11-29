using Lesson1_Task4;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Lesson1_Task4_Tests
{
    public class Task4_Tests
    {
        [Fact]
        public void AddWithLock_add_element_succeeded()
        {
            var adapterList = new AdapterList<int> { 0, 8, 3 };

            var threads = new Thread[5];
            var addElement = 12;

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    adapterList.AddWithLock(addElement);
                    Thread.Sleep(100);
                });

                threads[i].Start();
            }

            Thread.Sleep(2000);

            Assert.Contains(expected: addElement, collection: adapterList);
        }

        [Fact]
        public void AddRangeWithLock_add_range_succeeded()
        {
            var addArray = new int[] { 0, 1, 2 };

            var expectedList = new List<int> { 3, 2, 1, 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2 };
            var adapterList = new AdapterList<int>() { 3, 2, 1 };

            var threads = new Thread[5];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    adapterList.AddRangeWithLock(addArray);
                    Thread.Sleep(100);
                });

                threads[i].Start();
            }

            Thread.Sleep(2000);
            
            Assert.Equal(expected: expectedList, actual: adapterList);
        }

        [Fact]
        public void RemoveWithLock_remove_element_succeeded()
        {
            var adapterList = new AdapterList<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            var threads = new Thread[3];
            var removableNumber = 5;

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    adapterList.RemoveWithLock(removableNumber);
                    Thread.Sleep(100);
                });

                threads[i].Start();
            }

            Thread.Sleep(2000);

            Assert.DoesNotContain(expected: removableNumber, collection: adapterList);
        }

        [Fact]
        public void RemoveAllWithLock_deleting_elements_with_condition_succeeded()
        {
            var adapterList = new AdapterList<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var expectedList = new List<int> { 1, 3, 5, 7 };

            var threads = new Thread[3];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    adapterList.RemoveAllWithLock(number => number % 2 == 0);
                    Thread.Sleep(100);
                });

                threads[i].Start();
            }

            Thread.Sleep(2000);

            Assert.Equal(expected: expectedList, actual: adapterList);
        }

        [Fact]
        public void RemoveAtWithLock_deleting_an_item_by_index_succeeded()
        {
            var adapterList = new AdapterList<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var expectedList = new List<int> { 0, 1, 2, 6, 7, 8 };
            var index = 3;

            var threads = new Thread[3];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    adapterList.RemoveAtWithLock(index);
                    Thread.Sleep(100);
                });

                threads[i].Start();
            }

            Thread.Sleep(2000);

            Assert.Equal(expected: expectedList, actual: adapterList);
        }

        [Fact]
        public void RemoveRange_deleting_sequence_succeeded()
        {
            var adapterList = new AdapterList<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var expectedList = new List<int> { 6, 7, 8 };
            var index = 0;
            var count = 2;

            var threads = new Thread[3];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    adapterList.RemoveRangeWithLock(index, count);
                    Thread.Sleep(100);
                });

                threads[i].Start();
            }

            Thread.Sleep(2000);

            Assert.Equal(expected: expectedList, actual: adapterList);
        }
    }
}