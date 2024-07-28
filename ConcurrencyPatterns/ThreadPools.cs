namespace ConcurrencyPatterns
{
        internal class ThreadPools
        {
                public ThreadPools() { }

                public async Task InvokePattern()
                {
                        ThreadPool.QueueUserWorkItem(DoWork!, 1);
                        
                        ThreadPool.QueueUserWorkItem(DoWork!, 2);

                        for (int i = 0; i < 5; i++)
                        {
                                Console.WriteLine($"Main thread working... {i}");

                                Thread.Sleep(500);
                        }

                        await Task.Delay(2000);

                        Console.WriteLine("All work completed.");
                }

                static void DoWork(object state)
                {

                        int taskId = (int)state;

                        Console.WriteLine($"Worker thread {taskId} started.");

                        Thread.Sleep(2000);

                        Console.WriteLine($"Worker thread {taskId} completed");
                }
        }
}
