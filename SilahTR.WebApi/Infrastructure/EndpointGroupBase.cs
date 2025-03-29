namespace SilahTR.WebApi.Infrastructure
{
    public abstract class EndpointGroupBase
    {
        protected static readonly string RateLimitPolicyName = "SecurityPolicy.RateLimiting.FixedWindow";

        public abstract void Map(WebApplication app);
    }
}
