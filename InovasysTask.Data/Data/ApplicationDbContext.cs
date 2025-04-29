using InovasysTask.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InovasysTask.Data.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
    {
    }

    public ApplicationDbContext()
    {
    }

    public virtual DbSet<User> Users {  get; set; }

    public virtual DbSet<Addresses> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) =>
        base.OnModelCreating(builder);
}
