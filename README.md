# E-Commerce Project

This project is an e-commerce web application developed using Asp.net MVC, HTML, CSS, JavaScript, and Bootstrap. Microsoft SQL Server is utilized as the database.

## Features

- User Authentication: Users can log in with roles such as ADMIN, PERSONNEL, and CUSTOMERS.
- **ADMIN**: Has extensive privileges, including managing products, adding/deleting personnel, and editing categories.
- **PERSONNEL**: Can perform operations like adding, deleting, and updating products, and view categories.
- **CUSTOMERS**: Can track invoices and sales movements but do not have access to the product list.

## Cart and Order Processes

- Users can view their information on the shopping cart page after placing an order and check the order status.
- The stock quantity of products sold is updated after each sale, and when it reaches zero, it automatically becomes invisible.
- Products with zero stock can be viewed on a dedicated page, and shortages can be addressed.

## Download and Copy Features

- All tables can be downloaded in Excel and PDF formats. This feature facilitates the management of invoices and sales movements.

## Installation

1. Clone the project to your computer.
2. Open the project using Visual Studio or a similar IDE.
3. Update the database connection information in the `web.config` file.
4. Run the project.

## Technologies

- Asp.net MVC
- HTML
- CSS
- JavaScript
- Bootstrap
- Microsoft SQL Server
   
