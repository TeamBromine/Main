namespace ComputerFactory.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using ComputerFactory.Models.SqlServer;

    public interface IComputerFactorySqlDbContext
    {
        IDbSet<Computer> Computers { get; set; }

        IDbSet<Motherboard> Motherboards { get; set; }

        IDbSet<Psu> Psus { get; set; }

        IDbSet<Cpu> Cpus { get; set; }

        IDbSet<Ram> Rams { get; set; }

        IDbSet<Vendor> Vendors { get; set; }

        IDbSet<Sale> Sales { get; set; }

        IDbSet<BuildReport> BuildReports { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}