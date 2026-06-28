# Notification.Gateway

## Project Overview

**Notification.Gateway** is a simplified notification gateway implemented as a .NET Worker Service to demonstrate the practical application of **Object-Oriented Design**, **SOLID principles**, and several **Gang of Four (GoF) Design Patterns**.

The application simulates sending SMS notifications through multiple providers. A notification is created from user input, sent using a configurable provider, and automatically fails over to alternative providers if delivery fails. Throughout the process, important application events are published and logged.

The current implementation supports **OTP (One-Time Password)** messages, but the architecture is intentionally designed to be easily extensible for additional notification types (such as Email, Alert, Promotional SMS, etc.) and additional notification providers without modifying the existing business logic.

---

# Project Architecture

The solution is divided into two projects:

* **Notification.Gateway.Core**

  * Contains all business logic.
  * Implements notification models, providers, factories, services, handlers, events, and abstractions.

* **Notification.Gateway.Presentation**

  * Console Worker Service.
  * Parses CLI commands.
  * Creates executable commands.
  * Invokes the Core layer.

This separation follows the **Single Responsibility Principle** by isolating business logic from presentation concerns.

---

# Supported CLI Commands

Display available commands:

```text
help
```

Send an OTP notification:

```text
send -otp -recipient 09121234567 -code 123456
```

---

# Design Patterns Used

## 1. Factory Method Pattern

Factory Method is used to encapsulate object creation and remove direct dependencies on concrete implementations.

### Message Factory

Instead of creating notification objects directly:

```csharp
new OTPMessage(...)
```

clients use:

```csharp
IMessageFactory.CreateMessage(...)
```

This allows new notification types (Email, Alert, Marketing, etc.) to be introduced without changing client code.

### Command Factory

The Presentation layer also uses a command factory to create executable CLI commands after parsing user input.

Benefits:

* Encapsulates object creation.
* Reduces coupling.
* Supports future message and command types.
* Follows the Open/Closed Principle.

---

## 2. Strategy Pattern

Notification delivery providers implement a common interface:

```csharp
ISmsProvider
```

Examples:

* ProviderA
* ProviderB

Each provider contains its own delivery strategy while exposing the same behavior to the application.

The notification service depends only on the abstraction rather than any concrete provider.

Benefits:

* Providers become interchangeable.
* New providers can be added without modifying existing code.
* Promotes dependency inversion.

---

## 3. Chain of Responsibility Pattern

Multiple providers are connected together into a processing pipeline.

Example:

```text
Provider A
      │
      ▼
Provider B
```

If the first provider successfully delivers the notification, the chain stops.

If delivery fails, responsibility is automatically delegated to the next provider.

This design eliminates nested conditional statements such as:

```text
if ProviderA fails
    try ProviderB
else
    ...
```

Benefits:

* Automatic failover.
* Loose coupling between providers.
* Easy addition of new providers to the pipeline.

---

## 4. Observer Pattern

The application publishes domain events whenever important actions occur.

Current events include:

* MessageCreated
* ProviderSelected
* ProviderChanged
* MessageSent
* MessageFailed

The logging component subscribes to these events using .NET events and logs them through the built-in `ILogger` abstraction.

The publisher has no knowledge of who is listening, making the system loosely coupled.

Benefits:

* Decouples business logic from logging.
* Supports additional observers (metrics, auditing, monitoring, notifications) without changing the publisher.
* Promotes extensibility.

---

## 5. Command Pattern

Each CLI command is represented as an independent executable object implementing:

```csharp
ICommand
```

Examples:

* HelpCommand
* SendOtpCommand
* UnknownCommand

The worker simply requests a command from the command factory and executes it.

Benefits:

* Removes large switch statements.
* Encapsulates command behavior.
* Makes adding new CLI commands straightforward.
* Follows the Open/Closed Principle.

---

## 6. Parser Strategy

The command parsing mechanism also follows the Strategy Pattern.

Each parser is responsible for recognizing and constructing one specific command.

Examples:

* HelpCommandParser
* SendOtpCommandParser
* UnknownCommandParser

The command factory iterates through registered parsers and delegates parsing to the first parser capable of handling the input.

Benefits:

* No centralized parsing logic.
* Easy extension with additional commands.
* Better separation of responsibilities.

---

# SOLID Principles Applied

## Single Responsibility Principle (SRP)

Every class has one well-defined responsibility.

Examples:

* `NotificationService` coordinates notification delivery.
* `ProviderPipeline` builds the provider chain.
* `ProviderHandler<T>` delegates sending to a provider.
* `NotificationLogger` handles logging only.
* `CommandFactory` creates commands.
* `SendOtpCommandParser` parses OTP commands only.
* `OTPMessageFactory` creates OTP messages only.

---

## Open/Closed Principle (OCP)

The system is designed to be extended without modifying existing components.

Examples:

* Adding a new notification provider only requires implementing `ISmsProvider`.
* Adding a new message type only requires creating a new message class and factory.
* Adding a new CLI command only requires implementing a new `ICommand` and `ICommandParser`.

Existing classes remain unchanged.

---

## Liskov Substitution Principle (LSP)

Concrete implementations can replace their abstractions without affecting application behavior.

Examples:

* Any `ISmsProvider` implementation can replace another.
* Any `ICommand` can be executed by the worker.
* Any `ICommandParser` can participate in the parser collection.
* Any message derived from `BaseMessage` can be processed by the notification service.

---

## Interface Segregation Principle (ISP)

Interfaces remain focused and minimal.

Examples:

* `ISmsProvider`
* `IMessageFactory`
* `IProviderHandler`
* `IProviderPipeline`
* `ICommand`
* `ICommandParser`

Clients depend only on the members they actually require.

---

## Dependency Inversion Principle (DIP)

High-level modules depend on abstractions instead of concrete implementations.

Examples:

* `NotificationService` depends on `IProviderPipeline`.
* `ProviderHandler<T>` depends on `ISmsProvider`.
* The worker depends on `ICommandFactory`.
* Command parsers depend on command factories.
* Logging depends on the `ILogger` abstraction.

Dependency Injection is used throughout the solution to resolve concrete implementations.

---

# Extensibility

The architecture is designed so that new functionality can be added with minimal changes.

Examples include:

* Adding Email notifications.
* Adding Push notifications.
* Adding additional SMS providers.
* Adding new CLI commands.
* Adding new event subscribers (metrics, auditing, monitoring).
* Supporting different notification routing strategies.

Most new features require only creating new implementations and registering them with the dependency injection container.

---

# Technologies Used

* .NET Worker Service
* C#
* Dependency Injection
* Microsoft.Extensions.Logging
* Generic Host
* Built-in .NET Events
* SOLID Principles
* GoF Design Patterns

---

# Summary

This project demonstrates how multiple design patterns can work together within a clean, extensible architecture. By combining Factory Method, Strategy, Chain of Responsibility, Observer, and Command patterns while adhering to the SOLID principles, the application remains modular, maintainable, and easy to extend with new notification types, providers, commands, and event subscribers.
