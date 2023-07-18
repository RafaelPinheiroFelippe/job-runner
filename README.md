# user-management
This is the User Management Context of the AI-Driven Job Matching Platform, a larger backend project aimed at automating the job matching process using artificial intelligence. It's built with .NET, specifically using Domain-Driven Design (DDD) and Test-Driven Development (TDD) practices.

The larger system is composed of several bounded contexts, and this project focuses on the User Management part. This context is responsible for managing users, which includes operations like registration, login, user profile management, etc.

## Tech Stack

The following technologies and practices are used for this context:

- .NET 7
- Entity Framework Core
- FluentValidation
- FluentReturn
- xUnit
- Moq
- Domain-Driven Design (DDD)
- Test-Driven Development (TDD)

## Validation

A layered approach to validation is used:

- Value Objects: Used at the domain level to ensure the internal consistency and validity of individual properties.
- FluentValidation: Used at the application level for higher-level business rules and object-level validation.

The application layer / handlers DTOs are validated by FluentValidation.

## Unit Testing

Unit tests are written using the xUnit framework, with the help of Moq for mocking dependencies.

## Error Handling

Errors are handled using a Result Pattern implemented with the FluentReturn package. This provides a robust way to handle and propagate errors without the use of exceptions.

## License

This project is licensed under the terms of the MIT license.

