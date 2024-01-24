using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoryAPI.Models;

namespace RepositoryAPI.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<MedicalFacility> MedicalFacilities { get; set; }
    public DbSet<ServicePriceList> ServicePriceLists { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
}