Quorix.Pipeline

Quorix.Pipeline is a modular and extensible middleware layer designed to work seamlessly with Quorix.
It provides out-of-the-box pipeline behaviors such as logging, retry, circuit breaker, rate limiting, validation, caching, and more — all designed for commercial-grade .NET systems.
🎯 Why Quorix.Pipeline?

While many CQRS/Mediator libraries offer basic pipelines, most fall short when applied to enterprise-level architectures.
Quorix.Pipeline gives you:

    🔌 Plug-and-play behaviors
    ⚙️ Full extensibility using IPipelineBehavior<TRequest, TResponse>
    🚀 Zero external dependencies beyond Polly, FluentValidation, and Microsoft abstractions
    🔐 Safe for use in commercial and sensitive production environments
    🧱 Built from the ground up to be lightweight, testable, and scalable

✨ Included Behaviors

    LoggingBehavior – Logs each request's execution
    RetryBehavior – Automatically retries transient failures
    CircuitBreakerBehavior – Prevents cascading failures
    IdempotencyBehavior – Prevents double execution of requests
    CachingBehavior – Supports custom or in-memory caching
    RateLimitingBehavior – Protects downstream resources
    ValidationBehavior – Uses FluentValidation validators
    PerformanceBehavior – Tracks execution duration
    MetricsBehavior – Exposes observable metrics for monitoring

📦 Installation

Install the package via NuGet:

dotnet add package Quorix.Pipeline

🛠️ Getting Started Register the pipeline:

services.AddQuorixPipeline() .AddLoggingBehavior() .AddRetryBehavior() .AddValidationBehavior() .AddQuorixMemoryCaching(); // Optional: Built-in memory caching

Add FluentValidation validators:

dotnet add package FluentValidation.DependencyInjectionExtensions

services.AddValidatorsFromAssemblyContaining();

Provide a custom caching strategy:

services.AddQuorixCaching();

🔧 Custom Middleware Example

Create your own behavior by implementing:

public class CustomBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest { public async Task Handle( TRequest request, RequestHandlerDelegate next, CancellationToken cancellationToken) { // Pre-processing logic var response = await next(); // Post-processing logic return response; } }

Then register:

services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CustomBehavior<,>));

🧪 Built with Testability in Mind

All behaviors are added via DI and can be replaced or mocked for unit/integration tests. 📄 License

Quorix.Pipeline is licensed under the MIT License – free for both personal and commercial use. 🔗 Related Packages

Quorix.Mediator – Core CQRS mediator infrastructure

⭐ Give Back

If you find this package helpful, a star on GitHub or NuGet would be appreciated.

Feedback and contributions are always welcome!

📬 Contact

For commercial support, licensing inquiries, or contribution discussions, please get in touch at tunahan.ali.ozturk@outlook.com




🔌 Quorix.Pipeline

Quorix.Pipeline is a modular middleware layer that works seamlessly with Quorix, offering out-of-the-box behaviors for real-world production needs.
🎯 Why Quorix.Pipeline?

Most mediator frameworks fall short in real commercial use cases. Quorix.Pipeline offers:

    🔌 Plug-and-play behaviors

    ⚙️ Full extensibility with IPipelineBehavior<TRequest, TResponse>

    🚀 Zero external dependencies beyond Polly, FluentValidation, and Microsoft.Abstractions

    🔐 Safe for sensitive production systems

    🧪 Built for testability and scaling

✨ Included Behaviors

    LoggingBehavior – Request logging

    RetryBehavior – Transient fault handling

    CircuitBreakerBehavior – Fault tolerance

    IdempotencyBehavior – Prevents duplicate command execution

    CachingBehavior – Optional memory/custom caching

    RateLimitingBehavior – Controls request flow

    ValidationBehavior – Integrates FluentValidation

    PerformanceBehavior – Measures execution time

    MetricsBehavior – Exposes metrics for observability

📦 Install via NuGet

dotnet add package Quorix.Pipeline

🛠️ Getting Started

services.AddQuorixPipeline()
        .AddLoggingBehavior()
        .AddRetryBehavior()
        .AddValidationBehavior()
        .AddQuorixMemoryCaching(); // Optional built-in memory caching

Add FluentValidation:

dotnet add package FluentValidation.DependencyInjectionExtensions

Then:

services.AddValidatorsFromAssemblyContaining<YourValidator>();

To provide custom caching:

services.AddQuorixCaching();

🔧 Custom Middleware Example

public class CustomBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // Pre-processing
        var response = await next();
        // Post-processing
        return response;
    }
}

Register via DI:

services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CustomBehavior<,>));

🧪 Testability

All behaviors are DI-based and can be easily mocked or swapped for testing.
📄 License

Quorix and Quorix.Pipeline are open source and licensed under the MIT License — free to use in personal and commercial projects.
⭐ Support the Project

If you find this package helpful, please consider starring the repo or supporting development:

👉 [Buy Me a Coffee](https://buymeacoffee.com/tunahanali)
📬 Contact

Commercial support, licensing inquiries, or contribution discussions welcome:

📧 tunahan.ali.ozturk@outlook.com
