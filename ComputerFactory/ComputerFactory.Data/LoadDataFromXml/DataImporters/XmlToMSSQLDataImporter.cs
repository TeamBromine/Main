namespace ComputerFactory.Data.LoadDataFromXml.DataImporters
{
    using ComputerFactory.Data.LoadDataFromXml.Models;
    using System.Collections.Generic;

    public class XmlToMSSQLDataImporter : IDataImporter
    {
        public void ImportData(IEnumerable<Sale> sales)
        {
            var db = new ComputerFactorySqlDbContext();

            foreach (var sale in sales)
            {
                foreach (var computer in sale.Computers)
                {
                    //var computerToAdd = new ComputerFactory.Models.SqlServer.Computer(computer.Model, computer.Price);
                    //computerToAdd.SaleId = sale.Id;
                    //db.Computers.Add(computerToAdd);
                    //saleToAdd.Computers.Add(computerToAdd);
                }

                var saleToAdd = new ComputerFactory.Models.SqlServer.Sale(sale.Month);
                db.Sales.Add(saleToAdd);
            }

            db.SaveChanges();
        }
    }
}
