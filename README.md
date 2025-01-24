## MultiShop Microservice Project With .NET Core 8.0

## Overview
This project is developed with ASP.NET Core 8.0, adopting a modern, microservices-driven architecture to deliver flexibility and scalability. Docker support is seamlessly integrated, providing a secure and portable deployment environment. The system is optimized to work effortlessly with various SQL and NoSQL databases, including MSSQL, MongoDB, Redis, and PostgreSQL.

## Project Features

- **Microservices Architecture:** Implements Layered and Onion architectures, ensuring a flexible, scalable, and SOLID-compliant design.
- **Design Patterns:** Incorporates Repository, CQRS, and Mediator patterns to enhance modularity and maintainability.
- **Security:** Utilizes Identity Server and JWT for robust user authentication and authorization.
- **Database Support:** Efficiently manages data with support for MSSQL, MongoDB, Redis, and PostgreSQL.
- **API Gateway:** Uses Ocelot Gateway for seamless API routing, complemented by Swagger-generated documentation.
- **Real-Time Communication:** Enables live updates and notifications with SignalR, eliminating the need for page reloads.
- **Testing and Validation:** API functionality is rigorously tested and verified using Postman.

## Technologies Used

- **Backend:** ASP.NET Core 8.0 Web API
- **Databases:** MSSQL, MongoDB, Redis, PostgreSQL
- **Containerization:** Docker for streamlined deployment and management
- **Database Tools:** DBeaver, Dapper for efficient data access and management
- **API Testing:** Postman and Swagger for endpoint validation and documentation
- **Messaging Queue:** RabbitMQ for reliable message handling
- **Cloud Storage:** Google Cloud Storage for scalable data storage solutions
- **Architectural Patterns:** Onion Architecture, CQRS, Mediator, and Repository Design Pattern for maintainable and modular design
- **Security:** Identity Server and JWT for authentication and authorization
- **API Gateway:** Ocelot Gateway for efficient API routing and aggregation
- **Real-Time Features:** SignalR for live notifications and updates
- **Frontend Technologies:** HTML, CSS, JavaScript, and Bootstrap

## System Requirements
To set up and run this project locally or in a production environment, make sure you have the following prerequisites installed:

- .NET Core SDK 8.0 or later
- Docker (latest version recommended for containerization and deployment)
- Redis Server (for caching when running locally)
- RabbitMQ Server (for message queueing in local environments)
- PostgreSQL or MSSQL Server (or any compatible SQL database configured for the project)
- MongoDB (for NoSQL database operations)

## NuGet Packages
The packages used in this project are
These packages should be installed via the NuGet Package Manager or by using the ```dotnet add```  package command.

- Microsoft.EntityFrameworkCore – ORM for managing SQL databases
- Microsoft.EntityFrameworkCore.SqlServer – SQL Server provider for Entity Framework Core
- Dapper – Lightweight ORM for efficient data access
- MediatR – Implementation of the Mediator pattern for CQRS
- IdentityServer4 – Authentication and authorization framework
- System.IdentityModel.Tokens.Jwt – JWT token management for secure API interactions
- SwaggerGen – API documentation generator
- Ocelot – API Gateway for routing and aggregation
- SignalR – Real-time communication for live notifications

## Installation

To clone the project:
```bash 
git clone https://github.com/srburak/MultiShop.git
```

## Screenshots of the project
- Home Page
![homepage](https://github.com/user-attachments/assets/29b6712a-24bf-40ec-b18b-e4305893c773)

- Product Detali Page
![productDetaliPage](https://github.com/user-attachments/assets/f33fa173-d7e9-47f7-867f-20eba0d9be7c)

- Shoping Cart Page
![shopingCartPage](https://github.com/user-attachments/assets/d0edc746-cc1a-4fdf-849c-6fdfb093ea08)

- Profile Page
![profilPage](https://github.com/user-attachments/assets/c07efdba-7913-4313-b9fe-87cda48e0d21)

- Login Page
![loginpage](https://github.com/user-attachments/assets/a0742d3d-de45-4ed7-bdfa-826759dd711b)

-Register Page
![registerpage](https://github.com/user-attachments/assets/7b478b0b-6d5c-4538-8cc9-1a2bfe7d81f1)

- Admin / Brands Page
![adminBrands](https://github.com/user-attachments/assets/529150c5-e263-4f71-a0f8-1df3b128d6f4)

- Admin / Category Page
![admincategory](https://github.com/user-attachments/assets/9fb9354e-f4ca-4473-b85a-79cbd2571fae)

- Admin / Product Page
![adminProduct](https://github.com/user-attachments/assets/f1ec8b6e-0ce6-4579-9909-45540d7a63de)

- Admin / Statistics Page
![adminStatistic](https://github.com/user-attachments/assets/4ccb44de-e37e-4213-baf1-55a3de92bd0e)

- Docker
![docker](https://github.com/user-attachments/assets/b9392d5d-2631-4e02-abca-2cd788aedf0c)



