using System.Data;

class Program
{
    static List<string> cartItems = new List<string>();

    static Dictionary<string, double> itemPrices = new Dictionary<string, double>()
    {
        {"laptop", 999.99 },
        {"mouse", 2940},
        {"keyboard", 4800 },
        {"monitor", 7000 },
        {"headphones", 899.99 }
    };

    static Stack<string> undoActions = new Stack<string>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("==============================");
            Console.WriteLine("welcome to the shopping cart!");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. View Cart Items");
            Console.WriteLine("3. Remove Item From Cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Undo Last Action");
            Console.WriteLine("6. Exit");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter The Number Of Your Choice:");
            Console.WriteLine("------------------------------");
            int Choice = int.Parse(Console.ReadLine());

            switch (Choice)
            {

                case 1:
                    AddItem();
                    Console.WriteLine("------------------------------");

                    break;
                case 2:
                    ViewCartItems();
                    Console.WriteLine("------------------------------");

                    break;
                case 3:
                    RemoveItem();
                    Console.WriteLine("------------------------------");

                    break;
                case 4:
                    CheckOut();
                    Console.WriteLine("------------------------------");

                    break;
                case 5:
                    UndoAction();
                    Console.WriteLine("------------------------------");

                    break;
                case 6:
                    Environment.Exit(0);
                    Console.WriteLine("------------------------------");

                    break;
                default:
                    Console.WriteLine("Invalid Choice. Please Try Again.");
                    break;

            }
        }

    }
    static void AddItem()
    {
        Console.WriteLine("Available Items:");
        foreach (var item in itemPrices)
        {
            Console.WriteLine($"Item:{item.Key}, Price:{item.Value}");
        }
        Console.WriteLine("------------------------------");
        Console.WriteLine("Enter the name of the item you want to add:");
        string itemName = Console.ReadLine().ToLower();
        if (itemPrices.ContainsKey(itemName))
        {
            Console.WriteLine("------------------------------");
            cartItems.Add(itemName);
            undoActions.Push($"Item {itemName} added to the Cart");
            Console.WriteLine("Item added to cart.");

        }
        else
        {
            Console.WriteLine("Item out of stock or not found.");
        }
    }


    static void ViewCartItems()
    {
        var itemPriceCollection = GetCartPrice();
        Console.WriteLine("Your Cart Items :");
        if (cartItems.Any())
        {
            foreach (var item in itemPriceCollection)
            {
                Console.WriteLine($"Item :{item.ItemName}, Price: {item.Price}");
            }
        }
        else
            Console.WriteLine("Cart Is empty.");
    }



    static IEnumerable<(string ItemName, double Price)> GetCartPrice()
    {
        var cartPrice = new List<(string ItemName, double Price)>();
        foreach (var item in cartItems)
        {
            double price = 0;
            bool foundItem = itemPrices.TryGetValue(item, out price);
            if (foundItem)
            {
                var itemPrice = (item, price);
                cartPrice.Add(itemPrice);
            }
        }
        return cartPrice;
    }

    static void RemoveItem()
    {
        ViewCartItems();
        if (cartItems.Any())
        {
            Console.WriteLine("Select Item To Remove : ");
            string itemremove = Console.ReadLine();
            if (cartItems.Contains(itemremove))
            {
                cartItems.Remove(itemremove);
                Console.WriteLine($"Item :{itemremove} Is Removed");
                undoActions.Push($"Item {itemremove} removed from the cart");

            }
            else
                Console.WriteLine("Item Dosn't Exist In Choping Cart ");

        }
    }



    static void CheckOut()
    {
        if (cartItems.Any())
        {
            double totalPrice = 0;
            var itemsInCart = GetCartPrice();
            foreach (var item in itemsInCart)
            {
                totalPrice += item.Price;
                Console.WriteLine($"Item :{item.ItemName}, Price : {item.Price}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Total Price : {totalPrice}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Please Proceed To Payment , Thank You For Shoping With Us❤️ ❤️❤️ ");
            cartItems.Clear();
            undoActions.Push("CheckOut");
        }
        else
            Console.WriteLine("The Shoping Cart Is Empty");
    }




    static void UndoAction()
    {
        if (undoActions.Any())
        {
            var lastAction = undoActions.Pop();
            Console.WriteLine($"Last Action Is :{lastAction}");

            var actionArray = lastAction.Split();

            if (lastAction.Contains("added"))
            {
                cartItems.Remove(actionArray[1]);

            }
            else if (lastAction.Contains("removed"))
            {
                cartItems.Add(actionArray[1]);

            }
            else
                Console.WriteLine("Ckeck Out Cannot Be Undo , Pleas Ask For Refund");
            
    }

}


}