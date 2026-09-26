using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "OR", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "P101", 25.50m, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "P102", 75.00m, 1));


        Address address2 = new Address("456 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Sarah Smith", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("USB-C Cable", "P201", 12.00m, 3));
        order2.AddProduct(new Product("HD Monitor", "P202", 150.00m, 1));
        order2.AddProduct(new Product("Webcam", "P203", 45.00m, 1));



        Console.WriteLine("==================================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotalCost():F2}");

        Console.WriteLine("\n==================================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine("==================================================");
    }
}