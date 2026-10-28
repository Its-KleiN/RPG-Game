
public abstract class Consumable : Item
{
    protected Consumable(
        string name,
        string description,
        double weight,
        int basePrice)
        : base(name, description, weight, basePrice)
    {
    }

    public abstract bool Use(Player player);

    public override string GetDescription()
    {
        return base.GetDescription() + "\n" +
               "Тип предмета: Витратний";
    }
}
