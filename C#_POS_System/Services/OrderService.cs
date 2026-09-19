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
    internal class OrderService
    {
        public int AddOrder(Order order)
        {
            string query = "INSERT INTO Orders (Date, Total) VALUES (@Date, @Total); SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Date", order.Date),
                new SqlParameter("@Total", order.Total)
            };
            DataTable dt = Db.ExecuteQuery(query, parameters);
            int orderId = Convert.ToInt32(dt.Rows[0][0]);

            foreach (var item in order.Items)
            {
                string itemQuery = "INSERT INTO OrderItems (OrderID, ProductID, ProductName, UnitPrice, Qty, Total) VALUES (@OrderID, @ProductID, @ProductName, @UnitPrice, @Qty, @Total)";
                SqlParameter[] itemParams = new SqlParameter[]
                {
                    new SqlParameter("@OrderID", orderId),
                    new SqlParameter("@ProductID", item.ProductId),
                    new SqlParameter("@ProductName", item.ProductName),
                    new SqlParameter("@UnitPrice", item.UnitPrice),
                    new SqlParameter("@Qty", item.Qty),
                    new SqlParameter("@Total", item.Total)
                };
                Db.ExecuteNonQuery(itemQuery, itemParams);
            }

            return orderId;
        }

        public List<Order> GetAllOrders()
        {
            string query = "SELECT Id, Date, Total FROM Orders ORDER BY Date DESC";
            DataTable dt = Db.ExecuteQuery(query);
            List<Order> orders = new List<Order>();
            foreach (DataRow row in dt.Rows)
            {
                orders.Add(new Order
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Date = Convert.ToDateTime(row["Date"]),
                    Total = Convert.ToDecimal(row["Total"])
                });
            }
            return orders;
        }

        public List<OrderItem> GetOrderItems(int orderId)
        {
            string query = "SELECT ProductID, ProductName, UnitPrice, Qty, Total FROM OrderItems WHERE OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderId)
            };
            DataTable dt = Db.ExecuteQuery(query, parameters);
            List<OrderItem> items = new List<OrderItem>();
            foreach (DataRow row in dt.Rows)
            {
                items.Add(new OrderItem
                {
                    ProductId = Convert.ToInt32(row["ProductID"]),
                    ProductName = row["ProductName"].ToString(),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    Qty = Convert.ToInt32(row["Qty"])
                });
            }
            return items;
        }
    }
}
