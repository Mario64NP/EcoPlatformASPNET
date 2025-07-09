# EcoPlatform API 🌱

EcoPlatform API is a RESTful backend service designed for managing environmental initiatives. It provides endpoints for organizing cities, projects, and participants, making it easy to build client applications for environmental platforms, collaboration tools, or admin dashboards.

The API is lightweight, secure, and designed with scalability in mind, using modern ASP.NET Core practices.

---

## 🚀 Features

- Manage **cities**, **projects**, and **users** with full CRUD operations
- Assign users to projects and track participation
- Secure authentication with JWT bearer tokens
- Clean API contracts using DTOs to decouple data models
- Interactive API docs with Swagger UI
- EF Core migrations for easy database management

---

## 📦 Tech Stack

- **Framework:** ASP.NET Core Web API (.NET 9)  
- **Database:** SQL Server (LocalDB for development)  
- **ORM:** Entity Framework Core  
- **Authentication:** JWT Bearer tokens  
- **API Docs:** Swagger / Swashbuckle  

---

## ⚙️ Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022+ or VS Code
- SQL Server (LocalDB works out of the box for development)

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/Mario64NP/EcoPlatformASPNET.git
   cd EcoPlatformASPNET

2. **Configure user secrets**
   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\\mssqllocaldb;Database=EcoPlatformDb;Trusted_Connection=True;"
   dotnet user-secrets set "Jwt:Key" "your-very-strong-secret-key"
   dotnet user-secrets set "Jwt:Issuer" "EcoPlatformAPI"
   dotnet user-secrets set "Jwt:Audience" "EcoPlatformAPI"

3. **Apply migrations**
   ```bash
   dotnet ef database update

4. **Run the API**
   Either from the command line or your IDE
