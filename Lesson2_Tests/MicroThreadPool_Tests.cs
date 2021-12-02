using Xunit;
using Lesson2;

namespace Lesson2_Tests
{
    public class MicroThreadPool_Tests
    {
        [Fact]
        public void Test1()
        {
            var pool = new MicroThreadPool();

            void CalculateSum()
            {
                int a = 10, b = 20, sum = a + b;
            }

            var thread1 = pool.GetTask(CalculateSum);
            var thread2 = pool.GetTask(CalculateSum);

            thread1.Start();
            pool.ReleaseTask(thread1);
            thread2.Start();
            pool.ReleaseTask(thread2);
        }
    }
}