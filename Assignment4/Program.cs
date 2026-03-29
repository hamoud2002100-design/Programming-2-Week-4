
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment4; 

public class Program
{
    static void Main(string[] args)
    {
        new Program().Start();
    }

    public void Start()
    {
        
        List<Product> products = new List<Product>()
        {
            new Product("Coffee mug", 1.49, Category.Kitchenware),
            new Product("Pencil", 0.59, Category.Stationary),
            new Product("Pen", 0.99, Category.Stationary)
        };

        Console.WriteLine("All products (not filtered, not sorted):");
        PrintProducts(products);

        SortByPrice(products);
        Console.WriteLine("\nSorted products (by price):");
        PrintProducts(products);

        List<Product> filtered = FilterByCategory(products, Category.Stationary);
        Console.WriteLine("\nFiltered products (Category: Stationary):");
        PrintProducts(filtered);
    }
    public void PrintProducts(List<Product> products)
    {
        int counter = 1;
        foreach (var p in products)
        {
            Console.WriteLine($"{counter}. Product: {p.Name}, Price: {p.Price}, Category: {p.Category}");
            counter++;
        }
    }
    public void SortByPrice(List<Product> products)
    {
        products.Sort((a, b) => b.Price.CompareTo(a.Price));
    }
    public List<Product> FilterByCategory(List<Product> products, Category category)
    {
        return products.Where(p => p.Category == category).ToList();
    }
}
