# Password Manager

## Overview

This is a secure and user-friendly Password Manager desktop application built with WinForms. It allows users to securely store and centralize all their passwords in one place. The application ensures the security of the stored data by utilizing encryption and follows best practices for secure password management.

## Features

- **Secure Password Storage:** All passwords are encrypted using DPAPI (Data Protection API) before being stored in the SQLite database.
- **Centralized Password Management:** Manage all your passwords securely in one place.
- **User-Friendly Interface:** Intuitive and easy-to-use WinForms interface.
- **Robust Logging:** Integrated logging using Serilog to keep track of application activities.
- **Data Access:** Efficient data access layer using Dapper.
- **Dependency Injection:** Implementation of dependency injection for better code maintainability and testability.
- **Command and Query Handling:** Uses MediatR pattern to manage application commands and queries.
- **Unit Testing:** Comprehensive xUnit tests with mocking to ensure code reliability.
