# BTRS: Bus Trips Reserving System

A web application for booking bus trips, built with **ASP.NET Core MVC**, **Entity Framework Core** and **SQL Server**.

This is a university team project (Applied Science Private University, early 2024), based on a given scenario: *ABC Bus Travels* wants an online system where passengers can book trips and administrators can manage them.

## Features

**Passengers**
- Sign up with name, email, phone number, username, password and gender
- Validation that prevents duplicate usernames, emails and phone numbers, and rejects empty inputs
- Log in, browse the list of available trips, and view trip details
- Book trips and view a bookings page

**Administrators**
- Log in and manage trips and buses (create, view, edit, delete)
- Admin pages are generated from MVC scaffold templates, as the assignment required

## Tech stack

- C#, ASP.NET Core MVC (.NET 6), Razor views
- Entity Framework Core 6 (code-first, migrations)
- SQL Server (LocalDB)
- Bootstrap, HTML helpers, data-annotation validation

## Project structure

```
BTRS/
  Controllers/   passenger, administrator, trips and bookings controllers
  Models/        passenger, administrator, trip, bus, BookingTrips, MyDbContext
  Views/         Razor views per controller
  Migrations/    EF Core migrations
  Program.cs     service registration, DbContext and routing
```

## Running locally

Requirements: Visual Studio 2022 with the ASP.NET workload, the .NET 6 SDK, and SQL Server LocalDB.

1. Open `BTRS.sln` in Visual Studio.
2. Open **Tools > NuGet Package Manager > Package Manager Console** and run:
   ```
   Update-Database
   ```
   This creates the `BTRS` database from the migrations.
3. Press **F5** to run.

The connection string is in `Program.cs` and points to `(localdb)\MSSQLLocalDB`.

## Planned improvements

This project was built for a course assignment. The following points are planned as separate improvements:

- **Passwords** are stored as plain text and should be hashed.
- **Authentication:** login does not yet create a session or cookie, so pages are not protected with `[Authorize]` and roles are not enforced.
- **Bookings model:** bookings are not yet linked to a passenger. A many-to-many relationship between passengers and trips is needed.
- **Sign-up** currently clears the bookings table, which needs to be fixed.
- **Seat capacity** is not checked when booking a trip.
- **Automated tests** are not included yet.
- **Configuration:** move the connection string to configuration and upgrade from .NET 6 to a supported version.
