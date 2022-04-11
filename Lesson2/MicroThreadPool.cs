using System.Collections.Concurrent;
using System.Diagnostics;

namespace Lesson2
{
    public sealed class MicroThreadPool
    {
        private int _counter;
        private const int _counterMax = 10;
        private readonly ConcurrentQueue<Task> _tasks = new();

        /// <summary> Добавляет созданную задачу в пул </summary>
        /// <param name="task">задача</param>
        /// <exception cref="ArgumentNullException">исключение возникает, если аргумент параметра равен null</exception>
        /// <exception cref="ArgumentOutOfRangeException">исключение возникает при превышении лимита потоков в пуле</exception>
        public void AddTaskToPool(Task task)
        {
            if (_counter < _counterMax)
            {
                if (task is null) throw new ArgumentNullException();
                else
                {
                    _tasks.Enqueue(task);
                    Debug.WriteLine($"Task successfully added! Id: {task.Id} Status: {task.Status}");
                }

                _counter++;
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        /// <summary> Получает информацию о всех потоках из пула </summary>
        /// <returns>возвращает строки с информацией о потоках из пула</returns>
        public IEnumerable<string> GetAllTasksFromPool()
        {
            foreach (var task in _tasks)
                yield return $"{task.Id} {task.Status}";
        }

        /// <summary> Удаляет задачу из пула </summary>
        /// <param name="idTask">id задачи</param>
        /// <returns>значение true, если элемент был успешно удален, в противном случае — значение false</returns>
        public bool RemoveTaskFromPool(int idTask)
        {
            var task = _tasks.SingleOrDefault(task => task.Id == idTask);
            return _tasks.TryDequeue(out task);
        }

        /// <summary> Запускает выбранный поток из пула потоков </summary>
        /// <param name="idTask">id потока</param>
        public void StartTaskFromPool(int idTask)
        {
            try
            {
                _tasks.SingleOrDefault(task => task.Id == idTask)!
                      .Start();
            }
            catch (ObjectDisposedException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (NullReferenceException)
            {
                throw;
            }
        }
    }
}
