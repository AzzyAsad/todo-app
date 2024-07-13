# Todo App

A simple Todo application built with React functional components and a .NET 8 Minimal APIs using vertical slicing architecture.

## Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Tech Stack](#tech-stack)
- [Installation](#installation)

## Features

- Create, read, update, and delete todo items.
- Persistent data storage on the server using Entity Framework In Memory.
- In-memory data storage to mimic actual data storing and retrieving behavior without the need for executing any migrations.
- For validations, I have used FluentValidation on the server side.

## Architecture

This project follows the vertical slicing architecture, which organizes the code by features instead of technical concerns. Each feature (or slice) contains all the relevant code such as models, controllers, and services, making the codebase more modular and easier to maintain.

## Tech Stack

### Frontend

- React (functional components)
- Axios for HTTP requests
- Tailwind CSS for styling

### Backend

- .NET 8 Minimal API
- Entity Framework for data storage

## Installation & Setup

### Prerequisites

- Node.js
- .NET 8 SDK

### Clone repository

   ```bash
   git clone https://github.com/AzzyAsad/todo-app.git
   ```

### Change the working directory to .NET API Project
   ```bash
   cd todo-app\TodoApp.API\
   ```

### Restore .NET project packages
   ```bash
   dotnet restore
   ```

### Build .NET project
   ```bash
   dotnet build
   ```

### Start .NET API project
   ```bash
   dotnet run --launch-profile https
   ```

### Open a new terminal on same folder and then change the working directory to react UI Project
   ```bash
   cd todo-app\TodoApp.UI\todo-app
   ```

### Install node_modules
   ```bash
   npm install
   ```

### Start UI Project
   ```bash
   npm start
   ```
