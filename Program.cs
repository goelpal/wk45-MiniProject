//Weekly Mini Project - wk45
//Enter project information from the user
//Ability to add it using class
//Display the sorted information
//Messages come in green color while errors are coded in Red



List<Product> items = new List<Product>();

showMainMenu();

//Function to add Products to the list
void AddProduct()
{ 

while (true)
{
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("To enter a new Product - follow the steps | To Quit Enter : 'Q'");
        Console.ResetColor();

        //Product Category
        Console.Write("Enter the Product Category : ");
        string ProdCategory = Console.ReadLine();
        if (string.IsNullOrEmpty(ProdCategory))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry.");
            Console.ResetColor();
        }
        else if (ProdCategory.ToLower().Trim() == "q")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exiting the Add Products application.");
            Console.ResetColor();
            break;
        }

        //Product Name
        Console.Write("Enter the Product Name : ");
        string ProdName = Console.ReadLine();
        if (string.IsNullOrEmpty(ProdName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry.");
            Console.ResetColor();
        }
        else if (ProdName.ToLower().Trim() == "q")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exiting the Add Products application.");
            Console.ResetColor();
            break;
        }


        //Product Price
        Console.Write("Enter the Product Price : ");
        string ProdPrice = Console.ReadLine();

        if (string.IsNullOrEmpty(ProdPrice))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry.");
            Console.ResetColor();
        }
        else if (ProdPrice.ToLower().Trim() == "q")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exiting the Add Products application");
            Console.ResetColor();
            break;
        }
        else
        {
            bool isValid = int.TryParse(ProdPrice, out int price);//Check to find Price is integer and not having any irrelevant input
            if (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is an invalid entry.");
                Console.ResetColor();
            }
            else
            {
                if (string.IsNullOrEmpty(ProdCategory) || string.IsNullOrEmpty(ProdName))
                {
                    Console.WriteLine("There is an invalid entry. Please try again.");
                }
                else
                {
                    Product product = new Product(ProdCategory, ProdName, price);
                    items.Add(product);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The Product was successfully added to list.");
                    Console.ResetColor();
                }
            }
        }
    }
    showMainMenu();
}

//To list the Products on Console
void ListProducts()
{
    if (items.Count > 0)
    {
        //Sorted List By Price
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Products List (Sorted by Price Ascending");
        List<Product> SortedProduct = items.OrderBy(Product => Product.Price).ToList();
        Console.WriteLine("Category".PadRight(20) + "Name".PadRight(20) + "Price");
        foreach (Product itemProduct in SortedProduct)
        {
            Console.WriteLine(itemProduct.Category.PadRight(20) + itemProduct.Name.PadRight(20) + itemProduct.Price);
        }
        Console.WriteLine("Total Amount :".PadLeft(40) + items.Sum(items => items.Price));
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No Products to display. Please add Products to the list.");
        Console.ResetColor();
    }

    showMainMenu();
}

//Function to search a product from list and highlighting the same in Magenta color when showing the list
void SearchProduct()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Enter the Product Name to search in the List: ");
    Console.ResetColor();       
    string InputName = Console.ReadLine().ToLower().Trim();
    if (string.IsNullOrEmpty(InputName))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid Entry.");
        Console.ResetColor();
    }
    else
    {
        if (items.Count > 0)
        {
            List<Product> FilteredProduct = items.OrderBy(Product => Product.Price).ToList();
            Console.WriteLine("Category".PadRight(20) + "Name".PadRight(20) + "Price");
            foreach (Product itemProduct in FilteredProduct)
            {
                if (itemProduct.Name.ToLower().Trim().Equals(InputName))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(itemProduct.Category.PadRight(20) + itemProduct.Name.PadRight(20) + itemProduct.Price);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(itemProduct.Category.PadRight(20) + itemProduct.Name.PadRight(20) + itemProduct.Price);
                }
            }
            Console.WriteLine("Total Amount :".PadLeft(40) + items.Sum(items => items.Price));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Products to display. Please add Products to the list.");
            Console.ResetColor();
        }
    }
    showMainMenu();
}


//Function to show the available options to the user
void showMainMenu()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Welcome to the Products application! Please select the relevant option.");
    Console.WriteLine("1-Add a Product");
    Console.WriteLine("2-Search a Product");
    Console.WriteLine("3-List the Products");
    Console.WriteLine("0-Quit");

    Console.Write("Enter your choice : ");
    Console.ResetColor();

    string userInput = Console.ReadLine();
    switch (userInput)
    {
        case "1":
            AddProduct();//Add the product to the list
            break;
        case "2":
            SearchProduct();//Search a product in the list
            break;
        case "3":
            ListProducts();//List all the products in the list
            break;
        case "0":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for using this application!");//Quit the application
            Console.ResetColor();
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Selection. Please try again.");//Invalid input from the user
            Console.ResetColor();
            showMainMenu();
            break;
    }
}


//The main class 'Product' having all the attributes as Product category, name and price
class Product
{
    public Product(string category, string name, int price)
    {
        Category = category;
        Name = name;
        Price = price;
    }

    public string Category { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}
