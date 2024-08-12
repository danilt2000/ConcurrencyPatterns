namespace HandlingRaceConditionsAndDeadlocks
{
    internal class InterlockedExample
    {
        private static int _counter = 0;

        public void Invoke()
        {
            Thread t1 = new Thread(IncrementCounter);

            Thread t2 = new Thread(IncrementCounter);

            t1.Start();

            t2.Start();

            t1.Join();

            t2.Join();

            Console.WriteLine($"Final counter value:{_counter}");
        }

        static void IncrementCounter()
        {
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine($"Current index {i}");

                Interlocked.Increment(ref _counter);
            }
        }
    }
}
