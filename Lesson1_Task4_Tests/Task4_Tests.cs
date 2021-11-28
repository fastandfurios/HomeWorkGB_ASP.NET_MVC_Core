using Lesson1_Task4;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Lesson1_Task4_Tests
{
    public class Task4_Tests
    {
        [Fact]
        public void AddWithLock_comparision_of_two_lists_succeeded()
        {
            var list = new List<int> { 0, 1, 2, 0, 1, 2, 0, 1, 2 };
            var adapterList = new AdapterList<int>();

            var threads = new Thread[3];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 3; j++)
                    {
                        adapterList.AddWithLock(j);
                    }
                });

                threads[i].Start();
            }

            Thread.Sleep(1500);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.Equal(list[i], adapterList[i]);
            }
        }
    }
}