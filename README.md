## Console Shopping System

## Overview

**Shoppee Typeshi** is a simple console-based shopping system built in C#. It allows users to browse products, add items to a cart, and complete a checkout process with optional discounts.

This project demonstrates core programming concepts such as object-oriented programming (OOP), list manipulation, loops, and input validation.



## Features

* View available products
* Add items to cart with quantity selection
* Real-time cart display with subtotal and total
* Stock validation (prevents over-purchasing)
* Automatic total calculation
* 10% discount for purchases ≥ 5000
* Checkout system with payment and change calculation
* Basic input validation

---

##  Code Structure

###  `Program` Class

* Entry point of the application
* Displays the main menu:

  * Start Shopping
  * View Products
  * Exit
* Handles user navigation using a loop and switch-case logic

---

###  `Product` Class

Represents a product in the system.

**Attributes:**

* `ID` – Unique identifier
* `Name` – Product name
* `Price` – Price per item
* `Stock` – Available quantity

👉 This class is used for both:

* Store inventory
* Cart items (with modified price & quantity)

---

### 🔹 `Shop` Class

Handles the main shopping logic and system behavior.

#### 📦 Product List

* Stored in `List<Product>`
* Predefined (hardcoded) products for simplicity

#### 🛒 Cart System

* `CartContent` stores selected items
* Tracks:

  * Total cost (`Overall`)
  * Discounted total (`Discount`)
  * Cart item count (`CartLimit`)
  * Maximum allowed items (`MaxCartLimit`)

---

## 🔄 Core Functionalities

### 🛍️ Shopping Flow (`Cart`)

* Displays products
* Accepts user input:

  * Product number → proceed to confirmation
  * `X` → exit shopping
  * `C` → checkout
* Uses exception handling to manage invalid inputs

---

### ✅ Confirmation System

* `Confirmation()` → asks user to confirm item selection
* `Confirmation2()` → asks for quantity

  * Defaults to **1** if input is empty
  * Validates stock before adding

---

### ➕ Add to Cart (`AddToCart`)

* Checks:

  * Stock availability
  * Cart limit
* Updates:

  * Cart content
  * Product stock
  * Total cost
* Merges duplicate items in cart

---

### 🧾 Cart Display (`ShowCart`)

* Shows:

  * Item name
  * Quantity
  * Subtotal
  * Overall total
* Automatically returns user to shopping loop

---

### 💳 Checkout System

Triggered when user enters `C`

#### 💸 Discounted Checkout (`Discounted`)

* Applied when total ≥ 5000
* 10% discount
* Validates payment before completing purchase

#### 💵 Normal Checkout (`NormalCheckout`)

* Standard payment process
* Calculates change
* Resets cart after successful transaction

---

## 🔄 Program Flow

1. Program starts
2. Menu is displayed
3. User selects an option:

   * Start Shopping → enters cart system
   * View Products → displays inventory
   * Exit → ends program
4. User adds items to cart
5. User proceeds to checkout
6. Payment is processed
7. System resets for next transaction

---

## 🚀 How to Run

1. Open terminal in project folder
2. Run the program:

```bash
dotnet run
```

---

## 📚 Concepts Used

* Object-Oriented Programming (OOP)
* Lists (`List<T>`)
* Loops (`while`)
* Conditional Statements (`if`, `switch`)
* Exception Handling (`try-catch`)
* Basic Input Validation

---

## ⚠️ Notes / Limitations

* Products are hardcoded (no database)
* Input handling is basic (can be improved)
* Cart logic may duplicate loops (optimization possible)
* UI is console-based only


