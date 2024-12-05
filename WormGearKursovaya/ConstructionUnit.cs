namespace WormGearKursovaya;

public sealed class ConstructionUnit
{
    public int Id { get; set; }
    public double X { get; set; }
    public double N { get; set; }
    public double Kfl { get; set; }
    public double Aw { get; set; }

    public List<Detail> Details { get; set; } = new List<Detail>();
}