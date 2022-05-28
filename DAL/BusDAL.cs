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
    public class BusDAL : IBusDAL
    {
        private readonly string _connectoinString;

        public BusDAL(string connectoinString)
        {
            _connectoinString = connectoinString;
        }

        public Bus GetBus(string num)
        {
            Bus bus = null;

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetBus";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@num", System.Data.SqlDbType.NVarChar).Value = num;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bus = new Bus(reader.GetString(0), reader.GetInt32(3), reader.GetString(2), reader.GetString(4), reader.GetDouble(1));
                }

            }
            return bus;
        }

        public List<Bus> GetBuses()
        {
            List<Bus> buses = new List<Bus>();

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetBuses";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    buses.Add(new Bus(reader.GetString(0), reader.GetInt32(3), reader.GetString(2), reader.GetString(4), reader.GetDouble(1)));
                }

            }
            return buses;
        }
    }
}
