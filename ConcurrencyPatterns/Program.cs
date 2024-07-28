namespace ConcurrencyPatterns;

internal class Program
{
        public static async Task Main(string[] args)
        {
                ProducerConsumerPattern producerConsumerPattern = new ProducerConsumerPattern();

                await producerConsumerPattern.InvokePattern();

        }
}