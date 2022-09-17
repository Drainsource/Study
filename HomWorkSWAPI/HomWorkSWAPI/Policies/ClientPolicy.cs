using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using System.Reflection.Metadata.Ecma335;

namespace HomWorkSWAPI.Policies
{
    public class ClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> InmidateHttpRetry { get; }

        public AsyncCircuitBreakerPolicy<HttpResponseMessage> InmidateHttpCircutBreaker { get; set; }

        
        public ClientPolicy()
        {
            InmidateHttpRetry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode).RetryAsync(5);
            InmidateHttpCircutBreaker = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode).CircuitBreakerAsync(4, TimeSpan.FromSeconds(2) );
        }
    }
}
