using OnlineShop.Model;
using OnlineShop.Presenter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public sealed class ProductSingleton
    {
        private static ProductSingleton instance = null;
        private static readonly object obj = new object();

        ProductPresenter pres = new ProductPresenter();
        private string _constring = @"Server=ANETA;Database=Shop;Trusted_Connection=True;";

        public static ProductSingleton Instance
        {
            get
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new ProductSingleton();
                    }
                    return instance;
                }
            }
        }

        public void AddProduct(Product p)
        {
            using (SqlConnection conn = new SqlConnection(_constring))
            {
                try
                {
                    conn.Open();
                    string sql = "";
                    if (p.ProductType == "Slodycze")
                    {
                        NoChangePriceFactory noChange = new NoChangePriceFactory();
                        sql = noChange.sqlCommand(p);
                    } else
                    {
                        ChangePriceFactory change = new ChangePriceFactory();
                        sql = change.sqlCommand(p);
                    }
                    
                    
                    SqlCommand command = new SqlCommand(sql, conn);

                    command.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    //.Message;
                }
            }
        }

        public List<Product> GetProduct()
        {
            List<Product> p = new List<Product>();

            using (SqlConnection conn = new SqlConnection(_constring))
            {
                try
                {
                    conn.Open();
                    string sql = "Select * from dbo.Product";
                    SqlCommand command = new SqlCommand(sql, conn);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        p.Add(new Product()
                        {
                            ID = Int32.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString(),
                            Price = Decimal.Parse(reader["Price"].ToString()),
                            ProductType = reader["ProductType"].ToString()
                        });
                    }


                }
                catch (SqlException ex)
                {
                    //.Message;
                }
            }
            return p;
        }
    }
}
