# 💸 Personal Finance Tracker

A Blazor WebAssembly application with ASP.NET Core API backend for managing and tracking personal income and expenses.

---

## 📋 Features

- Track income and expense transactions
- Categorize transactions by type (e.g., Food, Salary, Utilities)
- View recent transactions in a responsive table
- Add, edit, and delete transactions using MudBlazor dialogs
- Validation for transaction form inputs
- ASP.NET Core Web API for data management
- EF Core + Unit of Work + Repository pattern
- Unit tests for service layer

---

## 🚀 Tech Stack

| Technology       | Description                            |
|------------------|----------------------------------------|
| **Blazor WASM**  | Frontend UI                            |
| **ASP.NET Core 8** | Web API backend                      |
| **Entity Framework Core** | ORM for data access           |
| **MudBlazor**    | UI components library                  |
| **xUnit**        | Unit testing framework                 |
| **AutoMapper**   | Mapping between DTOs and entities      |
| **SQL Server**   | Relational database                    |

---
```
## 🧩 Project Structure

📁 PersonalFinanceTracker/
│
├── 📁 FinanceTracker.App # Blazor frontend
├── 📁 FinanceTracker.Api # ASP.NET Core API
├── 📁 FinanceTracker.BLL # Business Logic
├── 📁 FinanceTracker.DAL # Data Access
├── 📁 FinanceTracker.Shared # Shared models
├── 📁 FinanceTracker.Tests # Unit tests
│
├── PersonalFinanceTracker.sln # Solution file
└── README.md

```
---

## ⚙️ Getting Started

### 🧑‍💻 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server] installed
- Git

### 🛠️ Running the Application

1. **Clone the repository**

```bash
git https://github.com/isuru-uwk/FinanceTracker.git
cd FinanceTracker
```

2. **Clone the repository**

Run the API Server

```bash
cd FinanceTracker.Api
dotnet run
```

Run the Blazor App

```bash
cd FinanceTracker.App
dotnet run
```

