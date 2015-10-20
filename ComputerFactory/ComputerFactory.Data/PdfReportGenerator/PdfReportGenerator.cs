namespace ComputerFactory.Data.PdfReportGenerator
{
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.IO;
    using System.Linq;

    public static class PdfReportGenerator
    {
        private const string PdfFilePath = "../../../Data/ComputerPricesReport.pdf";
        private const string PdfTableTitle = "Aggregated Computer Prices Report";
        private const string PriceColumnTitle = "Price";
        private const string ComputerColumnTitle = "Computer";
        private const string CpuColumnTitle = "Cpu";
        private const string PsuColumnTitle = "Psu";
        private const string MotherboardColumnTitle = "Motherboard";
        private const string RamColumnTitle = "Ram";
        private const int DocumentMarginLeft = 50;
        private const int DocumentMarginRight = 50;
        private const int DocumentMarginTop = 50;
        private const int DocumentMarginBottom = 20;
        private const int PdfTableNumberOfColumns = 5;

        public static void GeneratePdfReport()
        {
            Document document = new Document(
                PageSize.A4, 
                DocumentMarginLeft, 
                DocumentMarginRight, 
                DocumentMarginTop, 
                DocumentMarginBottom);
            FileStream fileStream = new FileStream(
                PdfFilePath, 
                FileMode.Create, 
                FileAccess.Write, 
                FileShare.None);
            PdfWriter writer = PdfWriter.GetInstance(document, fileStream);

            document.Open();

            using (var db = new ComputerFactorySqlDbContext())
            {
                var computersGroups = db.Computers.GroupBy(c => c.Price).ToList();

                PdfPTable table = new PdfPTable(PdfTableNumberOfColumns);
                PdfPCell cell = new PdfPCell(new Phrase(PdfTableTitle));
                cell.Colspan = PdfTableNumberOfColumns;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                foreach (var computersGroup in computersGroups)
                {
                    string priceColumnStringFormat = PriceColumnTitle + ": " + computersGroup.FirstOrDefault().Price + "$";
                    PdfPCell priceCell = new PdfPCell(new Phrase(priceColumnStringFormat));
                    priceCell.Colspan = PdfTableNumberOfColumns;
                    priceCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(priceCell);

                    PdfPCell computerCell = new PdfPCell(new Phrase(ComputerColumnTitle));
                    table.AddCell(computerCell);

                    PdfPCell cpuCell = new PdfPCell(new Phrase(CpuColumnTitle));
                    table.AddCell(cpuCell);

                    PdfPCell psuCell = new PdfPCell(new Phrase(PsuColumnTitle));
                    table.AddCell(psuCell);

                    PdfPCell motherboardCell = new PdfPCell(new Phrase(MotherboardColumnTitle));
                    table.AddCell(motherboardCell);

                    PdfPCell ramCell = new PdfPCell(new Phrase(RamColumnTitle));
                    table.AddCell(ramCell);

                    var computers = computersGroup.ToList();

                    foreach (var computer in computers)
                    {
                        table.AddCell(computer.Model);
                        table.AddCell(computer.Cpu.Model);
                        table.AddCell(computer.Psu.Model);
                        table.AddCell(computer.Motherboard.Model);
                        table.AddCell(computer.Ram.Model);
                    }

                    string totalComputersCountStringFormat = "Total computers with given price: " + computers.Count;
                    PdfPCell totalComputersCountCell = new PdfPCell(new Phrase(totalComputersCountStringFormat));
                    totalComputersCountCell.Colspan = PdfTableNumberOfColumns;
                    totalComputersCountCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(totalComputersCountCell);
                } 
                                
                document.Add(table);
                document.Close();
            }             
        }
    }
}
