
#Caseworker – Task Management API

A secure, lightweight Task Management API built with **ASP.NET Core 8**, **Dapper**, and **SQL Server**. This project lets authenticated users create, view, update, and delete their personal tasks.

It’s cleanly architected with repository and service layers, secured using **JWT authentication**, and ready for frontend integration (e.g. React). Swagger UI is also included to make testing a breeze.

---
## 🚀 Features

- ✅ User registration and login with hashed passwords  
- 🔐 JWT-based authentication for protected routes  
- 📝 Create, update, view, and delete tasks  
- 📄 Swagger UI for API exploration and testing  
- 🌍 CORS enabled (default origin: `http://localhost:3000`)  
- 🔧 Clean separation of concerns via repositories and services  
---

## 🛠️ Tech Stack

- **Backend**: ASP.NET Core 8 Web API  
- **ORM**: Dapper (Micro ORM)  
- **Database**: SQL Server  
- **Security**: JWT tokens & secure password hashing  
- **Docs**: Swagger (OpenAPI)  
- **Extras**: CORS, Dependency Injection, Configuration via `appsettings.json`  
---

## ⚙️ Setup Instructions

### ✅ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)  
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)  
- Visual Studio or VS Code  

### 📂 Clone Repository

```bash
git clone https://github.com/ejimeoghenefejiro/Caseworker.git
cd Caseworker
```

---

### 🧱 Database Setup

1. Open SQL Server Management Studio.  
2. Run the following SQL script to create the required tables:

```sql
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    CreatedOn DATETIME NOT NULL DEFAULT GETUTCDATE()
);

CREATE TABLE Tasks (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Status NVARCHAR(50) NOT NULL,
    DueDate DATETIME NOT NULL,
    CreatedOn DATETIME NOT NULL DEFAULT GETUTCDATE(),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
);
```

---

### 🔑 Configuration

Edit the `appsettings.json` file:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "SqlServerConnection": "Server=localhost;Database=CaseWokerAPI;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true"
  },
  "CorsOptions": {
    "PolicyName": "ApiPolicy",
    "AllowedOrigin": "http://localhost:3000"
  },
  "JwtToken": {
    "Audience": "CaseworkerClient",
    "Issuer": "CaseworkerAPI",
    "Key": "YOUR_SECRET_KEY",
    "Seconds": 180
  },
  "AllowedHosts": "*",
  "PasswordHasher": {
    "Iterations": 10000
  }
}
```

> Replace `"YOUR_SECRET_KEY"` with a strong secret key.

---

## ▶️ Run the Application

```bash
dotnet run
```

Visit:

```
https://localhost:5001/swagger
```

to test the API via Swagger UI.

---

## 🙌 Contributions

Pull requests and ideas are welcome. This is a simple and extendable base project that can grow with your needs.
