using System;
using PermAdminAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace PermAdminAPI.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Employee> Employees {get; set;}
    public DbSet<Licence> Licences {get; set;}
}