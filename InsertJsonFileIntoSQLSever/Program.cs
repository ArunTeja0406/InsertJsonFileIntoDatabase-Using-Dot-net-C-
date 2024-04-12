using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using InsertJsonFileIntoSQLSever.Model;

namespace InsertJsonFileIntoSQLSever
{
    class Program
    {
        static void Main(string[] args)
        {
            int filesImported = 0;
            int filesFailed = 0;

            try
            {
                string connectionString = Config.ConnectionString;
                string directoryPath = ""; // Add your folder path where files contains

                if (!Directory.Exists(directoryPath))
                {
                    Console.WriteLine($"Directory '{directoryPath}' does not exist.");
                    return;
                }

                string[] filePaths = Directory.GetFiles(directoryPath, "*.txt");

                foreach (string filePath in filePaths)
                {
                    try
                    {
                        string fileContents = File.ReadAllText(filePath);
                        var sales = JsonConvert.DeserializeObject<List<SalesDataModel>>(fileContents);

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string insertQuery = "INSERT INTO SalesData (VID, Deleted, CreatedDate, ModifiedDate, OrderId, ProductCode, Name, ProductArea, Manufacturer, GoodsRecNumber, VendorInvoiceNumber, SalesQty) VALUES (@VID, @Deleted, @CreatedDate, @ModifiedDate, @OrderId, @ProductCode, @Name, @ProductArea, @Manufacturer, @GoodsRecNumber, @VendorInvoiceNumber, @SalesQty)";
                            connection.Open();

                            bool isDeleted = false;

                            foreach (var sale in sales)
                            {
                                if (!string.IsNullOrEmpty(sale.Manufacturer) || sale.Manufacturer == "Apple") // In case to filter data based on values, add parameters else remove condition
                                {
                                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                                    {
                                        Guid vid = Guid.NewGuid();
                                        command.Parameters.AddWithValue("@VID", vid);
                                        command.Parameters.AddWithValue("@Deleted", isDeleted);
                                        command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                                        command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                                        command.Parameters.AddWithValue("@OrderId", sale.OrderId);
                                        command.Parameters.AddWithValue("@ProductCode", sale.ProductCode);
                                        command.Parameters.AddWithValue("@Name", sale.Name);
                                        command.Parameters.AddWithValue("@ProductArea", sale.ProductArea);
                                        command.Parameters.AddWithValue("@Manufacturer", sale.Manufacturer);
                                        command.Parameters.AddWithValue("@GoodsRecNumber", sale.GoodsRecNumber);
                                        command.Parameters.AddWithValue("@VendorInvoiceNumber", sale.VendorInvoiceNumber);
                                        command.Parameters.AddWithValue("@SalesQty", sale.SalesQty);

                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        Console.WriteLine($"Data from {filePath} inserted into SalesData table.");
                        filesImported++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while processing file '{filePath}': {ex.Message}");
                        // Log the exception
                        filesFailed++;
                    }
                }

                Console.WriteLine($"Number of files imported: {filesImported}");
                Console.WriteLine($"Number of files failed: {filesFailed}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                // Log the exception
            }
            Console.Read();
        }
    }
}