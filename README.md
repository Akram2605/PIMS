# PIMS API

## Overview

The **PIMS (Product Inventory Management System)** API is a RESTful backend service designed to manage users, products, and inventory. It offers role-based authentication, API versioning, and CRUD operations for managing data related to products and inventory.

## Features

- User management
- Product management
- Inventory management
- JWT Authentication (with roles)
- Versioned API (v1, v2)
- Swagger UI for API documentation

## Setup

1. Clone the repository:
    ```bash
    git clone https://your-repository-url.git
    ```

2. Set up the database:
    - Ensure SQL Server is installed and running.
    - Create `appsettings.development.json` in PIMS.api and fill following info=>
`
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=PIMS;User Id=sa;Password=my!Pass&word;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "ThisIsASecretKeyThatIsDefinitelyMoreThan32CharactersLong!",
    "Issuer": "PIMS.API",
    "Audience": "PIMS.API"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
`
3. Create `Properties/launchSettings.json` in PIMS.api and fill the following info=>
`
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:26948",
      "sslPort": 44323
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5085",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:7017;http://localhost:5085",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
`
   

4. Restore dependencies:
    ```bash
    dotnet restore
    ```

5. Apply database migrations:
    ```bash
    dotnet ef database update
    ```

6. Run the application:
    ```bash
    dotnet run
    ```

7. Access the API via Swagger:
    - [Swagger UI](http://localhost:5085/swagger) or [HTTPS](https://localhost:7017/swagger)

## Endpoints

- **User**:
    - Create user: `POST /api/v1/users/create`
    - Get user profile: `GET /api/v1/users/profile`
    - Delete user: `DELETE /api/v1/users/delete/{id}`

- **Product**:
    - Create product: `POST /api/v1/products/create`
    - Get products: `GET /api/v1/products`
    - Delete product: `DELETE /api/v1/products/{id}`

## License

MIT License. See `LICENSE` for more details.
