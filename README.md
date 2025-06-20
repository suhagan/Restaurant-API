# Restaurant API

## Overview

This project is a backend API designed to streamline restaurant management tasks. It enables administrators to efficiently handle reservations, customer information, table availability, and menu items through a RESTful interface. The API supports full CRUD operations for all core entities and ensures optimal performance for database interactions.

## Technologies

- **.NET 8**
- **Entity Framework Core** (Code-First Approach)
- **SQL Server**
- **Swagger** for API documentation


## Database Schema

The database consists of the following tables:

- **Table**: Stores table information such as table number and number of seats.
- **Customer**: Stores customer data including name and contact information.
- **Reservation**: Stores reservation data, linking customers to tables, along with the reservation date and number of people.
- **Dish**: Stores menu info, including the name, price, and availability.

## API Endpoints

### Table Endpoints

- `GET /api/table`: Retrieves all tables.
- `GET /api/table/{tableId}`: Retrieves a specific table by its ID.
- `POST /api/table/createTable`: Creates a new table.
- `PUT /api/table/update/{tableId}`: Updates an existing table.
- `DELETE /api/table/delete/{tableId}`: Deletes a table by ID.
- `GET /api/table/availableTables?date={date}&partySize={partySize}`: Retrieves available tables for a given date and party size.

### Customer Endpoints

- `GET /api/customer`: Retrieves all customers.
- `GET /api/customer/{customerId}`: Retrieves a specific customer by ID.
- `POST /api/customer/createCustomer`: Creates a new customer.
- `PUT /api/customer/update/{customerId}`: Updates an existing customer.
- `DELETE /api/customer/delete/{customerId}`: Deletes a customer by ID.

### Reservation Endpoints

- `GET /api/reservation`: Retrieves all reservations.
- `GET /api/reservation/{reservationNumber}`: Retrieves a specific booking by ID.
- `POST /api/reservation/createRes`: Creates a new reservation. It checks if the table is available before creating the reservation.
- `PUT /api/reservation/update/{reservationNumber}`: Updates an existing reservation.
- `DELETE /api/reservation/delete/{reservationNumber}`: Deletes a reservation by reservation number..

### Menu Endpoints

- `GET /api/menu`: Retrieves all menu items (dishes).
- `GET /api/menu/{dishId}`: Retrieves a specific dish by ID.
- `POST /api/menu/createDish`: Creates a new dish.
- `PUT /api/menu/update/{dishId}`: Updates an existing dish by ID.
- `DELETE /api/menu/delete/{dishId}`: Deletes a dish by ID.
