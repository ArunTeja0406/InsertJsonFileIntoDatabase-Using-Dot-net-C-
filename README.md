# InsertJsonFileIntoDatabase

**Project Title: ReadJson**

**Description:**
The ReadJson project is a C# console application designed to read JSON data from text files and insert it into a SQL Server database. It utilizes Newtonsoft.Json (version 13.0.3) for JSON deserialization and System.Data.SqlClient (version 4.8.6) for database operations. The application is built using .NET 6.0 and features error handling to handle exceptions during file I/O, JSON deserialization, and database operations.

**Features:**
- Reads JSON data from text files
- Deserializes JSON into C# objects using Newtonsoft.Json
- Inserts data into a SQL Server database using parameterized queries
- Supports optional filtering based on the manufacturer of the product
- Implements error handling to handle exceptions gracefully

**Usage:**
1. Ensure the directory containing the JSON files is specified correctly in the code.
2. Update the database connection string in the Config class.
3. Run the application.

**Note:** Please ensure that appropriate permissions are set for accessing the directory and database.

**Dependencies:**
- Newtonsoft.Json (version 13.0.3)
- System.Data.SqlClient (version 4.8.6)

**Contributing:**
Contributions to the project are welcome! Feel free to fork the repository, make improvements, and submit pull requests.

**License:**
This project is licensed under the [MIT License](link-to-license).
