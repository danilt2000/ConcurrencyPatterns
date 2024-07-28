namespace SynchronizationMechanismsLocksMutexesSemaphores
{
        internal class MutexesExample
        {
                private static readonly Mutex Mutex = new Mutex();

                private static int _sharedValue = 0;

                public void Invoke()
                {
                        Thread t1 = new Thread(IncrementSharedValue);

                        Thread t2 = new Thread(DecrementSharedValue);

                        t1.Start();

                        t2.Start();

                        t1.Join();

                        t2.Join();

                        Console.WriteLine($"Final shared value:{_sharedValue}");
                }

                static void IncrementSharedValue()
                {
                        for (int i = 0; i < 10000; i++)
                        {
                                Mutex.WaitOne();

                                _sharedValue++;

                                Mutex.ReleaseMutex();
                        }
                }

                static void DecrementSharedValue()
                {
                        for (int i = 0; i < 10000; i++)
                        {
                                Mutex.WaitOne();

                                _sharedValue--;

                                Mutex.ReleaseMutex();
                        }
                }
        }
}
