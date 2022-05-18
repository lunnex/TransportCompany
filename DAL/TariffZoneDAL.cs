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
    public class TariffZoneDAL : ITariffZoneDAL
    {
        private readonly string _connectoinString;

        public TariffZoneDAL(string connectoinString)
        {
            _connectoinString = connectoinString;
        }

        public TariffZone Get(int id)
        {
            TariffZone zone = null;

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetZone";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    zone = new TariffZone(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3));
                }
            }

            return zone;
        }

        public List<TariffZone> GetAll()
        {
            var zones = new List<TariffZone>();

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetAllZones";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    zones.Add(new TariffZone(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3)));
                }
            }

            return zones;
        }
    }
}
