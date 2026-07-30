# LMSystem — Library Management System

A full-stack Library Management System built with **ASP.NET Core MVC (.NET 8)**, **Entity Framework Core**, and **SQL Server**, featuring catalogue management, a borrow/return workflow, a statistics dashboard, and role-based account management.

## Features

- **Books, Publications (Newspapers/Magazines), Students & Librarians** — full CRUD with search and pagination.
- **Borrow / Return workflow** — books are automatically marked unavailable when borrowed and available again when returned.
- **Dashboard** — real-time counts of books, borrowings, students, librarians, and publications.
- **Accounts & Roles** — Admin, Librarian, Teacher, and Student roles with hashed (PBKDF2-SHA256) passwords.
  - Admin-only account management (create / edit / delete users, assign roles).
  - Safeguards against self-lockout and deleting the last remaining Admin.
- **User Profiles** — every user can view their info, edit their name/email, and change their password.
- **REST API** (`/api/*`) powering a secondary static HTML/JS front end in `wwwroot`.

## Tech Stack

- ASP.NET Core MVC (.NET 8), C#
- Entity Framework Core 8 (Code-First, SQL Server)
- Bootstrap 5 + Bootstrap Icons
- Session-based authentication with PBKDF2 password hashing

## Project Structure

```
LMSystem/
├── Controllers/       MVC controllers + Controllers/Api (REST endpoints)
├── Models/             Domain entities, LibraryContext, PasswordHasher
├── ViewModels/         View-specific data models
├── Dtos/                API request/response objects
├── Filters/              RequireLoginFilter, RequireRoleAttribute
├── Views/                 Razor views
├── Migrations/             EF Core migrations
└── wwwroot/                Static assets + parallel static HTML/JS client
frontend/                    Source copy of the static HTML/JS client
```

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server or SQL Server LocalDB

### Setup

```bash
cd LMSystem
dotnet restore
dotnet ef database update   # requires: dotnet tool install --global dotnet-ef
dotnet run
```

The app starts at `http://localhost:5093` by default (see `Properties/launchSettings.json`). Update the `DefaultConnection` string in `appsettings.json` if your SQL Server instance differs.

### Default Accounts (seed data)

| Username | Password | Role |
|---|---|---|
| `admin` | `12345` | Admin |
| `mycodingproject` | `myc546` | Librarian |
| `my` | `myc` | Student |

> Change these credentials before any real deployment.

## Documentation

See [`LMSystem_Project_Report.md`](LMSystem_Project_Report.md) for the full project report (requirements, design, testing, etc.).


