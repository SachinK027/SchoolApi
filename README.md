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

