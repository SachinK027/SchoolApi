# SchoolApi

A comprehensive RESTful Web API built with **.NET 8**, implementing a **Database-First** approach using Entity Framework Core. The API manages a school system with features including user authentication, role-based authorization, and student/course management.

---

## Table of Contents

- [Overview](#overview)  
- [Features](#features)  
- [Technologies](#technologies)  
- [Database Schema](#database-schema)  
- [Project Structure](#project-structure)  
- [Setup and Installation](#setup-and-installation)  
- [Running the Application](#running-the-application)  
- [Authentication & Authorization](#authentication--authorization)  
- [API Endpoints](#api-endpoints)  
- [Contributing](#contributing)  
- [License](#license)  

---

## Overview

This API provides core functionalities for a school management system:

- User registration with role assignment (Student, Teacher, Admin)  
- Secure login with JWT token generation and validation  
- Role-based authorization to restrict access to specific endpoints  
- Student entity management linked with user authentication  
- Course and Enrollment management (extendable)  
- Error handling via custom middleware  
- Password encryption for security  

The project uses a **Database-First** approach, scaffolding models and DbContext from an existing SQL Server database.

---

## Features

- **User Management**: Register, login, assign roles.  
- **JWT Authentication**: Secure token-based authentication.  
- **Role-Based Access Control**: Authorization enforced per role.  
- **Student Profiles**: Linked to Users through foreign key relationships.  
- **Entity Framework Core**: Database-first integration for data access.  
- **Modular Architecture**: Clear separation of concerns (Controllers, Services, Helpers).  
- **Custom Middleware**: For consistent error handling and logging.  

---

## Technologies

- **.NET 8** (ASP.NET Core Web API)  
- **Entity Framework Core** (Database-First)  
- **SQL Server**  
- **JWT (JSON Web Tokens)** for authentication  
- **C# 12**  
- **Dependency Injection & Middleware**  
- **Visual Studio / VS Code** for development  

---

## Database Schema

The database contains the following key tables and relations:

- **Users**: Stores user credentials and authentication data.  
- **Roles**: Contains role definitions (e.g., Admin, Student, Teacher).  
- **UserRoles**: Many-to-many linking table between Users and Roles.  
- **Students**: Domain-specific student data linked to the Users table (one-to-many).  
- **Courses**: Course information.  
- **Enrollments**: Links Students and Courses.  

### Important Relationships

- `Users` ↔ `Roles` through `UserRoles` (Many-to-Many)  
- `Students` linked to `Users` via `UserId` foreign key.  

This allows assigning multiple roles per user and maintaining domain-specific data separately.

---

## Project Structure
SchoolApi/
│
├── Controllers/ # API controllers (AuthController, StudentController)
├── CustomMiddleware/ # Custom middleware classes (e.g., ExceptionMiddleware)
├── Data/ # EF DbContext and database-related configurations
├── DTOs/ # Data Transfer Objects for API input/output
├── Helpers/ # Helper classes such as Mappers and Encryption utilities
├── Interfaces/ # Service interfaces
├── Logs/ # Application logs (if configured)
├── Models/ # EF Core entity classes mapped from database tables
├── Services/ # Business logic implementations (AuthService, StudentService)
├── appsettings.json # Configuration file for database connection, JWT settings, etc.
├── Program.cs # Application entry point and service configuration
└── SchoolApi.http # HTTP requests file for testing APIs (optional)

## Setup and Installation

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)  
- IDE like Visual Studio 2022 or VS Code

## Contributing

Contributions are highly appreciated! Please follow these steps:

Fork the repository

Create a feature branch (git checkout -b feature/your-feature)

Commit your changes (git commit -m 'Add some feature')

Push to your branch (git push origin feature/your-feature)

Open a Pull Request

Please ensure code style consistency and add tests for new features.

## License

This project is licensed under the MIT License. See the LICENSE
 file for details.

## Contact

For questions or support, please contact:
Name – Sachin Kanzariya
GitHub: https://github.com/SachinK027
