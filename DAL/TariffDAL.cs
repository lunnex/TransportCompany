using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class TariffDAL : ITariffDAL
    {
        private readonly string _connectoinString;

        public TariffDAL(string connectoinString)
        {
            _connectoinString = connectoinString;
        }

        public Tariff Get(int id)
        {
            Tariff tariff = null;

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetTariff";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[3] is DBNull)
                    {
                        tariff = new Tariff(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), null, reader.GetString(4), reader.GetInt32(5));
                    }
                    else if (reader[5] is DBNull)
                    {
                        tariff = new Tariff(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), (int?)reader.GetInt32(5), reader.GetString(4), null);
                    }
                }
            }

            return tariff;
        }

        public List<Tariff> GetAll()
        {
            var tariffs = new List<Tariff>();

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT* FROM Tariff";
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[3] is DBNull)
                    {
                        tariffs.Add(new Tariff(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), null, reader.GetString(4), reader.GetInt32(5)));
                    }
                    else if(reader[5] is DBNull)
                    {
                        tariffs.Add(new Tariff(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), (int?)reader.GetInt32(5), reader.GetString(4), null));
                    }
                }
            }

            return tariffs;
        }
    }
}
