# Quorix

**Quorix** is a lightweight, high-performance, and extensible **Mediator & Message Dispatching Infrastructure** built for modern .NET applications. Designed with **clean architecture** and **CQRS principles** in mind, it enables your system to scale with clear separation of concerns, high testability, and plug-and-play pipeline behaviors — all without depending on any external mediator library like MediatR.

This package is built with **commercial-grade projects** in mind, offering a minimalistic core and extension points that fit enterprise-level service-oriented architectures and microservices.

---

## ✨ Key Features

- ✅ **Zero External Dependencies**: Built from the ground up — no reliance on MediatR or others.
- 🧠 **Interfaces for Command, Query, and Event Segregation**:
  - `ICommand`, `IQuery`, `IEvent`
- 🧩 **Handler Abstractions**:
  - `ICommandHandler<TRequest, TResponse>`
  - `IQueryHandler<TRequest, TResponse>`
  - `IEventHandler<TEvent>`
- 🚀 **Pipeline Extensibility**:
  - `IPipelineBehavior<TRequest, TResponse>` and `RequestHandlerDelegate<TResponse>` to implement middleware like logging, caching, retries, validation, etc.
- 🔄 **Command Bus**:
  - `ICommandBus` & `CommandBusMediator` for unified and testable message dispatching
- 🧪 **Testing-Friendly**:
  - Mockable interfaces, clear contracts
- 🧱 **Foundation for Commercial Systems**:
  - Suitable for DDD, Microservices, Modular Monoliths

---

## 💼 Why Quorix?

> Unlike general-purpose mediators, **Quorix.Mediator** is created with **real-world business complexity** in mind. Whether you're building a large ERP, SaaS platform, e-commerce backend, or distributed microservices — Quorix gives you:
- Full control over the message pipeline
- High customization capacity for behaviors (e.g., observability, metrics, resilience)
- Lightweight and focused core infrastructure
- Ready-to-extend architecture for vertical scalability


## 📦 Installation

You can install it via NuGet CLI:

dotnet add package Quorix.Mediator
