
# 🧱 Clean Architecture Web API (.NET 8)

![.NET 8](https://img.shields.io/badge/.NET-8.0-blue)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean%20Arch-brightgreen)
![REST API](https://img.shields.io/badge/Type-REST%20API-orange)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow)

A professional Web API project built using **Clean Architecture**, **.NET 8**, **Entity Framework Core**, **CQRS**, **Dependency Injection**, and proper domain-driven structure.

This repository is designed as a **portfolio-grade backend project** showing best practices used in modern .NET development.

## 🧰 Tech Stack

- .NET 8
- C#
- Clean Architecture
- CQRS + MediatR
- Entity Framework Core
- SQL Server / LocalDB
- FluentValidation (si lo agregas más adelante)
- Swagger / OpenAPI
- Dependency Injection
- Repository Pattern
- Domain-Driven Design (DDD) principles

---

# 📂 Project Structure

```
CleanArch/
│── CleanArch.Api/           → Presentation layer (controllers, DTOs, swagger)
│── CleanArch.Application/   → Use cases, CQRS, DTOs, validation
│── CleanArch.Domain/        → Entities, enums, interfaces, core logic
│── CleanArch.Infrastructure/→ EF Core, repositories, persistence
```

---

# 🚀 Features

- Fully structured Clean Architecture  
- REST API with CRUD operations  
- DTO validation  
- Repository pattern  
- EF Core with migrations  
- Dependency Injection everywhere  
- Swagger UI  
- Async/Await all the way  
- Extensible and production-ready  

---

# 🛠 Getting Started

### 1️⃣ Restore Dependencies
```bash
dotnet restore
```

### 2️⃣ Apply EF Core Migrations
```bash
dotnet ef database update --project CleanArch.Infrastructure
```

### 3️⃣ Run the API
```bash
dotnet run --project CleanArch.Api
```

API available at:

```
https://localhost:5001
http://localhost:5000
```

Swagger UI:

```
/swagger
```

---

## 🔗 Endpoints Overview

| Method | Endpoint               | Description             |
|--------|------------------------|-------------------------|
| GET    | /api/TodoItems         | Get all todo items      |
| GET    | /api/TodoItems/{id}    | Get todo item by ID     |
| POST   | /api/TodoItems         | Create a new todo item  |
| PUT    | /api/TodoItems/{id}    | Update an existing item |
| DELETE | /api/TodoItems/{id}    | Delete a todo item      |

---

# 📦 Example Request

### Create Todo
```json
POST /api/TodoItems
{
  "title": "Learn Clean Architecture",
  "description": "Understand layered patterns"
}
```

---

# ⭐ Why this project matters

This repository shows that you understand:

- Enterprise-level architecture  
- Separation of concerns  
- Dependency Inversion  
- Clean, testable code  
- Professional backend development  

Perfect for recruiters, interviews, and portfolio highlights.

---

## 🛠️ Roadmap

- [x] Project structure with Clean Architecture
- [x] CRUD operations for TodoItems
- [x] CQRS with MediatR (Commands & Queries)
- [x] Swagger documentation
- [ ] Add FluentValidation for DTOs
- [ ] Add pagination to GET /TodoItems
- [ ] Implement unit tests (xUnit / NUnit)
- [ ] Add authentication (JWT)
- [ ] Deploy to Azure / Render
- [ ] Add CI/CD pipeline with GitHub Actions

---

# 📜 License

This project is under the **MIT License**.
