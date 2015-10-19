namespace ComputerFactory.Models.SqlServer
{
    using System.Collections.Generic;

    public class Vendor
    {
        
        private ICollection<Motherboard> motherboards;
        private ICollection<Psu> psus;
        private ICollection<Cpu> cpus;
        private ICollection<Ram> rams;

        public Vendor()
        {
            this.motherboards = new HashSet<Motherboard>();
            this.psus = new HashSet<Psu>();
            this.cpus = new HashSet<Cpu>();
            this.rams = new HashSet<Ram>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }
        
        public virtual ICollection<Motherboard> Motherboards
        {
            get
            {
                return this.motherboards;
            }

            set
            {
                this.motherboards = value;
            }
        }

        public virtual ICollection<Psu> Psus
        {
            get
            {
                return this.psus;
            }

            set
            {
                this.psus = value;
            }
        }

        public virtual ICollection<Cpu> Cpus
        {
            get
            {
                return this.cpus;
            }

            set
            {
                this.cpus = value;
            }
        }

        public virtual ICollection<Ram> Rams
        {
            get
            {
                return this.rams;
            }

            set
            {
                this.rams = value;
            }
        }
    }
}
