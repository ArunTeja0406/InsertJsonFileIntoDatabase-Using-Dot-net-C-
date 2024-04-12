using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class Config
    {
        //Added local Database server having windows authentication
        public static string ConnectionString { get; } = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=model;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=10;"; // Update connection string acccordingly
    }

