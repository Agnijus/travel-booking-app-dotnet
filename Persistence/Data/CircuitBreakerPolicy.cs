using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public static class CircuitBreakerPolicy
    {
        public static IAsyncPolicy RetryPolicy = Policy
            .Handle<Exception>() 
            .RetryAsync(3, onRetry: (exception, retryCount) =>
            {
                Console.WriteLine($"Retry {retryCount} for exception: {exception.Message}");
            });

        public static IAsyncPolicy TimeoutPolicy = Policy
            .TimeoutAsync(TimeSpan.FromSeconds(30), Polly.Timeout.TimeoutStrategy.Pessimistic);

        public static IAsyncPolicy ResiliencePolicy => Policy.WrapAsync(TimeoutPolicy, RetryPolicy);
    }
}
