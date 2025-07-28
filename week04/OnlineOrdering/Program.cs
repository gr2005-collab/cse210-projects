using System;

class Program
{
    static void Main(string[] args)
    {
        // USA Order
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Alice Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B001", 12.99, 2));
        order1.AddProduct(new Product("Pen", "P101", 1.50, 5));

        // International Order
        Address address2 = new Address("45 King St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Johnson", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N999", 8.75, 3));
        order2.AddProduct(new Product("Backpack", "BP42", 29.99, 1));

        // Display Order 1
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Order 1 Total Cost: ${order1.GetTotalCost():0.00}\n");

        // Display Order 2
        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Order 2 Total Cost: ${order2.GetTotalCost():0.00}");
    }
}
