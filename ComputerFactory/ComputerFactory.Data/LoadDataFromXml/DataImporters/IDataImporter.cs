namespace ComputerFactory.Data.LoadDataFromXml.DataImporters
{
    using Models;
    using System.Collections.Generic;

    public interface IDataImporter
    {
        void ImportData(IEnumerable<Sale> sales);
    }
}
