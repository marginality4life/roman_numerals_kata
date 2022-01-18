namespace roman_numerals_kata;

public class Checkout
{
    private readonly List<Item> _items;

    public Checkout(List<Item> pricingRules)
    {
        _items = pricingRules;
    }

    public void Scan(string name)
    {
        foreach (var item in _items)
        {
            if (item.Name == name)
            {
                item.Add();
                return;
            }
        }
        //Item not found - just do nothing for now
    }
    
    public int Total => _items.Select(x => x.Total()).Sum();
}