namespace ComputerFactory.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using ComputerFactory.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ComputerFactorySqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ComputerFactorySqlDbContext context)
        {
        }
    }
}
