using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using CaseStudyPart2.Models;

namespace CaseStudyPart2
{
    public class FileAdapter
    {
        private readonly string _connectionString;

        public FileAdapter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertPrices(string path)
        {
            var recs = ReadCsv<Prices>(path);
            BulkInsert("Part2.StagingPrices", recs);
        }

        public void InsertHoliday(string path)
        {
            var recs = ReadTxt<Holidays>(path);
            BulkInsert("Part2.StagingHolidays", recs);
        }

        public void InsertConstituencies(string path)
        {
            var recs = ReadCsv<Constituents>(path);
            BulkInsert("Part2.StagingConstituents", recs);
        }

        private List<T> ReadCsv<T>(string filePath, char delimiter = ',')
        {
            using var reader = new StreamReader(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimiter.ToString(),
                HasHeaderRecord = true,
                BadDataFound = null,
                Quote = '"',

            };
            using var csv = new CsvReader(reader, config);
            return new List<T>(csv.GetRecords<T>());
        }

        private List<T> ReadTxt<T>(string filePath, char delimiter = '\t')
        {
            using var reader = new StreamReader(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimiter.ToString(),
                HasHeaderRecord = true,
                Quote = '"',
                BadDataFound = null,
                TrimOptions = TrimOptions.Trim
            };
            using var csv = new CsvReader(reader, config);
            return new List<T>(csv.GetRecords<T>());
        }

        private void BulkInsert<T>(string tableName, List<T> records)
        {
            var dataTable = ConvertToDataTable(records);

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var bulkCopy = new SqlBulkCopy(connection)
            {
                DestinationTableName = tableName,
                BatchSize = 1000 // Adjust batch size based on your environment
            };
            foreach (var column in typeof(T).GetProperties())
            {
                bulkCopy.ColumnMappings.Add(column.Name, column.Name);
            }

            bulkCopy.WriteToServer(dataTable);
        }

        private DataTable ConvertToDataTable<T>(List<T> records)
        {
            var dataTable = new DataTable();

            // Add columns
            foreach (var prop in typeof(T).GetProperties())
            {
                dataTable.Columns.Add(prop.Name, typeof(string));
            }

            // Add rows
            foreach (var record in records)
            {
                var row = dataTable.NewRow();
                foreach (var prop in typeof(T).GetProperties())
                {
                    row[prop.Name] = prop.GetValue(record) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }


        public void LoadHolidaysToDatabase(string connectionString, string holidaysFilePath)
        {
            // Open a connection to the SQL database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to insert data into the StagingHolidays table
                string query = @"
                INSERT INTO Part2.StagingHolidays
                ([HolidayDate], [HolidayDescription])
                VALUES (@HolidayDate, @HolidayDescription)";

                // Open the holidays text file
                using (var reader = new StreamReader(holidaysFilePath))
                {
                    // Skip the header line
                    reader.ReadLine();

                    // Read each line in the file
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var columns = line.Split(new[] { '\t' }, StringSplitOptions.None);

                        if (columns.Length == 2)
                        {
                            string holidayDate = columns[0].Trim();
                            string holidayDescription = columns[1].Trim();

                            // Insert each line's data into the database
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@HolidayDate", holidayDate);
                                command.Parameters.AddWithValue("@HolidayDescription", holidayDescription);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }

                Console.WriteLine("Holiday data inserted successfully.");
            }
        }
        }
}
