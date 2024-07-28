using System.Collections.Concurrent;

namespace ConcurrencyPatterns
{
        internal class ProducerConsumerPattern
        {
                public ProducerConsumerPattern() { }

                public async Task InvokePattern()
                {
                        var buffer = new BlockingCollection<int>(boundedCapacity: 10);

                        var producerTask = Task.Run(() =>

                                {
                                        for (int i = 0; i < 20; i++)
                                        {
                                                buffer.Add(i);
                                                Console.WriteLine($"Produced:{i}");

                                                Thread.Sleep(100);
                                        }

                                        buffer.CompleteAdding();
                                }
                        );

                        var consumerTask = Task.Run(() =>
                        {
                                foreach (var item in buffer.GetConsumingEnumerable())
                                {
                                        Console.WriteLine($"Consumed:{item}");
                                        Thread.Sleep(200);
                                }


                        });
                 
                        await Task.WhenAll(producerTask, consumerTask);
                }
        }
}
