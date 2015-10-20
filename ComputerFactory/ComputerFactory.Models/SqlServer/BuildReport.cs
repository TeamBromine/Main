namespace ComputerFactory.Models.SqlServer
{
    using System;

    public class BuildReport
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ComputerId { get; set; }

        public Computer Computer { get; set; }

        public int Quantity { get; set; }

        // In hours
        public int Duration { get; set; }

        public double Price { get; set; }
    }
}
