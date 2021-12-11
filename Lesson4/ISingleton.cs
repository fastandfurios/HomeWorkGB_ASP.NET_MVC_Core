namespace Lesson4
{
    public interface ISingleton<T> where T : class, new()
    {
        static object _lockObject = new();
        static volatile T? _instance;
        static T? Instance
        {
            get
            {
                if(_instance is null)
                {
                    lock (_lockObject)
                    {
                        if(_instance is null) _instance = new T();
                    }
                }
                return _instance;
            }
        }
    }
}
