using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public sealed class MicroThreadPool
    {
        private int _id;
        private readonly Queue<Task> _tasks = new();
        

        /// <summary> Возращает id потока из пула </summary>
        public int Id => _id;
        public StringBuilder Status { get; set; }

        /// <summary> Получает информацию о всех потоках из пула </summary>
        /// <returns>возвращает строки с информацией о потоках из пула</returns>
        public IEnumerable<string> GetAllTasksFromPool()
        {
            foreach (var task in _tasks)
                yield return $"{task.Id} {task.Status}";
        }

        public Task AddTaskToPool(Action action, int idTask)
        {
            if(_tasks.Count > 0) return _tasks.Dequeue();
            return new(action);
        }
        
        public void ReleaseTask(Task task)
        {
            if (task is null) return;

            _tasks.Enqueue(task);
        }
    }
}
