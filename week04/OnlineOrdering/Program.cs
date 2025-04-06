using System;

class Program
{
    static void Main(string[] args)
    {
        double usaResidentShippingCost = 5;
        double nonUSAResidentShippingCost = 35;

        Product product1 = new Product("Office Table", "OT-10B", 75, 6);
        Product product2 = new Product("Lenovo X1 Carbon Laptop", "LV-12G", 560, 10);
        Product product3 = new Product("Violin", "VL-SDV", 95, 8);
        Product product4 = new Product("Tesla", "TS-v8", 1050, 12);
        Product product5 = new Product("IPhone 28", "IP-28", 250, 15);

        List<Product> products1  = new List<Product>{product1, product2, product3};
        List<Product> products2 = new List<Product>{product4, product5};

        Address address1 = new Address("No.13 William Park", "New York", "Ohio", "USA");
        Address address2 = new Address("No.52 Wellington Bassey Road", "Uyo", "Akwa-Ibom", "NIGERIA");

        Customer customer1 = new Customer("Les Brown", address1);
        Customer customer2 = new Customer("Samuel Timothy", address2);

        Order order1 = new Order(products1, customer1);
        Order order2 = new Order(products2, customer2);

        List<Order> orderList = new List<Order>{order1, order2};

        foreach(Order order in orderList){
            Console.WriteLine($"==================== Order {orderList.IndexOf(order) + 1} ====================");
            Console.WriteLine("----------------- PARKING LABEL -----------------");
            Console.WriteLine(order.PrintPackingLabel());
            Console.WriteLine("----------------- SHIPPING LABEL ----------------");
            Console.WriteLine(order.PrintShippingLabel());
            Console.WriteLine("------------------ TOTAL COST ------------------");
            if(order.GetCustomer().IsUSAResident()){
                Console.WriteLine($"${order.CalculateTotalCost(usaResidentShippingCost)}");
            }
            else{
                Console.WriteLine($"${order.CalculateTotalCost(nonUSAResidentShippingCost)}");
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("\n\n");
        }

    }
}