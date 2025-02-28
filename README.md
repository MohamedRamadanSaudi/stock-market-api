# Stock Market API

A RESTful API for managing stocks, user portfolios, and comments, built with ASP.NET Core and Entity Framework Core. This API supports user authentication, role-based authorization, and CRUD operations for financial stock data.

## Features

- **User Authentication & Authorization**: Register, login, and manage users with JWT tokens.
- **Stock Management**: Create, read, update, and delete stocks.
- **Portfolio Management**: Users can track their stock portfolios.
- **Comments**: Users can post and manage comments on stocks.
- **Pagination & Filtering**: Query stocks with sorting, filtering, and pagination.
- **Swagger Documentation**: Integrated OpenAPI/Swagger for API exploration.

## Technologies

- **Framework**: ASP.NET Core 9.0
- **Database**: SQL Server (Entity Framework Core)
- **Authentication**: JWT Bearer Tokens
- **Tools**: Swagger/OpenAPI, Newtonsoft.Json, AutoMapper

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- SQL Server (or modify `appsettings.json` for another database)
- IDE (e.g., Visual Studio, VS Code)

### Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/MohamedRamadanSaudi/stock-market-api.git
   cd stock-market-api
   ```

2. **Configure the Database**

   - Update `appsettings.json` with your SQL Server connection string:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=StockMarketDB;Trusted_Connection=True;"
     }
     ```

3. **Configure JWT Settings**

   - Replace the placeholder values in `appsettings.json`:
     ```json
     "Jwt": {
       "Issuer": "your_issuer",
       "Audience": "your_audience",
       "SigningKey": "your_secure_key_here"
     }
     ```

4. **Apply Migrations**

   ```bash
   dotnet ef database update
   ```

5. **Run the Application**
   ```bash
   dotnet run
   ```
   - The API will start at `http://localhost:5229` (HTTP) or `https://localhost:7272` (HTTPS).

## API Endpoints

### Authentication

| Method | Endpoint                | Description                 |
| ------ | ----------------------- | --------------------------- |
| POST   | `/api/account/register` | Register a new user.        |
| POST   | `/api/account/login`    | Log in and get a JWT token. |

**Example Registration Request:**

```json
{
  "username": "john_doe",
  "email": "john@example.com",
  "password": "SecurePassword123!"
}
```

**Example Login Response:**

```json
{
  "userName": "john_doe",
  "email": "john@example.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Stocks

| Method | Endpoint          | Description                                 |
| ------ | ----------------- | ------------------------------------------- |
| GET    | `/api/stock`      | Get all stocks (supports query parameters). |
| GET    | `/api/stock/{id}` | Get a stock by ID.                          |
| POST   | `/api/stock`      | Create a new stock.                         |
| PUT    | `/api/stock/{id}` | Update a stock.                             |
| DELETE | `/api/stock/{id}` | Delete a stock.                             |

**Query Parameters for GET /api/stock:**

- `symbol`: Filter by stock symbol.
- `companyName`: Filter by company name.
- `sortBy`: Sort by `symbol` or other fields.
- `isDescending`: Set to `true` for descending order.
- `pageNumber`: Page number (default: 1).
- `pageSize`: Items per page (default: 10).

### Comments

| Method | Endpoint                 | Description               |
| ------ | ------------------------ | ------------------------- |
| POST   | `/api/comment/{stockId}` | Add a comment to a stock. |
| GET    | `/api/comment/{id}`      | Get a comment by ID.      |
| PUT    | `/api/comment/{id}`      | Update a comment.         |
| DELETE | `/api/comment/{id}`      | Delete a comment.         |

### Portfolios

| Method | Endpoint         | Description                               |
| ------ | ---------------- | ----------------------------------------- |
| GET    | `/api/portfolio` | Get the current user's portfolio.         |
| POST   | `/api/portfolio` | Add a stock to the portfolio (by symbol). |
| DELETE | `/api/portfolio` | Remove a stock from the portfolio.        |

## Testing with Swagger

Access the Swagger UI at `http://localhost:5229/swagger` (replace with HTTPS if needed) to explore and test endpoints interactively.

## Configuration

Key settings in `appsettings.json`:

- **Database Connection**: Set your SQL Server details under `ConnectionStrings`.
- **JWT Tokens**: Configure issuer, audience, and signing key for authentication.
