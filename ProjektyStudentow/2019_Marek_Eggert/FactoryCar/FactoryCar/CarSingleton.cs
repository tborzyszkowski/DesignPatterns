using FactoryCar.Model;
using FactoryCar.Presenter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCar
{
    public sealed class CarSingleton
    {
        private static CarSingleton instance = null;
        private static readonly object obj = new object();

        CarPresenter pres = new CarPresenter();
        private string _constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\uzytkownik\Documents\bazka.mdf;Integrated Security=True;Connect Timeout=30";

        public static CarSingleton Instance
        {
            get
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new CarSingleton();
                    }
                    return instance;
                }
            }
        }

        public void AddProduct(Car c)
        {
            using (SqlConnection conn = new SqlConnection(_constring))
            {
               
                    conn.Open();
                    string sql = "";
                    if (c.Battery == "S2")
                    {
                        NoChangePriceFactory noChange = new NoChangePriceFactory();
                        sql = noChange.sqlCommand(c);
                    } else
                    {
                        ChangePriceFactory change = new ChangePriceFactory();
                        sql = change.sqlCommand(c);
                    }
                    
                    
                    SqlCommand command = new SqlCommand(sql, conn);

                    command.ExecuteNonQuery();

                
            }
        }

        public List<Car> GetCar()
        {
            List<Car> c = new List<Car>();

            using (SqlConnection conn = new SqlConnection(_constring))
            {
                try
                {
                    conn.Open();
                    string sql = "Select * from dbo.Car";
                    SqlCommand command = new SqlCommand(sql, conn);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        c.Add(new Car()
                        {
                            ID = Int32.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString(),
                            Speed = Decimal.Parse(reader["Speed"].ToString()),
                            Battery = reader["Battery"].ToString()
                        });
                    }


                }
                catch (SqlException ex)
                {
            
                }
            }
            return c;
        }
    }
}