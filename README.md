# SchoolApi

A comprehensive RESTful Web API built with **.NET 8**, showcasing multiple data access approaches — including **Entity Framework Core (Database-First)**, **ADO.NET**, and **Dapper** — to perform CRUD operations on a school management system. The API manages users, roles, students, courses, and enrollments with features such as JWT authentication and role-based authorization.

---

## Table of Contents

- [Overview](#overview)  
- [Features](#features)  
- [Data Access Approaches](#data-access-approaches)  
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

This API provides core functionalities for a school management system, including:

- User registration with role assignment (Student, Teacher, Admin)  
- Secure login with JWT token generation and validation  
- Role-based authorization restricting access to sensitive endpoints  
- Management of Students, Courses, and Enrollments  
- Centralized error handling via custom middleware  
- Password encryption and secure authentication

Uniquely, this project demonstrates **three distinct data access approaches** in the same codebase, allowing for comparison and learning:

- **Entity Framework Core (Database-First)**: Auto-generated models and DbContext based on an existing SQL Server database schema.  
- **ADO.NET**: Low-level, direct database interaction using `SqlConnection`, `SqlCommand`, and `SqlDataReader` for raw SQL execution and manual data mapping.  
- **Dapper**: Lightweight micro-ORM for efficient and simple object mapping with raw SQL queries.

---

## Features

- **User Management**: Registration, login, role assignment  
- **JWT Authentication**: Secure token-based access control  
- **Role-Based Authorization**: Granular endpoint protection based on roles  
- **Student & Course Management**: Full CRUD support  
- **Multiple Data Access Approaches**: EF Core, ADO.NET, and Dapper implemented via separate controllers  
- **Custom Middleware**: Error handling and logging support  
- **Password Encryption**: Secure storage of user credentials  

---

## Data Access Approaches

| Approach            | Description                                                        | Usage in Project                              | Pros                              | Cons                                    |
|---------------------|--------------------------------------------------------------------|----------------------------------------------|----------------------------------|-----------------------------------------|
| **Entity Framework Core (EF Core)** | High-level ORM with model classes generated from database schema (Database-First). Supports LINQ queries, change tracking, and migrations. | `StudentController` (and others) | Rapid development, easy to maintain | Can be slower for complex queries       |
| **ADO.NET**          | Low-level data access using raw SQL commands and manual data mapping with `SqlConnection`, `SqlCommand`, and `SqlDataReader`. | `StudentAdoController`                     | Maximum control, lightweight      | Verbose code, manual mapping required    |
| **Dapper**           | Lightweight micro-ORM providing fast object mapping to SQL query results. Less verbose than ADO.NET but more control than EF Core. | `StudentDapperController`                  | Fast, simple syntax, good performance | Limited advanced ORM features            |

Each approach is implemented in its own controller to clearly separate concerns and allow easy testing and comparison.

---

## Technologies

- **.NET 8** (ASP.NET Core Web API)  
- **Entity Framework Core** (Database-First)  
- **ADO.NET** (System.Data.SqlClient)  
- **Dapper** (Micro-ORM)  
- **SQL Server**  
- **JWT (JSON Web Tokens)** for authentication  
- **C# 12**  
- Dependency Injection and Middleware pipeline  
- Visual Studio / VS Code  

---

## Database Schema

The database schema includes:

- **Users**: Stores user authentication details  
- **Roles**: Role definitions (Admin, Student, Teacher)  
- **UserRoles**: Many-to-many mapping between Users and Roles  
- **Students**: Student-specific data linked to Users  
- **Courses**: Courses offered  
- **Enrollments**: Linking Students and Courses  

---

## Project Structure

```plaintext
SchoolApi/
│
├── Controllers/                # API Controllers
│   ├── StudentController.cs        # EF Core (Database-First) data access
│   ├── StudentAdoController.cs     # ADO.NET data access
│   ├── StudentDapperController.cs  # Dapper data access
│   └── ...                        
├── CustomMiddleware/           # Middleware for error handling
├── Data/                      # EF DbContext and configurations
├── DTOs/                      # Data Transfer Objects
├── Helpers/                   # Utility classes like encryption
├── Interfaces/                # Service interfaces
├── Models/                    # EF Core entities
├── Services/                  # Business logic implementations
├── appsettings.json           # Configurations (DB connection, JWT, etc.)
├── Program.cs                 # App startup and DI configuration
└── SchoolApi.http             # HTTP request collections for testing APIs


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
