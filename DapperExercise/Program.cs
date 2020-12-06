using System;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DapperExercise
{

    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json")
                              .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var repoDept = new DapperDepartmentRepository(conn);
            var repoProd = new DapperProductRepository(conn);

            int selection = 0;

            while (selection != 5)
            {
                Console.WriteLine("[1] View Departments");
                Console.WriteLine("[2] Create New Department");
                Console.WriteLine("[3] View Products");
                Console.WriteLine("[4] Enter New Product");
                Console.WriteLine("[5] Exit Program");
                Console.WriteLine("Please enter a selection number (1 - 5): ");

                selection = Convert.ToInt32(Console.ReadLine());

                if (selection == 1)
                {
                    var departments = repoDept.GetAllDepartments();

                    foreach (var dept in departments)
                    {
                        Console.WriteLine(dept.Name);
                    }
                }

                if (selection == 2)
                {
                    Console.WriteLine("Type a new Department name");

                    var newDepartment = Console.ReadLine();

                    repoDept.InsertDepartment(newDepartment);
                }

                if (selection == 3)
                {
                    var products = repoProd.GetAllProducts();

                    foreach (var prod in products)
                    {
                        Console.WriteLine(prod.Name);
                    }
                }

                if (selection == 4)
                {
                    Console.WriteLine("Type a new product name");

                    var newProdName = Console.ReadLine();

                    Console.WriteLine("Type the product's price");

                    var newProdPrice = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Type the product's category ID");

                    var newProdCat = Convert.ToInt32(Console.ReadLine());

                    repoProd.CreateProduct(newProdName, newProdPrice, newProdCat);
                }
            }
        }
    }
}
