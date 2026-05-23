# ComputerManagementApi

REST Web API for managing computers and their components, built with ASP.NET Core and Entity Framework Core (Code First approach).

## Technologies

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core 10
- SQLite

## Project Structure

```
ComputerManagementApi/
├── Controllers/        # API layer - HTTP endpoints
├── Services/           # Business logic layer
├── DTOs/               # Data Transfer Objects
├── Models/             # Entity classes
├── Data/               # AppDbContext + seed data
├── Migrations/         # EF Core migrations
├── appsettings.json
└── Program.cs
```

## Database Schema

- **PCs** — computers with name, weight, warranty, stock
- **Components** — hardware components with code (PK), name, description
- **ComponentTypes** — type of component (CPU, GPU, RAM, SSD)
- **ComponentManufacturers** — manufacturer details
- **PCComponents** — join table between PCs and Components (composite PK)

## Getting Started

### Prerequisites

- .NET 10 SDK
- dotnet-ef tool

Install the EF Core CLI tool if not already installed:

```bash
dotnet tool install --global dotnet-ef
```

### Setup

1. Clone the repository
2. Navigate to the project folder:
```bash
cd ComputerManagementApi
```

3. Restore packages:
```bash
dotnet restore
```

4. Apply migrations and seed the database:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

5. Run the application:
```bash
dotnet run
```

The API will be available at `http://localhost:5000`.

## Endpoints

| Method | Endpoint | Description | Status codes |
|--------|----------|-------------|--------------|
| GET | `/api/pcs` | Get all computers | 200 |
| GET | `/api/pcs/{id}/components` | Get components of a specific PC | 200, 404 |
| POST | `/api/pcs` | Add a new computer | 201, 400 |
| PUT | `/api/pcs/{id}` | Update an existing computer | 200, 404 |
| DELETE | `/api/pcs/{id}` | Delete a computer | 204, 404 |

## Example Requests

### GET /api/pcs
```json
[
  {
    "id": 1,
    "name": "Gaming Beast X",
    "weight": 12.5,
    "warranty": 36,
    "createdAt": "2026-05-08T09:00:00",
    "stock": 5
  }
]
```

### GET /api/pcs/1/components
```json
{
  "id": 1,
  "name": "Gaming Beast X",
  "weight": 12.5,
  "warranty": 36,
  "createdAt": "2026-05-08T09:00:00",
  "stock": 5,
  "components": [
    {
      "amount": 1,
      "component": {
        "code": "CPU0000001",
        "name": "Ryzen 7 7800X3D",
        "description": "8-core gaming processor",
        "manufacturer": {
          "id": 1,
          "abbreviation": "AMD",
          "fullName": "Advanced Micro Devices",
          "foundationDate": "1969-05-01"
        },
        "type": {
          "id": 1,
          "abbreviation": "CPU",
          "name": "Processor"
        }
      }
    }
  ]
}
```

### POST /api/pcs
```json
{
  "name": "Gaming Beast X",
  "weight": 12.5,
  "warranty": 36,
  "createdAt": "2026-05-08T09:00:00",
  "stock": 5
}
```

### PUT /api/pcs/1
```json
{
  "name": "Gaming Beast X Updated",
  "weight": 13.0,
  "warranty": 36,
  "createdAt": "2026-05-08T09:00:00",
  "stock": 3
}
```
