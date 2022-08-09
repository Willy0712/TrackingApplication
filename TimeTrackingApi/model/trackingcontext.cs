using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace TimeTrackingApi.Models
{
  public class trackingcontext : DbContext
  {

    private readonly IConfiguration configuration;
    public trackingcontext(DbContextOptions<trackingcontext> options, IConfiguration configuration)
        : base(options)
    {
      this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("TrackingConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<tracking>()
          .HasOne<Country>(c => c.Country)
          .WithMany(t => t.Trackings)
          .HasForeignKey(s => s.Countryid);
      modelBuilder.Entity<tracking>()
          .HasOne<State>(e => e.State)
          .WithMany(g => g.Trackings)
          .HasForeignKey(s => s.Stateid);
      modelBuilder.Entity<tracking>()
          .HasOne<City>(e => e.City)
          .WithMany(g => g.Trackings)
          .HasForeignKey(s => s.Cityid);
    }






    public DbSet<tracking> Tracking { get; set; } = null!;
    public DbSet<SubActivity> SubActivity { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Country> Country { get; set; } = null!;
    public DbSet<City> City { get; set; } = null!;
    public DbSet<State> State { get; set; } = null!;




  }
}