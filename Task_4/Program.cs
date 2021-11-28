using Task_4;

var customList = new AdapterList<int>();

var threads = new Thread[10];

for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(() => 
    {
        for (int j = 0; j < 100; j++)
        {
            lock (customList)
            {
                customList.Add(j);
                Console.WriteLine($"{j} добавлен");
                Thread.Sleep(10);
            }
        }
    });

    threads[i].Start();
}