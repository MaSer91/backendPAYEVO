// Database Context
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Absence> Absences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Employee>()
            .ToTable("Employees")
            .HasKey(e => e.EmployeeID);

        modelBuilder.Entity<Absence>()
            .ToTable("EmployeeAbsences");
            //.HasOne(a => a.EmployeeId)
            //.WithMany()
            //.HasForeignKey(a => a.EmployeeId);
    }
}
