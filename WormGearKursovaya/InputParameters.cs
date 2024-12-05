using System.ComponentModel.DataAnnotations;

namespace WormGearKursovaya;

public class InputParameters
{
    /*public InputParameters(int id, int z2, int z1, double q, double sigmaHp, double efficiency, double powerN1,
        double sigmaFp)
    {
        Id = id;
        Z2 = z2;
        Z1 = z1;
        Q = q;
        SigmaHP = sigmaHp;
        Efficiency = efficiency;
        PowerN1 = powerN1;
        SigmaFP = sigmaFp;
    }*/
    public int Id { get; set; }
    public int Z2 { get; set; }
    public int Z1 { get; set; }
    public double Q { get; set; }
    public double SigmaHP { get; set; }
    public double Efficiency { get; set; }
    public double PowerN1 { get; set; }
    public double SigmaFP { get; set; }

    public virtual Calculation? Calculation { get; set; }
}