# Notification.Gateway

## Design Patterns Used:

- **Factory Method Pattern**: Different types of messages (OTP, email, alert...) created using _IMessageFactory_ interface. Also used for creating different input types from CLI.
- **Strategy Pattern**: There are two different providers to send notifications using _Strategy Pattern_.
- **Chain of Responsibilty Pattern**: For handling notification providers failover, passing the request to next available providers if one might fail delivering the message.
- **Observer Pattern**: Used to log the following events in console when occurred (used with .NET Core _events_):
  - MessageCreated
  - ProviderSelected
  - MessageSent
  - MessageFailed
  - ProviderChanged

- **Command Pattern**: Used in presentation layer (worker serivce) to handle parsing and creating corresponding command types stand-alone objects ready to execute to the core notification service.

## All SOLID principles considered and applied throughout the application structure.
