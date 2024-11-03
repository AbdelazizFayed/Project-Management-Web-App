# Project Management Web App

This is a web application for managing projects and tasks. It provides features for user registration, login, project creation, task assignment, and more.

## Installation

1. Clone the repository
2. Navigate to the project directory: `cd project-management-web-app`
3. Install the dependencies: `dotnet restore`
4. Set up the database:
   - Open the `appsettings.json` file in the `ProjectManagementWebApp` project.
   - Update the connection string with your database credentials.
   - Run the database migrations: `dotnet ef database update`
5. Start the application: `dotnet run`
6.  It includes data seeding that will run and create some basic data when the application is started.
## Login
User Name : AlicJohnson@manager.com
Password : Password123!

## Design Choices

### Authentication and Authorization

- User registration and login are implemented using ASP.NET Core Identity.
- JWT (JSON Web Tokens) are used for authentication and authorization.
- Role-based access control is implemented using Identity Roles.

### Database Design

- The database schema is designed using Entity Framework Core Code-First approach.
- There are two main entities: `Project` and `Task`.
- The `Project` entity has a one-to-many relationship with the `Task` entity.
- The `User` entity is extended from the IdentityUser class and is used for authentication and authorization.

## API Documentation

The API endpoints are documented using Swagger (Swashbuckle.AspNetCore). You can access the API documentation by running the application and navigating to `/swagger` in your browser.
