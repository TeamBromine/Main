namespace ComputerFactory.Models.SqlServer
{
    using System.Collections.Generic;

    public class Cpu
    {
        private ICollection<Computer> computers;

        public Cpu() 
        {
            this.computers = new HashSet<Computer>();
        }

        public int Id { get; set; }

        public string Model { get; set; }

        public int Cores { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public double Price { get; set; }
        
        public virtual ICollection<Computer> Computers
        {
            get
            {
                return this.computers;
            }

            set
            {
                this.computers = value;
            }
        }
    }
}
