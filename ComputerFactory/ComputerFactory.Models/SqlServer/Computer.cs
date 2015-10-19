using System.ComponentModel.DataAnnotations;

namespace ComputerFactory.Models.SqlServer
{
    public class Computer
    {
        public Computer(string model, double price)
        {
            this.Model = model;
            this.Price = price;
        }

        public int Id { get; set; }

        [MaxLength(30)]
        public string Model { get; set; }

        public int CpuId { get; set; }

        public virtual Cpu Cpu { get; set; }

        public int PsuId { get; set; }

        public virtual Psu Psu { get; set; }

        public int MotherboardId { get; set; }

        public virtual Motherboard Motherboard { get; set; }

        public int RamId { get; set; }

        public virtual Ram Ram { get; set; }

        public int SaleId { get; set; }

        public virtual Sale Sale { get; set; }

        public double Price { get; set; }
    }
}
