namespace WormGearKursovaya;

public sealed class Detail
{
    public int Id { get; set; }

    public double Z1 { get; set; }

    public int Z2 { get; set; }

    public double SigmaHP { get; set; }

    public double X { get; set; }

    public double N { get; set; }

    public double Kfl { get; set; }

    public double Aw { get; set; }

    public double M { get; set; }

    public double T2 { get; set; }

    public double N1 { get; set; }

    public ConstructionUnit? ConstructionUnit { get; set; }
}