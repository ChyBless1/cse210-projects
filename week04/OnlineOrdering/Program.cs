using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street", "Rexburg", "Idaho", "USA");
        Customer customer1 = new Customer("Maria Johnson", address1);

        Product product1 = new Product("Notebook", "NB101", 3.50m, 2);
        Product product2 = new Product("Pen Set", "PS202", 5.00m, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);


        Address address2 = new Address(
            "45 Rua da Missão", "Luanda", "Luanda", "Angola");
        Customer customer2 = new Customer("Blessing Muokwe", address2);

        Product product3 = new Product("Water Bottle", "WB303", 12.00m, 1);
        Product product4 = new Product("Lunch Box", "LB404", 8.50m, 2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);


        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine("ORDER");
            Console.WriteLine($"Total cost: ${order.GetTotalCost():F2}");

            Console.WriteLine("Packing label:");
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine("Shipping label:");
            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine("--------------------");
        }
    }
}