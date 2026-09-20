# POS System — Project Flow & UML

## 1. Project Overview

A **Windows Forms (C# / .NET 8)** Point-Of-Sale (POS) application for managing products, categories, and customer orders against an **SQL Server** database.

- **UI Framework:** Windows Forms with the **Guna.UI2** control suite (custom-styled panels, buttons, text boxes, data grids).
- **Data Access:** `Microsoft.Data.SqlClient` with a thin helper class (`Db`) that wraps `DataTable` queries and non-query commands.
- **Database:** `POS_system` on SQL Server (`DESKTOP-RCP3HG7`, Windows Authentication).
- **Language / Runtime:** C# 12 / .NET 8.0 (`net8.0-windows`).

---

## 2. Project Structure

```
C#_POS_System/
├── Program.cs                  // Entry point, starts MainForm
├── DbConnection/
│   └── Db.cs                   // Connection string + ExecuteQuery / ExecuteNonQuery helpers
├── Models/
│   ├── Category.cs             // Id, Name, Description
│   ├── Product.cs              // Id, Name, Price, CategoryID, CategoryName, Image, IsActive
│   ├── Order.cs                // Id, Date, Total, Items[]
│   └── OrderItem.cs            // ProductId, ProductName, UnitPrice, Qty, Total (computed)
├── Services/
│   ├── ProductService.cs       // Add / Update / Delete(soft) / Restore / query products
│   └── OrderService.cs         // AddOrder, GetAllOrders, GetOrderItems
└── Forms/
    ├── MainForm.cs             // Selling screen: product grid + cart + checkout
    ├── ShowProducts.cs         // Product management: search, filter, edit, deactivate/restore
    ├── ShowOrders.cs           // Order history: grid with line items, search + filter
    ├── FormCreate.cs           // Add / edit product dialog (name, price, category, image)
    └── *.Designer.cs           // UI layout (auto-generated)
```

---

## 3. Database Schema

| Table | Columns |
|-------|---------|
| `Categories` | `Id` (PK), `Name`, `Description` |
| `Products` | `Id` (PK), `Name`, `Price`, `CategoryID` (FK → Categories.Id), `Image`, `IsActive` (bit) |
| `Orders` | `Id` (PK), `Date`, `Total` |
| `OrderItems` | `OrderID` (FK → Orders.Id), `ProductID`, `ProductName`, `UnitPrice`, `Qty`, `Total` |

### ER Diagram

```mermaid
erDiagram
    CATEGORIES ||--o{ PRODUCTS : contains
    PRODUCTS ||--o{ ORDERITEMS : "sold in"
    ORDERS ||--o{ ORDERITEMS : contains

    CATEGORIES {
        int Id PK
        string Name
        string Description
    }
    PRODUCTS {
        int Id PK
        string Name
        decimal Price
        int CategoryID FK
        string Image
        bit IsActive
    }
    ORDERS {
        int Id PK
        datetime Date
        decimal Total
    }
    ORDERITEMS {
        int OrderID FK
        int ProductID
        string ProductName
        decimal UnitPrice
        int Qty
        decimal Total
    }
```

---

## 4. System Flow

### 4.1 High-Level Flowchart

```mermaid
flowchart TD
    A[Start app: Program.Main] --> B[MainForm loads]
    B --> C[Load active products]
    C --> D{Seller clicks a product?}
    D -->|Yes| E[Add to cart]
    D -->|No| F
    E --> F[Seller adjusts qty / removes items]
    F --> G{Click Place Order?}
    G -->|Yes| H[OrderService.AddOrder]
    H --> I[Insert Orders + OrderItems]
    I --> J[Clear cart, show success]
    G -->|No| B

    B --> K[Manage Products: ShowProducts]
    K --> K1[Search / filter by category]
    K1 --> K2{Edit or Deactivate?}
    K2 -->|Edit| K3[FormCreate -> ProductService.UpdateProduct]
    K2 -->|Deactivate| K4[ProductService.DeleteProduct sets IsActive=0]
    K4 --> K1

    B --> L[View Orders: ShowOrders]
    L --> L1[Load orders + line items]
    L1 --> L2[Search by Order ID / Date / Product]
```

### 4.2 Typical Ordering Flow

```mermaid
sequenceDiagram
    participant S as Seller (MainForm)
    participant P as ProductService
    participant O as OrderService
    participant DB as SQL Server

    S->>S: Click product card
    S->>S: Add OrderItem to cart (or increment Qty)
    S->>S: Click "Place Order"
    S->>O: AddOrder(order)
    O->>DB: INSERT INTO Orders + SCOPE_IDENTITY()
    O->>DB: INSERT OrderItems for each item
    DB-->>O: OrderId
    O-->>S: OrderId
    S->>S: Clear cart, show "Order #N placed"
```

### 4.3 Product Management Flow

```mermaid
sequenceDiagram
    participant M as Admin (ShowProducts)
    participant F as FormCreate
    participant P as ProductService
    participant DB as SQL Server

    M->>M: Search / select category
    M->>F: Open FormCreate (add or edit)
    F->>P: AddProduct / UpdateProduct
    P->>DB: INSERT / UPDATE Products
    DB-->>P: OK
    P-->>F: rows affected
    F-->>M: ProductAdded = true, refresh grid

    M->>P: DeleteProduct(id)  // soft delete
    P->>DB: UPDATE Products SET IsActive = 0
    M->>P: RestoreProduct(id)
    P->>DB: UPDATE Products SET IsActive = 1
```

---

## 5. Use Case Diagram

```mermaid
flowchart LR
    Seller((Seller)) --> UC1[Browse / search products]
    Seller --> UC2[Add items to cart]
    Seller --> UC3[Adjust quantity]
    Seller --> UC4[Place order]
    Seller --> UC5[View order history]
    Admin((Admin)) --> UC6[Add product]
    Admin --> UC7[Edit product]
    Admin --> UC8[Deactivate / restore product]
    Seller --> UC9[Search orders]
```

---

## 6. Class Diagram

```mermaid
classDiagram
    class Db {
        +string ConnectionString
        +SqlConnection GetConnection()
        +DataTable ExecuteQuery(string, SqlParameter[])
        +int ExecuteNonQuery(string, SqlParameter[])
    }

    class Product {
        +int Id
        +string Name
        +decimal Price
        +int CategoryID
        +string CategoryName
        +string Imaage
        +bool IsActive
    }

    class Category {
        +int Id
        +string Name
        +string Description
    }

    class Order {
        +int Id
        +DateTime Date
        +List~OrderItem~ Items
        +decimal Total
    }

    class OrderItem {
        +int ProductId
        +string ProductName
        +decimal UnitPrice
        +int Qty
        +decimal Total
    }

    class ProductService {
        +int AddProduct(Product)
        +int UpdateProduct(Product)
        +int DeleteProduct(int)
        +int RestoreProduct(int)
        +List~Product~ GetAllProducts()
        +List~Product~ GetAllActiveProducts()
        +List~Product~ SearchProducts(string)
        +List~Product~ GetProductsByCategory(int)
    }

    class OrderService {
        +int AddOrder(Order)
        +List~Order~ GetAllOrders()
        +List~OrderItem~ GetOrderItems(int)
    }

    class MainForm
    class ShowProducts
    class ShowOrders
    class FormCreate

    Db <-- ProductService
    Db <-- OrderService
    ProductService <-- ShowProducts
    ProductService <-- FormCreate
    ProductService <-- MainForm
    OrderService <-- MainForm
    OrderService <-- ShowOrders
    FormCreate --> Product
    Order --> OrderItem
    Product --> Category
    MainForm --> ShowProducts
    MainForm --> ShowOrders
    MainForm --> FormCreate
```

---

## 7. Feature Notes

1. **Soft delete (IsActive):** Deleting a product sets `IsActive = 0` instead of removing the row, so `OrderItems` history is preserved and no foreign-key errors occur. Inactive products are hidden from the selling screen and shown greyed-out in the management screen with a **Restore** option.
2. **Search / filter:**
   - Products: by name (text) and by category (combo).
   - Orders: by `Order ID`, `Date`, or `Product Name` (combo selects the field).
3. **Order totals** are computed as `UnitPrice * Qty` per line, summed in the cart, and stored on the `Orders.Total` column at checkout.