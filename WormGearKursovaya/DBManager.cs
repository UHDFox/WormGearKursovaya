using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WormGearKursovaya;

public class DbManager : DbContext
{
    public DbSet<InputParameters> InputParameters { get; set; }
    public DbSet<Calculation> Calculations { get; set; }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Связь 1:1 с внешним ключом
        modelBuilder.Entity<InputParameters>()
            .HasOne(ip => ip.Calculation)
            .WithOne(c => c.InputParameter)
            .HasForeignKey<Calculation>(c => c.InputParameterId);
        
        modelBuilder.Entity<Calculation>()
            .Property(cal => cal.CalculationDate)
            .HasConversion(
                c => c.UtcDateTime, // Сохраняем в UTC 
                c => new DateTimeOffset(c)); // Преобразуем обратно при чтении
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12345678;Database=WormGearDB";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

        
    public void AddCalculation(InputParameters inputParams, Calculation calculation)
    {
        InputParameters.Add(inputParams);
        Calculations.Add(calculation);
        SaveChanges();
    }

    public void AddCalculation(InputParameters inputParams)
    {
        InputParameters.Add(inputParams);
    }
    public void AddCalculation(Calculation calculation)
    {
        Calculations.Add(calculation);
    }
}