namespace SynchronizationMechanismsLocksMutexesSemaphores
{
        internal class SemaphoresExample
        {
                private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(2);

                private static int _resource = 0;

                public void Invoke()
                {
                        Thread t1 = new Thread(UseResource);
                        Thread t2 = new Thread(UseResource);
                        Thread t3 = new Thread(UseResource);

                        t1.Start();
                        t2.Start();
                        t3.Start();

                        t1.Join();
                        t2.Join();
                        t3.Join();

                        Console.WriteLine($"Final resource value:{_resource}");
                }

                static void UseResource()
                {
                        Semaphore.Wait();

                        try
                        {

                                Console.WriteLine(
                                        $"Thread {Thread.CurrentThread.ManagedThreadId} is using the resource.");

                                Thread.Sleep(2000);

                                _resource++;
                        }
                        catch (Exception)
                        {
                                // ignored
                        }
                        finally
                        {
                                Semaphore.Release();
                        }
                }
        }
}
