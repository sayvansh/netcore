using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace congestion.calculator;

public partial class OpenBankingContext : DbContext
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        IgnoreReadOnlyFields = true
    };

    public OpenBankingContext()
    {
    }

    public OpenBankingContext(DbContextOptions<OpenBankingContext> options)
        : base(options)
    {
    }


    public virtual DbSet<City> Cities { get; set; }
    
    public virtual DbSet<Rule> Rules { get; set; }
    
    public virtual DbSet<Motorbike> Motorbikes { get; set; }
    
    public virtual DbSet<CalenderRule> CalenderRules { get; set; }
    
    public virtual DbSet<Car> Cars { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseInMemoryDatabase("congestion_tax");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("city", "application");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Rules).HasColumnName("rules");
            entity.Property(e => e.CalenderRules).HasColumnName("calender");
        });
        
        modelBuilder.Entity<Rule>(entity =>
        {
            entity.ToTable("rule", "application");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.From).HasColumnName("from");
            entity.Property(e => e.To).HasColumnName("to");
            entity.Property(e => e.Amount).HasColumnName("amount");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.ToTable("car", "application");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.VehicleType).HasColumnName("vehicle_type");
            entity.Property(e => e.IsTaxFree).HasColumnName("is_tax_free");
        });

        modelBuilder.Entity<Motorbike>(entity =>
        {
            entity.ToTable("car", "application");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.VehicleType).HasColumnName("vehicle_type");
            entity.Property(e => e.IsTaxFree).HasColumnName("is_tax_free");
        });

        modelBuilder.Entity<CalenderRule>(entity =>
        {
            entity.ToTable("car", "application");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Days).HasColumnName("day");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}