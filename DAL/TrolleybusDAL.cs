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
    public class TrolleybusDAL : ITrolleybusDAL
    {
        private readonly string _connectoinString;

        public TrolleybusDAL(string connectoinString)
        {
            _connectoinString = connectoinString;
        }

        public Trolleybus GetBus(string num)
        {
            Trolleybus trolleybus = null;

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetTrolleybus";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@num", System.Data.SqlDbType.NVarChar).Value = num;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    trolleybus = new Trolleybus(reader.GetString(0), reader.GetInt32(3), reader.GetString(2), reader.GetString(4), reader.GetString(1));
                }

            }
            return trolleybus;
        }

        public List<Trolleybus> GetBuses()
        {
            List<Trolleybus> trolleybuses = new List<Trolleybus>();

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetTrolleybuses";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    trolleybuses.Add(new Trolleybus(reader.GetString(0), reader.GetInt32(3), reader.GetString(2), reader.GetString(4), reader.GetString(1)));
                }

            }
            return trolleybuses;
        }
    }
}
