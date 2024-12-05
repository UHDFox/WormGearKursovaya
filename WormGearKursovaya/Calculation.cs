namespace WormGearKursovaya;

public class Calculation
{
    /*public Calculation(int id, DateTimeOffset calculationDate, double aw, double d2, double x, double m,
        int inputParameterId)
    {
        Id = id;
        CalculationDate = calculationDate;
        Aw = aw;
        D2 = d2;
        X = x;
        M = m;
        InputParameterId = inputParameterId;
    }*/
    public int Id { get; set; }
    public DateTimeOffset CalculationDate { get; set; }
    public double Aw { get; set; }
    public double D2 { get; set; }
    public double X { get; set; }
    public double M { get; set; }
    public int InputParameterId { get; set; }
    
    public InputParameters? InputParameter { get; set; }
}