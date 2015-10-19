namespace ComputerFactory.Models.SqlServer
{
    using System.Collections.Generic;

    public class Psu
    {
        private ICollection<Computer> computers;

        public Psu() 
        {
            this.computers = new HashSet<Computer>();
        }

        public int Id { get; set; }

        public string Model { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public int Power { get; set; }

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
