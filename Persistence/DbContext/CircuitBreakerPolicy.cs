using Polly;
using Domain.Exceptions;

namespace Persistence.Data
{
    public static class CircuitBreakerPolicy
    {
        public static IAsyncPolicy RetryPolicy = Policy
             .Handle<RetryException>()
             .RetryAsync(3, onRetry: (exception, retryCount) =>
             {
             });

        public static IAsyncPolicy TimeoutPolicy = Policy
            .TimeoutAsync(TimeSpan.FromSeconds(30), Polly.Timeout.TimeoutStrategy.Pessimistic);

        public static IAsyncPolicy ResiliencePolicy => Policy.WrapAsync(TimeoutPolicy, RetryPolicy);
    }
}
