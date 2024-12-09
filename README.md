## iWishApp

The iWishApp is a full-stack web application designed to allow users to create and manage wish lists. Built with ASP.NET Core MVC, Bootstrap, and a relational MySQL database, the application provides a responsive and secure platform for organizing personal or shared wish lists.

## Features

Dynamic User Authentication:
Uses ASP.NET Identity with MySQL integration for secure user management.
Provides role-based access control.
Homepage and Privacy Policy:
Includes a user-friendly landing page and a privacy policy section.
Responsive Design:
Utilizes Bootstrap for a fully responsive interface, ensuring compatibility across devices.
Database-Driven Functionality:
Integrates a MySQL relational database to store user credentials and wish list data securely.
Clean, Modular Architecture:
Separates concerns between UI, business logic, and database layers.]

## Technologies Used

ASP.NET Core MVC:
Framework for building server-side web applications.
Supports Razor Pages and layouts for consistent design.
Bootstrap:
Provides responsive UI components for modern web design.
jQuery:
Enables interactive client-side scripting.
MySQL:
Used as the relational database to manage application data.
Entity Framework Core:
Facilitates database migrations and simplifies data access in the application.

## Database Schema

The MySQL database includes the following key tables:

AspNetUsers: Stores user details like email, hashed passwords, and security stamps.
AspNetRoles: Manages roles for role-based access control.
AspNetUserRoles: Maps users to their roles.
WishLists (Planned Enhancement): Will store user-created wish lists and associated items.

## File Structure

Key Components:
Migrations:
Manages schema changes in the MySQL database using EF Core.
Views:
Includes shared layouts, homepage, and authentication-related views.
Controllers:
Handles HTTP requests and returns appropriate views or data.
Styles:
Custom CSS (iWishApp.styles.css) for branding and UI enhancements.

## Setup Instructions

Clone the Repository:
git clone https://github.com/your-repo/iWishApp.git
Configure the Database:
Update the appsettings.json file with your MySQL connection string:
"ConnectionStrings": {
    "DefaultConnection": "Server=your-server;Database=your-database;User=your-username;Password=your-password;"
}
Run Database Migrations: Execute the following command to set up the database:
dotnet ef database update
Build and Run:
Build the application:
dotnet build
Start the development server:
dotnet run
Access the app at http://localhost:5000.
## Usage

Register or Log In:
New users can register, while existing users can log in to manage their wish lists.
Navigate:
Use the responsive navbar to explore different sections of the app.
## Future Features:
Create and organize wish lists (to be implemented).
## Future Enhancements

Wishlist Management:
CRUD functionality for user wish lists and items.
Sharing Features:
Enable users to share wish lists with friends and family.
Improved Security:
Implement multi-factor authentication (MFA) for user accounts.
Enhanced Analytics:
Add user behavior analytics to improve the app's usability.
## Acknowledgments

Special thanks to all contributors who helped design and build the iWishApp during our SDE Aprenticeship at Launchcode in 2023

## License

This project is licensed under the MIT License. See the LICENSE file for details.
