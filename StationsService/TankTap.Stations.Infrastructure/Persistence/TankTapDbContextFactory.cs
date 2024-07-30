using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TankTap.Stations.Infrastructure.Persistence;
public class TankTapDbContextFactory() : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=TankTap;TrustServerCertificate=True;Trusted_Connection=True;");

        return new DataContext(optionBuilder.Options);
    }
}
