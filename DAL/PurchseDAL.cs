using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PurchseDAL : IPurchaseDAL
    {
        private readonly string _connectoinString;

        public PurchseDAL(string connectoinString)
        {
            _connectoinString = connectoinString;
        }

        public List<Purchase> GetPurchases(string phoneNumber)
        {
            List<Purchase> purchases = new List<Purchase>();

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "ShowPurchases";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@phone", System.Data.SqlDbType.NVarChar).Value = phoneNumber;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    purchases.Add(new Purchase(reader.GetDateTime(0), reader.GetString(1), reader.GetDecimal(2), reader.GetString(3), reader.GetDouble(4)));
                }

            }
            return purchases;
        }
    }
}
