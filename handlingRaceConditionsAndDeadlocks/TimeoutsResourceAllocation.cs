namespace HandlingRaceConditionsAndDeadlocks
{
    internal class TimeoutsResourceAllocation
    {
        private static readonly object Lock1 = new object();

        private static readonly object Lock2 = new object();

        public void Invoke()
        {
            Thread t1 = new Thread(DeadlockMethod1);

            Thread t2 = new Thread(DeadlockMethod2);

            t1.Start();

            t2.Start();

            t1.Join();

            t2.Join();

            Console.WriteLine($"Execution completed");
        }

        static void DeadlockMethod1()
        {
            if (Monitor.TryEnter(Lock1, TimeSpan.FromSeconds(1)))
            {
                try
                {
                    Console.WriteLine("Thread 1 acquired lock1.");

                    Thread.Sleep(2000);//Simulate some work 

                    if (Monitor.TryEnter(Lock2, TimeSpan.FromSeconds(1)))
                    {
                        try
                        {
                            Thread.Sleep(2000);//Simulate some work 

                            Console.WriteLine("Thread 1 acquired lock2.");
                        }
                        finally
                        {
                            Monitor.Exit(Lock2);
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(Lock1);
                }
            }
            else
            {
                Console.WriteLine("Thread 1 couldn't acquire lock1 within timeout.");
            }

            //lock (Lock1)
            //{
            //    Console.WriteLine("Thread 1 acquired lock1.");

            //    Thread.Sleep(1000);

            //    lock (Lock2)
            //    {
            //        Console.WriteLine("Thread 1 acquired lock2.");
            //    }
            //}
        }

        static void DeadlockMethod2()
        {
            lock (Lock2)
            {
                Console.WriteLine("Thread 2 acquired lock2.");

                Thread.Sleep(1000);

                lock (Lock1)
                {
                    Console.WriteLine("Thread 2 acquired lock1.");
                }
            }
        }
    }
}
