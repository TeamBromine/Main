namespace ComputerFactory.Models.SqlServer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Ram
    {
        private ICollection<Computer> computers;

        public Ram() 
        {
            this.computers = new HashSet<Computer>();
        }

        public int Id { get; set; }

        [MaxLength(30)]
        public string Model { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public int Size { get; set; }

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
