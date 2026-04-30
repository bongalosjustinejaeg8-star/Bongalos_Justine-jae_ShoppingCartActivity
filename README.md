````md
## Console Shopping System

## Overview

**Shoppee Typeshi** is a console-based shopping system built in **C#** that simulates a basic e-commerce experience inside the terminal. Users can browse available products, search items, filter by category, manage a shopping cart, checkout purchases, and review previous transactions.

This project demonstrates important programming concepts such as **Object-Oriented Programming (OOP)**, arrays, collections, loops, conditionals, method organization, and input validation.

---

## Features

* View all available products
* Search products by name
* Filter products by category
* Add items to cart with quantity selection
* Update cart quantity
* Remove specific cart items
* Clear entire cart
* Real-time cart subtotal and total display
* Stock validation (prevents over-purchasing)
* Maximum cart quantity limit
* Automatic total calculation
* 10% discount for purchases ≥ 5000
* Checkout system with payment and change calculation
* Receipt generation
* Low stock warning system
* Order history tracking
* Basic input validation

---

## Code Structure

### `Program` Class

* Entry point of the application
* Displays the main menu:

  * Start Shopping
  * View Products
  * Search Products
  * Filter by Category
  * View Order History
  * Exit

* Handles navigation using loop and switch-case logic

---

### `Product` Class

Represents a product in the store.

**Attributes:**

* `ID` – Unique identifier
* `Name` – Product name
* `Price` – Product price
* `Stock` – Available quantity
* `Category` – Product classification

Used for:

* Store inventory
* Cart items

---

### `OrderRecord` Class

Stores completed purchase information.

**Fields:**

* `ReceiptNo`
* `FinalTotal`
* `DateTime`

Used for viewing transaction history.

---

### `Shop` Class

Handles the main shopping system logic.

Includes:

* Product inventory
* Cart management
* Checkout system
* Search/filter functions
* Order history system

---

## Core Functionalities

### Product Viewing (`DisplayProducts`)

Displays all available products with:

* Name
* Price
* Stock
* Category

---

### Search Products (`SearchProduct`)

Allows users to search products by keyword.

Example:

```text
mouse
````

Returns matching products such as:

```text
Wireless Mouse
```

---

### Filter by Category (`FilterByCategory`)

Displays products under selected categories such as:

* Gadget
* Keyboard
* Mouse
* Monitor
* Accessories

---

### Shopping Flow (`Cart`)

Users may enter:

* Product number → Add item
* `V` → View Cart
* `X` → Exit Shopping

Uses validation and exception handling for invalid input.

---

### Confirmation System

#### `Confirmation()`

Asks user to confirm selected product.

#### `Confirmation2()`

Requests quantity.

* Defaults to **1** if left blank
* Validates stock before adding

---

### Add to Cart (`AddToCart`)

Checks:

* Available stock
* Cart quantity limit
* Existing duplicate items

Updates:

* Cart contents
* Product stock
* Total cost

---

### Cart Management Menu

Inside cart, users can:

1. Remove an item
2. Update quantity
3. Clear cart
4. Checkout
5. Continue Shopping

---

### Cart Display (`ShowCartDisplay`)

Shows:

* Product name
* Quantity
* Item subtotal
* Overall total

---

### Checkout System

Triggered through cart menu.

---

#### Discounted Checkout (`Discounted`)

Applied when total purchase is **5000 or higher**

* 10% discount
* Payment validation
* Receipt generation
* Order history save

---

#### Normal Checkout (`NormalCheckout`)

Used when total is below **5000**

* Standard payment process
* Calculates change
* Saves order history

---

### Receipt System (`PrintReceipt`)

Displays:

* Receipt Number
* Purchase Date & Time
* Purchased Items
* Grand Total
* Discount (if applied)
* Final Total
* Payment
* Change

---

### Low Stock Alert (`LowStockAlert`)

After checkout, warns when remaining stock is **5 or below**.

Example:

```text
Laptop has only 3 stock(s) left.
```

---

### Order History (`ViewOrderHistory`)

Displays all successful transactions:

* Receipt Number
* Final Total
* Date & Time

---

## Program Flow

1. Program starts
2. Main menu is displayed
3. User selects an option
4. Shopping/cart operations occur
5. Checkout processes payment
6. Receipt is shown
7. Order saved to history
8. Cart resets for next transaction

---

## How to Run

1. Open terminal inside project folder
2. Run:

```bash
dotnet run
```

---

## Concepts Used

* Object-Oriented Programming (OOP)
* Arrays
* Lists (`List<T>`)
* HashSet
* Loops (`while`, `foreach`)
* Conditional Statements (`if`, `switch`)
* Exception Handling (`try-catch`)
* Input Validation
* Method Decomposition

---

## Notes / Limitations

* Products are hardcoded
* Data resets when program closes
* No database integration
* Console UI only
* Cart uses fixed-size array
* Could be improved using `List<Product>`

---

## AI Usage Declaration

This project was developed with assistance from **OpenAI ChatGPT**.

AI was used for:

* Improving structure and readability
* Generating project documentation (README)

All final decisions, edits, testing, and implementation were done by the developer.

**AI Tool Used:** ChatGPT
**Conversation Used:** This conversation session
**Link:** https://chatgpt.com/share/69f363cb-b770-8323-83c8-dc836f505f80

```
```
