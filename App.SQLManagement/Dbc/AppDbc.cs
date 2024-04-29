using App.Domain.Operations;
using App.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace App.SQLManagement.Dbc;

public class AppDbc : DbContext
{
    public AppDbc(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Operation> Operations { get; set; }
}
