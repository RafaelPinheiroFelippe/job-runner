# JobRunner

JobRunner is an AI-Driven Job Matching Platform backend project. It's aimed at automating the job matching process using artificial intelligence and is built with .NET 7. The solution applies Domain-Driven Design (DDD) and Test-Driven Development (TDD) practices.

The system is currently composed of the following bounded context:

## User Management Context
This context is responsible for managing users, which includes operations like registration, login, user profile management, etc. The User Management Context is developed as a .NET class library and uses Entity Framework Core for data access.

## Service API
The `ServiceAPI` project serves as the main entry point for the application. This ASP.NET Core Web API project references the class library projects and initiates the application's services, middleware, and configurations.

## Tech Stack
The project uses a combination of modern technologies and best practices:

- .NET 7
- Entity Framework Core
- FluentValidation
- FluentReturn
- xUnit
- Moq
- Domain-Driven Design (DDD)
- Test-Driven Development (TDD)

## Validation
Validation is a crucial part of the system and has been implemented in a layered approach:

- **Value Objects**: Ensures the internal consistency and validity of individual properties at the domain level.
- **FluentValidation**: Applied at the application level for higher-level business rules and object-level validation.

## Unit Testing
Unit tests are written using the xUnit framework, with Moq employed for mocking dependencies.

## Error Handling
Errors are handled using a Result Pattern implemented with the FluentReturn package, providing a robust way to handle and propagate errors without throwing exceptions.

## Future Development
The current architecture is monolithic, with each bounded context as a separate .NET class library within the same solution. The roadmap includes plans to evolve this architecture into a microservices-based design, with each bounded context eventually becoming an independent microservice with its own database.

## License
JobRunner is open-source software, licensed under the terms of the MIT license.
