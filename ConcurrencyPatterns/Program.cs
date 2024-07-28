namespace ConcurrencyPatterns;

internal class Program
{
        public static async Task Main(string[] args)
        {
                //ProducerConsumerPattern producerConsumerPattern = new ProducerConsumerPattern();

                //await producerConsumerPattern.InvokePattern();

                //ThreadPools threadPools = new ThreadPools();

                //await threadPools.InvokePattern();

                AsynchronousProgramming asynchronousProgramming = new AsynchronousProgramming();

                await asynchronousProgramming.InvokePattern();
        }
}