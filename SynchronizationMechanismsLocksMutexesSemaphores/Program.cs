
namespace SynchronizationMechanismsLocksMutexesSemaphores;

internal class Program
{
        public static void Main(string[] args)
        {
                //LocksExample locksExample = new LocksExample();

                //locksExample.Invoke();

                //MutexesExample mutexesExample = new MutexesExample();

                //mutexesExample.Invoke();

                SemaphoresExample semaphoreExample = new SemaphoresExample();

                semaphoreExample.Invoke();
        }
}