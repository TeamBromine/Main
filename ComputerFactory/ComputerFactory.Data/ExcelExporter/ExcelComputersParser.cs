namespace ComputerFactory.Data.ExcelLoader
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.OleDb;

    using ComputerFactory.Data.Repositories;

    using ComputerFactory.Models.SqlServer;

    public class ExcelComputersParser
    {
        private const int ProductId = 0;
        private const int QuantityId = 1;
        private const int DurationId = 2;
        private const int PriceId = 3;

        public const string SelectStringFormat = "SELECT * FROM [{0}$]";

        //private OleDbConnection con = new OleDbConnection(connectionString);
        //private OleDbCommand cmd = new OleDbCommand(selectString, con);

        private OleDbConnection connection;
        private OleDbCommand command;
        private IRepository<BuildReport> buildReports;

        public ExcelComputersParser(string filePath)
            : this(filePath, "Sheet1", new EfRepository<BuildReport>())
        {

        }

        public ExcelComputersParser(string filePath, string selectStringSheet)
            : this(filePath, selectStringSheet, new EfRepository<BuildReport>())
        {

        }

        public ExcelComputersParser(string filePath, string selectStringSheet, IRepository<BuildReport> buildReports)
        {
            this.FilePath = filePath;
            this.SelectString = string.Format(SelectStringFormat, selectStringSheet);
            this.connection = new OleDbConnection(this.ConnectionString);
            this.command = new OleDbCommand(this.SelectString, connection);
            this.buildReports = buildReports;
        }

        public string FilePath { get; set; }

        public string SelectString { get; set; }

        public string ConnectionString 
        {
            get
            {
                return "Provider=Microsoft.Jet.OleDb.4.0; data source=" + this.FilePath + "; Extended Properties=Excel 8.0;";
            }
        }

        public List<Computer> Computers { get; set; }

        public void ParseExcelToComputers()
        {
            try
            {
                connection.Open();
                OleDbDataReader theData = command.ExecuteReader();
                while (theData.Read())
                {
                    BuildReport buildReport = new BuildReport()
                    {
                        ComputerId = theData.GetInt32(ProductId),
                        Date = DateTime.Now,
                        Quantity = theData.GetInt32(QuantityId),
                        Duration = theData.GetInt32(DurationId),
                        Price = theData.GetInt32(PriceId)
                    };

                    this.buildReports.Add(buildReport);
                    this.buildReports.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}