using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

class Program
{
    static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
        new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
        new Product { Id = 3, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
        new Product { Id = 4, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
        new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
        new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
        new Product { Id = 7, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
        new Product { Id = 8, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 }
    };

    static List<Product> SearchProducts(
        List<Product> products,
        Func<Product, bool> filter)
    {
        return products.Where(filter).ToList();
    }

    static void Display(string title, List<Product> list)
    {
        Console.WriteLine($"\n--- {title} ---");

        foreach (Product p in list)
        {
            Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
        }
    }

    static void Main()
    {
        var electronics = SearchProducts(products, p => p.Category == "Electronics");
        var under50 = SearchProducts(products, p => p.Price < 50);
        var inStock = SearchProducts(products, p => p.Stock > 0);
        var clothingUnder100 = SearchProducts(products, p => p.Category == "Clothing" && p.Price < 100);

        Display("Electronics", electronics);
        Display("Under $50", under50);
        Display("In Stock", inStock);
        Display("Clothing Under $100", clothingUnder100);
    }
}