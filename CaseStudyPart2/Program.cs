using CaseStudyPart2;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Server = 192.168.0.13\\sqlexpress,49753; Database = IVP_OS_CS; User Id = sa;Password = sa@12345678; TrustServerCertificate = True"; // Update with your actual connection string
       
        string PricesFilePath = @"C:\Users\ossingh\Downloads\20201231-20211231 S_P 500 Prices.csv"; // Update with the actual file path

        string holidaysFilePath = @"C:\Users\ossingh\Downloads\Holidays2021.txt";
        string ConstituentsFilePath = @"C:\Users\ossingh\Downloads\S_P500 constituents.xlsx";

        var adapter = new FileAdapter(connectionString);
        //adapter.InsertPrices(PricesFilePath);
        //adapter.InsertHoliday(holidaysFilePath);
        //adapter.LoadHolidaysToDatabase(connectionString, holidaysFilePath);
        //adapter.InsertConstituencies(ConstituentsFilePath);
    }
}
