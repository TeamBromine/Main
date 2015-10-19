namespace ComputerFactory.Models.MongoDb
{
    public class Sale
    {
        public Sale(string month)
        {
            this.Month = month;
        }

        public string Month { get; set; }
    }
}
