# ComputerManagementApi

REST Web API for managing computers and their components, built with ASP.NET Core and Entity Framework Core (Code First approach).

## Techstack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core 10
- SQLite

## Project Structure

```
ComputerManagementApi/
├── Controllers/
├── Services/
├── DTOs/
├── Models/
├── Data/
├── Migrations/
├── appsettings.json
└── Program.cs
```

## Database Schema

- **PCs** — computers with name, weight, warranty and stock
- **Components** — hardware components with code, name and description
- **ComponentTypes** — type of component
- **ComponentManufacturers** — manufacturer details
- **PCComponents** — join table between PCs and Components

## Prerequisites

- .NET 10 SDK
- dotnet-ef tool

Install the EF Core CLI tool if not already installed:

```bash
dotnet tool install --global dotnet-ef
```

## Setup

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

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/pcs` | Get all computers |
| GET | `/api/pcs/{id}/components` | Get components of a specific PC |
| POST | `/api/pcs` | Add a new computer |
| PUT | `/api/pcs/{id}` | Update an existing computer |
| DELETE | `/api/pcs/{id}` | Delete a computer |
