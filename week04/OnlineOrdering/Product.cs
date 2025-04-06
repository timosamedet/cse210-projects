using System;

public class Product{
    private string _name;
    private string  _productId;
    private double _price;
    private int _quantity;
    private double _totalCost;


    public Product(string _name, string _productId, double _price, int _quantity){
        this._name = _name;
        this._productId = _productId;
        this._price = _price;
        this._quantity = _quantity;
        this._totalCost = GetTotalCost();
    }

    public double GetTotalCost(){
        return _price * _quantity;
    }

    public string GetProductId(){
        return _productId;
    }

    public string GetName(){
        return _name;
    }

}