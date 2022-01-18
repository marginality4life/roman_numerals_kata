namespace roman_numerals_kata;

public class Item
{
    
    public string Name { get; private set; }
    public int UnitPrice { get; private set; }
    public SpecialPrice? SpecialPrice { get; private set; }
    private int _quantity = 0;

    public Item(string name, int unitPrice, SpecialPrice? specialPrice = null)
    {
        Name = name;
        UnitPrice = unitPrice;
        SpecialPrice = specialPrice;
    }

    public void Add()
    {
        _quantity++;
    }

    public int Total()
    {
        if (SpecialPrice == null)
        {
            return UnitPrice * _quantity;
        }

        var specialPriceComponent = _quantity / SpecialPrice.Quantity * SpecialPrice.Price;
        var normalPriceComponent = _quantity % SpecialPrice.Quantity * UnitPrice;
        
        return specialPriceComponent + normalPriceComponent;
    }

}

public class SpecialPrice
{
    public int Price { get; }
    public int Quantity { get; }

    public SpecialPrice(int quantity, int price)
    {
        Price = price;
        Quantity = quantity;
    }
}
