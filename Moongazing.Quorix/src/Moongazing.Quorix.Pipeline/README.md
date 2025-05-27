# Quorix.Pipeline

**Quorix.Pipeline** is a modular and extensible middleware layer designed to work seamlessly with [Quorix](https://www.nuget.org/packages/Quorix).  
It provides out-of-the-box pipeline behaviors such as logging, retry, circuit breaker, rate limiting, validation, caching, and more — all designed for **commercial-grade .NET systems**.

---

## 🎯 Why Quorix.Pipeline?

While many CQRS/Mediator libraries offer basic pipelines, most fall short when applied to **enterprise-level architectures**.  
**Quorix.Pipeline** gives you:

- 🔌 **Plug-and-play behaviors**
- ⚙️ Full extensibility using `IPipelineBehavior<TRequest, TResponse>`
- 🚀 Zero external dependencies beyond `Polly`, `FluentValidation`, and Microsoft abstractions
- 🔐 Safe for use in **commercial** and **sensitive production environments**
- 🧱 Built from the ground up to be lightweight, testable, and scalable

---

## ✨ Included Behaviors

- **LoggingBehavior** – Logs each request's execution
- **RetryBehavior** – Automatically retries transient failures
- **CircuitBreakerBehavior** – Prevents cascading failures
- **IdempotencyBehavior** – Prevents double execution of requests
- **CachingBehavior** – Supports custom or in-memory caching
- **RateLimitingBehavior** – Protects downstream resources
- **ValidationBehavior** – Uses FluentValidation validators
- **PerformanceBehavior** – Tracks execution duration
- **MetricsBehavior** – Exposes observable metrics for monitoring

---

## 📦 Installation

Install the package via NuGet:

dotnet add package Quorix.Pipeline

🛠️ Getting Started
Register the pipeline:

services.AddQuorixPipeline()
    .AddLoggingBehavior()
    .AddRetryBehavior()
    .AddValidationBehavior()
    .AddQuorixMemoryCaching(); // Optional: Built-in memory caching

Add FluentValidation validators:

dotnet add package FluentValidation.DependencyInjectionExtensions

services.AddValidatorsFromAssemblyContaining<Startup>();

Provide a custom caching strategy:

services.AddQuorixCaching<YourCustomRedisCacheProvider>();

🔧 Custom Middleware Example

Create your own behavior by implementing:

public class CustomBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // Pre-processing logic
        var response = await next();
        // Post-processing logic
        return response;
    }
}

Then register:

services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CustomBehavior<,>));

🧪 Built with Testability in Mind

All behaviors are added via DI and can be replaced or mocked for unit/integration tests.
📄 License

Quorix.Pipeline is licensed under the MIT License – free for both personal and commercial use.
🔗 Related Packages

    Quorix.Mediator – Core CQRS mediator infrastructure

⭐ Give Back

If you find this package helpful, a star on GitHub or NuGet would be appreciated.

    Feedback and contributions are always welcome!

📬 Contact

For commercial support, licensing inquiries, or contribution discussions, please get in touch at tunahan.ali.ozturk@outlook.com
