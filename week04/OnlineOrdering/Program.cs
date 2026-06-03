using System;

class Program
{
    static void Main(string[] args)
    {
        // ===== FIRST ORDER =====

        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "NY",
            "USA");

        Customer customer1 = new Customer(
            "John Smith",
            address1);

        Product product1 = new Product(
            "Laptop",
            "P101",
            800,
            1);

        Product product2 = new Product(
            "Mouse",
            "P102",
            25,
            2);

        Product product3 = new Product(
            "Keyboard",
            "P103",
            50,
            1);

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // ===== SECOND ORDER =====

        Address address2 = new Address(
            "45 King Street",
            "Toronto",
            "Ontario",
            "Canada");

        Customer customer2 = new Customer(
            "Sarah Johnson",
            address2);

        Product product4 = new Product(
            "Phone",
            "P201",
            600,
            1);

        Product product5 = new Product(
            "Headphones",
            "P202",
            75,
            2);

        Product product6 = new Product(
            "Charger",
            "P203",
            30,
            1);

        Order order2 = new Order(customer2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);

        // ===== DISPLAY ORDER 1 =====

        Console.WriteLine("ORDER 1");
        Console.WriteLine("---------------------");

        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"TOTAL COST: ${order1.CalculateTotalCost()}");

        Console.WriteLine();

        // ===== DISPLAY ORDER 2 =====

        Console.WriteLine("ORDER 2");
        Console.WriteLine("---------------------");

        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"TOTAL COST: ${order2.CalculateTotalCost()}");
    }
}