namespace ComputerFactory.ExcelLoader
{
    using ComputerFactory.Models.SqlServer;
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;

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

        public ExcelComputersParser(string filePath, string selectStringSheet = "Sheet1")
        {
            this.FilePath = filePath;
            this.SelectString = string.Format(SelectStringFormat, selectStringSheet);
            this.connection = new OleDbConnection(this.ConnectionString);
            this.command = new OleDbCommand(this.SelectString, connection);
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
                bool isFirstLine = true;

                connection.Open();
                OleDbDataReader theData = command.ExecuteReader();
                while (theData.Read())
                {
                    if(isFirstLine)
                    {
                        Console.Write("{0}   |", theData.GetName(ProductId));
                        Console.Write("{0}   |", theData.GetName(QuantityId));
                        Console.Write("{0}   |", theData.GetName(DurationId));
                        Console.Write("{0}   |", theData.GetName(PriceId));
                        Console.WriteLine();

                        isFirstLine = false;
                    }

                    Console.Write("{0}   ", theData.GetValue(ProductId));
                    Console.Write("{0}   ", theData.GetValue(QuantityId));
                    Console.Write("{0}   ", theData.GetValue(DurationId));
                    Console.Write("{0}   ", theData.GetValue(PriceId));
                    Console.WriteLine();
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