using KappaCreations.Database;
using System.Web.Http;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace KappaCreations.Controllers.Api
{
    public class AdminStatsController : ApiController
    {
        readonly ShopContext _db;

        public AdminStatsController()
        {
            _db = new ShopContext();
        }
        public AdminStatsController(ShopContext db)
        {
            _db = db;
        }

        [Route("api/adminStats/categoriesByOrders")]
        public object GetCategoriesByOrders()
        {
            string connectionString = _db.Database.Connection.ConnectionString;
            var response = new List<object>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT CategoryId, SUM(Quantity) AS 'Count'
                    	FROM Orders ord
                    	JOIN OrderItems item
                    		ON item.OrderId = ord.Id
                    	JOIN Products product
                    		ON product.Id = item.ProductId
                    	JOIN ProductCategories category
                    		ON category.Id = product.CategoryId
                    	GROUP BY CategoryId
                    	ORDER BY 'Count' DESC";
                    conn.Open();

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int categoryId = reader.GetInt32(0);
                                int quantity = reader.GetInt32(1);
                                object row = new { categoryId, quantity };
                                response.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [Route("api/adminStats/totalEarnings")]
        public object GetTotalEarnings()
        {
            string connectionString = _db.Database.Connection.ConnectionString;
            object response;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT SUM(item.Quantity * category.Price) AS 'Sum'
                    	FROM OrderItems item
                    	JOIN Products product
                    		ON product.Id = item.ProductId
                    	JOIN ProductCategories category
                    		ON category.Id = product.CategoryId;";
                    conn.Open();

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            double totalEarnings = reader.GetDouble(0);
                            response = new { totalEarnings };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}