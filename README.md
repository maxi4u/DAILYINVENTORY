# Daily Inventory Tracker 📊

Welcome to the Daily Inventory Tracker! This project is designed to help you effortlessly track and manage all your daily expenses, including bank account transactions and credit card expenditures. 

## Features ⭐️
- **All-in-One Tool**: Keep all your financial information in one convenient place.
- **Expense Management**: Easily monitor and categorize your daily expenses.
- **Financial Overview**: Get a clear view of your spending habits over time.

Whether you’re looking to maintain a budget or simply keep track of your finances, this tool is perfect for your everyday expense management!

Let's take control of our finances together! 💰✨

---

## Technology Stack 🛠️

- Language
  - C# (dotnet / .NET SDK)
- Platform & Framework
  - .NET / ASP.NET Core (projects target: net8.0)
  - Project SDKs used:
    - Microsoft.NET.Sdk.Web (for the Web project)
    - Microsoft.NET.Sdk (for library projects)
- Project layout
  - DailyInventory.Web (ASP.NET Core web app)
  - DailyInventory.Services (business logic)
  - DailyInventory.DataAccess (data access layer)
  - DailyInventory.Models (shared models)
  - DailyInventory.Utilities (utility helpers)
  - DAILYINVENTORY.sln (solution file)
- Key NuGet packages referenced
  - Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation (v8.0.2)
  - Microsoft.VisualStudio.Web.CodeGeneration.Design (v8.0.1)
  - Serilog.AspNetCore (v8.0.1)
  - Microsoft.Extensions.Configuration.Abstractions (v8.0.0)
  - System.Data.SqlClient (v4.8.6)
  - Microsoft.AspNetCore.Http.Abstractions (v2.2.0)
- Database
  - SQL Server (accessed via System.Data.SqlClient)
- Logging
  - Serilog (Serilog.AspNetCore)
- Tooling & CI
  - dotnet CLI / .NET SDK (build and run)
  - Visual Studio or VS Code for development
  - GitHub (Git) for source control
  - GitHub Actions (workflow present in repository; commit history indicates workflows reference .NET versions)
- Notes
  - The projects currently target net8.0 according to the project files.
  - The repository contains multiple class library projects and a web project structured as a typical layered .NET solution.

---

## References
- DailyInventory.Web project file: https://github.com/maxi4u/DAILYINVENTORY/blob/3e2cdfc2843748b7168d2402b8b78cd1a6b192c2/DailyInventory.Web/DailyInventory.Web.csproj
- DailyInventory.Services project file: https://github.com/maxi4u/DAILYINVENTORY/blob/3e2cdfc2843748b7168d2402b8b78cd1a6b192c2/DailyInventory.Services/DailyInventory.Services.csproj
- DailyInventory.DataAccess project file: https://github.com/maxi4u/DAILYINVENTORY/blob/3e2cdfc2843748b7168d2402b8b78cd1a6b192c2/DailyInventory.DataAccess/DailyInventory.DataAccess.csproj
- DailyInventory.Models project file: https://github.com/maxi4u/DAILYINVENTORY/blob/3e2cdfc2843748b7168d2402b8b78cd1a6b192c2/DailyInventory.Models/DailyInventory.Models.csproj
