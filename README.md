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

8. First register and login then user token for accessing other apis.

## Endpoints

 
**Category Endpoints**
-GET /api/v1/categories
-Get a list of categories (Admin & User)

-POST /api/v1/categories
-Create a new category (Admin-only)

-GET /api/v1/categories/{id}
-Get a category by ID (Admin & User)

-PUT /api/v1/categories/{id}
-Update an existing category (Admin-only)

-DELETE /api/v1/categories/{id}
-Delete a category (Admin-only)

**Inventory Endpoints**
-GET /api/v1/inventory
-Get a list of inventory items (Admin & User)

-POST /api/v1/inventory
-Add a new inventory item (Admin-only)

-GET /api/v1/inventory/{id}
-Get an inventory item by ID (Admin & User)

-PUT /api/v1/inventory/{id}
-Update an inventory item (Admin-only)

-DELETE /api/v1/inventory/{id}
-Delete an inventory item (Admin-only)

**Inventory Transaction Endpoints**
-GET /api/v1/inventory-transactions
-Get a list of inventory transactions (Admin & User)

-POST /api/v1/inventory-transactions
-Create a new inventory transaction (Admin-only)

-GET /api/v1/inventory-transactions/{id}
-Get an inventory transaction by ID (Admin & User)

**Price Adjustment Endpoints**
-GET /api/v1/price-adjustments
-Get a list of price adjustments (Admin & User)

-POST /api/v1/price-adjustments
-Create a new price adjustment (Admin-only)

-GET /api/v1/price-adjustments/{id}
-Get a price adjustment by ID (Admin & User)

**Product Endpoints**
-GET /api/v1/products
-Get a list of products (Admin & User)

-POST /api/v1/products
-Create a new product (Admin-only)

-GET /api/v1/products/{id}
-Get a product by ID (Admin & User)

-PUT /api/v1/products/{id}
-Update an existing product (Admin-only)

-DELETE /api/v1/products/{id}
-Delete a product (Admin-only)

**User Endpoints**
-POST /api/v1/users/register
-Register a new user (User-only)

-POST /api/v1/users/login
-Login to get a JWT token (User-only)

-GET /api/v1/users/{id}
-Get user details by ID (Admin & User)

-DELETE /api/v1/users/{id}
-Delete a user (Admin-only)



## License

MIT License. See `LICENSE` for more details.
