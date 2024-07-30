using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TankTap.SharedKernel;
using TankTap.Stations.Domain.CityAggregate;
using TankTap.Stations.Domain.PointOfSaleTypeAggregate;
using TankTap.Stations.Domain.ProductAggregate;
using TankTap.Stations.Domain.RegionAggregate;
using TankTap.Stations.Domain.StationAggregate;

namespace TankTap.Stations.Infrastructure.Persistence;

public class DataContext(DbContextOptions<DataContext> options, IMediator? mediator = null) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(TankTabDbContextSchema.DefaultSchema);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (mediator == null)
            return result;

        var entitiesWithEvents = ChangeTracker
            .Entries()
            .Select(e => e.Entity as IDomainEntity)
            .Where(e => e?.Events is not null && e.Events.Count != 0)
            .ToArray();

        foreach (IDomainEntity? entity in entitiesWithEvents)
        {
            BaseDomainEvent[] events = [.. entity!.Events];
            entity.ClearDomainEvents();
            foreach (BaseDomainEvent domainEvent in events)
            {
                await mediator.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
            }
        }

        return result;
    }
    public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
    
    public DbSet<Region> Regions { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<PointOfSaleType> PointOfSaleTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Station> Stations { get; set; }
}
