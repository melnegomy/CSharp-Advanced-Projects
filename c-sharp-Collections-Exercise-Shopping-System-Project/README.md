# 🛒 Shopping Cart Management System

A console-based C# application that simulates a simple shopping cart system using advanced collection classes such as **List**, **Dictionary**, and **Stack**.

## 🚀 Features

* Add items to the shopping cart.
* View all items currently in the cart.
* Remove items from the cart.
* Calculate the total price during checkout.
* Undo the last add or remove action.
* Display available products with their prices.

## 📚 Concepts Demonstrated

### 📦 Collections

* **List<T>**

  * Store cart items.

* **Dictionary<TKey, TValue>**

  * Store products and their prices.

* **Stack<T>**

  * Implement Undo functionality.

### 🔍 Data Lookup

* Fast product search using `Dictionary.TryGetValue()`.

### 🏗️ Tuples

* Return item names and prices as named tuples:

```csharp
(string ItemName, double Price)
```

### 🔄 Iteration

* Traverse collections using `foreach`.

### 🎯 LINQ

* Check collection contents using:

```csharp
cartItems.Any()
```

## 🛠️ Technologies

* C#
* .NET
* Visual Studio

## 📂 Project Structure

```text
Program.cs
│
├── AddItem()
├── ViewCartItems()
├── GetCartPrice()
├── RemoveItem()
├── CheckOut()
└── UndoAction()
```

## 📋 Menu Options

1. Add Item
2. View Cart Items
3. Remove Item From Cart
4. Checkout
5. Undo Last Action
6. Exit

## 🎓 Learning Outcomes

By building this project, you will gain practical experience with:

* Collection Framework
* Dictionary Operations
* Stack-Based Undo Systems
* Tuple Usage
* LINQ Methods
* Console Application Development
* Object-Oriented Programming Fundamentals

## 👨‍💻 Author

Mohamed Elnegomy

---

⭐ Feel free to fork this repository, explore the code, and enhance the project with additional features such as quantity management, discounts, user accounts, and persistent storage.
