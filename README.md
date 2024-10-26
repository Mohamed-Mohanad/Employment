# Employment System

The **Employment** system is a comprehensive job application management system built with ASP.NET Core. The system allows employers to manage job vacancies and applicants to submit applications for open positions. The system includes features like vacancy management, applicant management, application submission, and more. It also uses Redis for caching to improve performance, and the setup includes instructions for configuring Redis as a local server on your machine.

## Table of Contents

- [Features](#features)
- [Project Setup](#project-setup)
- [Redis Setup](#redis-setup)
- [Included Resources](#included-resources)

## Features

1. **Vacancy Management**: Employers can create, update, delete, and view job vacancies.
2. **Applicant Management**: Applicants can register and apply for job vacancies.
3. **Application Management**: The system stores all job applications, allowing employers to manage submissions.
4. **Caching with Redis**: Redis is used to cache frequently accessed data, improving performance.
5. **Data Validation**: The system validates all incoming requests with custom validation behaviors.
6. **Entity Framework Core**: Manages database interactions and relationships.
7. **Serilog for Logging**: Integrated logging system using Serilog to capture and manage log information effectively.
8. **Hangfire for Background Jobs**: Utilizes Hangfire for scheduling and managing background jobs, enhancing asynchronous processing.
9. **CQRS and Clean Architecture**: Implements Command Query Responsibility Segregation (CQRS) along with Clean Architecture principles to separate concerns and improve maintainability.
10. **Design Patterns**: Employs various design patterns, including:
    - **Factory Pattern**
    - **Facade Pattern**
    - **Unit of Work Pattern**
    - **Generic Repository Pattern**
    - **Specification Pattern**
    - **Options Pattern**
11. **Fluent Validation Behavior**: Integrates Fluent Validation to provide a robust way of validating model properties and incoming requests.
12. **Database Seeders for Company and Roles**: Includes seeders for initializing the database with default values for companies and roles, ensuring a smoother setup process.
13. **Database Interceptor for Auditing Entities**: Implements an interceptor for tracking changes to entities for auditing purposes, providing a history of modifications.

## Project Setup

Follow these steps to get the **Employment** system up and running on your local machine:

1. Clone the repository:

   ```bash
   git clone https://github.com/YourUsername/EmploymentSystem.git
   cd EmploymentSystem
   ```

2. Restore the .NET dependencies:

   ```bash
   dotnet restore
   ```

3. Update the database:

   ```bash
   dotnet ef database update
   ```

4. Configure the database connection in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=Employment;Trusted_Connection=True;"
   }
   ```

5. Build and run the project:
   ```bash
   dotnet build
   dotnet run
   ```

## Redis Setup

The **Employment** system uses Redis for caching. To set up Redis on your local machine:

1. **Download and extract the attached Redis zip file** that is included with this project. The zip file contains Redis binaries and a setup for Windows.
2. Unzip the contents to a location on your system, such as `C:\Redis`.

3. Inside the extracted folder, locate the `redis-server.exe` file and run it. This will start a local Redis server.

4. Redis is now set up and running. The application will automatically connect to it and use it for caching operations.

5. Install Another Redis Desktop Manager Application And Open It

## Included Resources

In the GitHub repository, you will find the following additional resources:

- **Database Backup**: A backup of the database to restore or seed data.
- **Database Create Script**: A SQL script to create the necessary tables and seed initial data.
- **Redis Desktop Manager**: A tool to manage Redis instances and data easily.
- **Redis Server**: The Redis server binaries for local setup.
- **Postman Collection**: A Postman collection for testing the API endpoints.
