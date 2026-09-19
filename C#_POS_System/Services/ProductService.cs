using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__POS_System.DbConnection;
using C__POS_System.Models;
using Microsoft.Data.SqlClient;

namespace C__POS_System.Services
{
    internal class ProductService
    {
        public int AddProduct(Product product)
        {
            string query = "INSERT INTO Products (Name, Price, CategoryID, Image) VALUES (@Name, @Price, @CategoryID, @Image)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@CategoryID", product.CategoryID),
                new SqlParameter("@Image", product.Imaage)
            };
            return Db.ExecuteNonQuery(query, parameters);
        }

        public int UpdateProduct(Product product)
        {
            string query = "UPDATE Products SET Name = @Name, Price = @Price, CategoryID = @CategoryID, Image = @Image WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", product.Id),
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@CategoryID", product.CategoryID),
                new SqlParameter("@Image", product.Imaage)
            };
            return Db.ExecuteNonQuery(query, parameters);
        }

        public int DeleteProduct(int id)
        {
            string query = "DELETE FROM Products WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };
            return Db.ExecuteNonQuery(query, parameters);
        }

        public List<Product> GetAllProducts()
        {
            string query = "SELECT p.Id, p.Name, p.Price, p.CategoryID, c.Name AS CategoryName, p.Image FROM Products p INNER JOIN Categories c ON p.CategoryID = c.Id";
            DataTable dt = Db.ExecuteQuery(query);
            List<Product> products = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Imaage = row["Image"] != DBNull.Value ? row["Image"].ToString() : string.Empty
                });
            }
            return products;
        }

        public List<Product> SearchProducts(string keyword)
        {
            string query = "SELECT p.Id, p.Name, p.Price, p.CategoryID, c.Name AS CategoryName, p.Image FROM Products p INNER JOIN Categories c ON p.CategoryID = c.Id WHERE p.Name LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            DataTable dt = Db.ExecuteQuery(query, parameters);
            List<Product> products = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Imaage = row["Image"] != DBNull.Value ? row["Image"].ToString() : string.Empty
                });
            }
            return products;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            string query = "SELECT p.Id, p.Name, p.Price, p.CategoryID, c.Name AS CategoryName, p.Image FROM Products p INNER JOIN Categories c ON p.CategoryID = c.Id WHERE p.CategoryID = @CategoryID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryID", categoryId)
            };
            DataTable dt = Db.ExecuteQuery(query, parameters);
            List<Product> products = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Imaage = row["Image"] != DBNull.Value ? row["Image"].ToString() : string.Empty
                });
            }
            return products;
        }
    }
}
