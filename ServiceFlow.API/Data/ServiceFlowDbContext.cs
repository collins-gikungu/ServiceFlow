using Microsoft.EntityFrameworkCore;
using ServiceFlow.API.Models;

namespace ServiceFlow.API.Data;

public class ServiceFlowDbContext : DbContext
{
    public ServiceFlowDbContext(DbContextOptions<ServiceFlowDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}