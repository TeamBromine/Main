namespace ComputerFactory.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using ComputerFactory.Models.SqlServer;

    public class ComputerFactorySqlDbContext : DbContext
    {
        public ComputerFactorySqlDbContext() 
            : base("ComputerFactory")
        {

        }

        public virtual IDbSet<Computer> Computers { get; set; }

        public virtual IDbSet<Motherboard> Motherboards { get; set; }

        public virtual IDbSet<Psu> Psus { get; set; }

        public virtual IDbSet<Cpu> Cpus { get; set; }

        public virtual IDbSet<Ram> Rams { get; set; }

        public virtual IDbSet<Vendor> Vendors { get; set; }

        public virtual IDbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
