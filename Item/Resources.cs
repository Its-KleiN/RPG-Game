public class Resource : Item
{
    public Resource(string name, string description,
                    double weight, int basePrice)
        : base(name, description, weight, basePrice)
    {
    }

    public override string GetItemType()
    {
        return "Ресурс";
    }
}