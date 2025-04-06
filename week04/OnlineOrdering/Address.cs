using System;
using System.Text;

public class Address{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(){

    }

    public Address(string street, string city, string stateOrProvince, string country){
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public string GetAddress(){
        StringBuilder addressBuilder = new StringBuilder();
        addressBuilder.Append(_street).Append(", " );
        addressBuilder.Append(_city).Append(' ');
        addressBuilder.Append(_stateOrProvince).Append(", ");
        addressBuilder.Append(_country);
        addressBuilder.Append('.');

        return addressBuilder.ToString();
    }

    public bool IsAddressInUSA(){
        if(_country.ToUpper().Equals("USA") || _country.Equals("United States Of America")){
            return true;
        }
        return false;
    }
}