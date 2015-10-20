namespace ComputerFactory.Models.SqlServer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        private ICollection<Computer> computers;

        public Sale(string month)
        {
            this.Month = month;
            this.computers = new HashSet<Computer>();
        }

        public int Id { get; set; }

        [MaxLength(8)]
        public string Month { get; set; }

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
