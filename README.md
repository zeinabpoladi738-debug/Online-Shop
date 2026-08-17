# 🛒 Online Shop

A backend-focused e-commerce application built with **ASP.NET Core** using **Clean Architecture, CQRS, MediatR, Entity Framework Core, and SQL Server**.

## 🚀 Overview

Online Shop is an e-commerce backend project designed with a clean and maintainable architecture.

The project provides APIs for managing products and shopping baskets and demonstrates modern backend development practices with .NET.

## 🛠️ Technologies

* **.NET 8 / ASP.NET Core**
* **C#**
* **Entity Framework Core**
* **SQL Server**
* **CQRS**
* **MediatR**
* **Clean Architecture**
* **Repository Pattern**
* **RESTful APIs**
* **Swagger / OpenAPI**

## 🏗️ Architecture

The project follows a layered architecture inspired by **Clean Architecture** principles.

```text
Online Shop
│
├── Shop.Domain
│   └── Entities
│
├── Shop.Application
│   ├── Commands
│   ├── Queries
│   ├── Handlers
│   ├── Responses
│   └── Interfaces
│
├── Shop.Infrastructure
│   ├── Data
│   ├── Repositories
│   ├── Configurations
│   └── Migrations
│
└── Shop.presentation
    ├── Controllers
    ├── Program.cs
    └── Configuration
```

## ✨ Features

### Product Management

* Create products
* Update products
* Delete products
* Get product by ID
* Get all products

### Shopping Basket

* Create shopping basket
* Add products to basket
* Retrieve basket
* Manage basket items

## 🧩 Design Patterns & Principles

This project demonstrates the use of:

* Clean Architecture
* CQRS
* Mediator Pattern
* Repository Pattern
* Dependency Injection
* Separation of Concerns
* Domain-driven design principles

## 📁 Project Structure

### Shop.Domain

Contains the core domain entities and business models.

### Shop.Application

Contains application logic including:

* Commands
* Queries
* Handlers
* DTOs / Responses
* Repository interfaces

### Shop.Infrastructure

Responsible for:

* Database access
* Entity Framework Core
* Repositories
* Entity configurations
* Database migrations

### Shop.presentation

Contains:

* API Controllers
* Application configuration
* Dependency Injection
* HTTP API endpoints

## 🗄️ Database

The project uses **SQL Server** with **Entity Framework Core**.

Database migrations are included in the Infrastructure project.

## 📖 API Documentation

The API can be tested and explored using **Swagger / OpenAPI**.

After running the application, open:

```text
https://localhost:<port>/swagger
```

## ▶️ Getting Started

### Prerequisites

* .NET 8 SDK
* SQL Server
* Visual Studio 2022 or another compatible IDE

### Clone the repository

```bash
git clone https://github.com/zeinabpoladi738-debug/Online-Shop.git
```

### Navigate to the project

```bash
cd Online-Shop
```

### Configure the database

Update the connection string in:

```text
Shop.presentation/appsettings.json
```

with your local SQL Server configuration.

### Apply migrations

```bash
dotnet ef database update
```

### Run the application

```bash
dotnet run --project Shop.presentation
```

Then open Swagger to test the API.

## 📌 Future Improvements

* JWT Authentication & Authorization
* Order Management
* Payment Integration
* Redis Caching
* Docker Support
* Automated Testing
* API Gateway
* Frontend integration

## 👩‍💻 Author

**Zeinab**

Backend Developer | ASP.NET Core | C#

---

⭐ If you find this project useful, feel free to explore the repository.
