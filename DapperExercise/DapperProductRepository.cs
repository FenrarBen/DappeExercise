using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DapperExercise
{
    class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@productName, @productPrice, @productCategoryID);", 
                new { productName = name, productPrice = price, productCategoryID = categoryID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }
    }
}
