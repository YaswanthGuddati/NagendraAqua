# 🐟 Feed Management System

## 📌 Overview

The **Feed Management System** is a web-based application developed using **ASP.NET MVC** to manage aquaculture feed operations.
It enables administrators to handle feed inventory, customer orders, and seller management efficiently through a centralized dashboard.

---

## 🎥 Project Demo

Click below to watch the Feed Management System:
👉 [Click here to watch the demo](https://raw.githubusercontent.com/YaswanthGuddati/NagendraAqua/master/ScreenRecording%20(1).mp4)

---

## 🚀 Features

### 🔐 Admin Module

* Secure login with validation
* Session-based authentication
* Dashboard access control

### 📦 Customer Orders

* Place new feed orders
* Select feed and seller dynamically
* View all orders
* Search/filter orders
* Delete orders

### 🐟 Feed Management

* Add new feed types
* Edit feed details
* Delete feeds
* View feed list

### 👨‍🌾 Seller Management

* Add new sellers
* View seller list
* Delete sellers

### ✅ Validations

* Required field validation
* Mobile number validation (10-digit Indian format)
* Quantity validation

---

## 🛠️ Tech Stack

* **Frontend:** HTML, CSS, Bootstrap, Razor Views
* **Backend:** C# (ASP.NET MVC)
* **Database:** SQL Server
* **Data Access:** ADO.NET
* **Architecture:** MVC Pattern
* **Authentication:** Session-based

---

## 🧠 Key Concepts Used

* MVC Architecture
* ADO.NET (Connected & Disconnected)
* Stored Procedures
* Session Management
* Model Validation
* jQuery (Search functionality)

---

## 🗂️ Project Structure

```
FeedManagementSystem/
│
├── Controllers/
│   ├── HomeController.cs
│   ├── AdminController.cs
│   ├── CustomerController.cs
│   ├── FeedController.cs
│   └── SellerController.cs
│
├── Models/
│   ├── Entities (Admin, Customer, Feed, Seller)
│   ├── DAL Classes
│
├── Views/
│   ├── Home
│   ├── Admin
│   ├── Customer
│   ├── Feed
│   ├── Seller
│   └── Shared
│
└── Web.config
```

---

## ⚙️ Setup Instructions

### Prerequisites

* Visual Studio
* SQL Server
* .NET Framework

### Steps

1. Clone the repository:

```
git clone https://github.com/your-username/FeedManagementSystem.git
```

2. Open the solution in Visual Studio

3. Configure database connection in `Web.config`:

```
<connectionStrings>
  <add name="dbcs" connectionString="your_connection_string_here"/>
</connectionStrings>
```

4. Create required stored procedures:

* `sp_AdminLogin`
* `sp_InsertCustomer`
* `sp_GetCustomers`
* `sp_DeleteCustomer`
* `sp_InsertFeed`
* `sp_GetFeeds`
* `sp_UpdateFeed`
* `sp_DeleteFeed`
* `sp_InsertSeller`
* `sp_GetSellers`
* `sp_DeleteSeller`

5. Run the application

---

## 🔄 Workflow

1. Admin logs into the system
2. Admin manages feeds and sellers
3. Customers place feed orders
4. Admin monitors and manages all orders

---

## 🔒 Security

* Session-based authentication
* Restricted access to admin modules
* Server-side validation

---

## 🔮 Future Enhancements

* Edit customer orders
* Reports & analytics
* Export to Excel/PDF
* Role-based authentication
* UI improvements

---

## 👨‍💻 Author

**Yaswanth Guddati**

---

## ⭐ Note

This project is developed for learning and demonstration purposes.
