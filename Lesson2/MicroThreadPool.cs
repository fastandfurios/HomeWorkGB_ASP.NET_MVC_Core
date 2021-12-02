using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public static class MicroThreadPool
    {
        private static readonly Queue<Task> _tasks = new();

        public static Task GetTask(Action action)
        {
            if(_tasks.Count > 0) return _tasks.Dequeue();
            return new(action);
        }

        public static void ReleaseTask(Task task)
        {
            if (task is null) return;

            _tasks.Enqueue(task);
        }
    }
}
