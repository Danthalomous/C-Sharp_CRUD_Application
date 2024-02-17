# C# CRUD Application

![C# CRUD Application](CSharp_CRUD_Application.png)

This repository contains a simple C# CRUD (Create, Read, Update, Delete) application built using the MVC pattern.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup](#setup)
- [Usage](#usage)
- [Endpoints](#endpoints)
- [Screenshots](#screenshots)

## Features

- **CRUD Operations:** Perform Create, Read, Update, and Delete operations on data.
- **MVC Architecture:** Follows the Model-View-Controller pattern for organizing code and separating concerns.
- **C#:** Developed using the C# programming language.
- **ASP.NET Core MVC:** Utilizes ASP.NET Core MVC for building web applications.

## Technologies Used

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (or your preferred database)
- Visual Studio (or Visual Studio Code)

## Setup

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/your-repository.git
    ```

2. **Navigate to the project directory:**

    ```bash
    cd your-repository
    ```

3. **Configure the database:**

    - Create a SQL Server database (or use an existing one).
    - Update the database connection string in `appsettings.json`.

4. **Open the project in Visual Studio (or Visual Studio Code).**

5. **Build and run the application:**

    - Press F5 or use the "Start" button in Visual Studio to build and run the application.

## Usage

Once the application is up and running, you can interact with it through its web interface.

## Endpoints

- **GET /Products:** Retrieve all entities.
- **GET /Products/{id}:** Retrieve an entity by ID.
- **POST /Products:** Create a new entity.
- **PUT /Products/{id}:** Update an entity by ID.
- **DELETE /Products/{id}:** Delete an entity by ID.

## Screenshots

- Here are the results of the /Products GET request:
  ![Products Page](Products_Page.png)

- Here is what the /Products/Add form page looks like:
  ![New Product Page](New_Product_Page.png)
