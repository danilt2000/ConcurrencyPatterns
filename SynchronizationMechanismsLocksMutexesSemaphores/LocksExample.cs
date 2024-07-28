namespace SynchronizationMechanismsLocksMutexesSemaphores
{
        internal class LocksExample
        {
                private static readonly object LockObject = new object();

                private static int _counter = 0;

                public void Invoke()
                {
                        Thread t1 = new Thread(IncrementCounter);

                        Thread t2 = new Thread(IncrementCounter);

                        t1.Start();

                        t2.Start();

                        t1.Join();

                        t2.Join();
                }

                static void IncrementCounter()
                {
                        for (int i = 0; i < 100000; i++)
                        {
                                Console.WriteLine($"Current index {i}");

                                //Class with atomic operations Interlocked also can be used
                                //Interlocked.Increment(ref _counter);

                                lock (LockObject)
                                {
                                        _counter++;
                                }
                        }
                }
        }
}
