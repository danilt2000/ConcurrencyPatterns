namespace ConcurrencyPatterns
{
        internal class AsynchronousProgramming
        {
                public AsynchronousProgramming() { }

                public async Task InvokePattern()
                {
                        var url = "https://example.com";

                        using HttpClient client = new HttpClient();
                        
                        try
                        {
                                string result = await client.GetStringAsync(url);

                                Console.WriteLine($"Downloaded content length:{result.Length} characters.");
                        }
                        catch (Exception e)
                        {
                                Console.WriteLine(e);
                        }
                }
        }
}
