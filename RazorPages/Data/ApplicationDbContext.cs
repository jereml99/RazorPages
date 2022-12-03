using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataModel;

namespace RazorPages.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
        //, 
        //DbSet<Anion> anions, DbSet<Cation> cations, 
        //DbSet<Producer> producer, DbSet<Product> product, 
        //DbSet<Delivery> delivery, DbSet<Order> order, DbSet<Sales> sales, DbSet<SalesList> salesList, 
        //DbSet<CationsList> cationsList, DbSet<AnionsList> anionsList
        )
        : base(options)
    {
        //Anions = anions;
        //Cations = cations;
        //Producer = producer;
        //Product = product;
        //Delivery = delivery;
        //Order = order;
        //Sales = sales;
        //SalesList = salesList;
        //CationsList = cationsList;
        //AnionsList = anionsList;
    }
    public DbSet<Anion> Anions { get; set; }
    public DbSet<Cation> Cations { get; set; }
    public DbSet<Producer> Producer { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Delivery> Delivery { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Sales> Sales { get; set; }
    public DbSet<SalesList> SalesList { get; set; }
    public DbSet<CationsList> CationsList { get; set; }
    public DbSet<AnionsList> AnionsList { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("(localdb)\\mssqllocaldb;Database=yyy;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}