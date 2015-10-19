namespace ComputerFactory.Data.ExcelLoader
{
    public class ExcelReportsTraverser
    {
        public ExcelReportsTraverser(string directory)
        {
            this.Directory = directory;
        }

        public string Directory { get; set; }

        public void Traverse()
        {
            string[] excelFilePaths = System.IO.Directory.GetFiles(this.Directory, "*.*", System.IO.SearchOption.AllDirectories);

            foreach (var excelFilePath in excelFilePaths)
            {
                var excelComputersParser = new ExcelComputersParser(excelFilePath);
                excelComputersParser.ParseExcelToComputers();
            }
        }
    }
}
