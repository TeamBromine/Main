namespace ComputerFactory.Data.ExcelLoader
{
    using System;
    using System.IO.Compression;

    public static class ReportsUnzipper
    {
        public static void Unzip(string zipPath, string extractPath)
        {
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
