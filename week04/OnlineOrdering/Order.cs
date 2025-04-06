using System;
using System.Text;

public class Order{
    
    private List<Product> _products = new List<Product>();
    private Customer _customer = new Customer();

    public Order(List<Product> products, Customer customer){
        _products = products;
        _customer = customer;
    }

    public Customer GetCustomer(){
        return _customer;
    }


    public double CalculateTotalCost(double shippingCost){
        double totalCost = 0.0;
        foreach(Product product in _products){
            totalCost += product.GetTotalCost();
        }
        totalCost += shippingCost;
        return totalCost;
    }

    public string PrintPackingLabel(){
        StringBuilder packingLabelBuilder = new StringBuilder();
        packingLabelBuilder.Append("S/N").Append('\t').Append("Product ID").Append('\t').Append("Product Name").Append('\n');
        foreach(Product product in _products){
            packingLabelBuilder.Append(_products.IndexOf(product) + 1).Append('\t');
            packingLabelBuilder.Append($"{product.GetProductId()}").Append("\t\t");
            packingLabelBuilder.Append($"{product.GetName()}");
            packingLabelBuilder.Append('\n');
        }
        return packingLabelBuilder.ToString();
    }

public string PrintShippingLabel(){
    StringBuilder shippingLabelBuilder = new StringBuilder();
            shippingLabelBuilder.Append($"Name: {_customer.GetName()} \n");
            shippingLabelBuilder.Append($"Address: {_customer.GetAddress().GetAddress()}");
            shippingLabelBuilder.Append('\n');
        
        return shippingLabelBuilder.ToString();
    }
}
