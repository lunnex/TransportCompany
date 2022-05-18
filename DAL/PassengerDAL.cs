using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PassengerDAL : IPassengerDAL
    {
        private readonly string _connectoinString;

        public PassengerDAL(string connectoinString)
        {
            _connectoinString = connectoinString;
        }

        public Passenger Get(string phoneNumber)
        {
            Passenger passenger = null;

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetPassenger";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@phoneNumber", System.Data.SqlDbType.NVarChar).Value = phoneNumber;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    passenger = new Passenger(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDateTime(5));
                }

            }
            return passenger;
        }

        public void Add(Passenger passenger)
        {
            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddPassenger";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@phoneNumber", System.Data.SqlDbType.NVarChar).Value = passenger.PhoneNumber;
                command.Parameters.Add("@pass", System.Data.SqlDbType.NVarChar).Value = Passenger.HashPass(passenger.Password);
                command.Parameters.Add("@firstname", System.Data.SqlDbType.NVarChar).Value = passenger.FirstName;
                command.Parameters.Add("@secondname", System.Data.SqlDbType.NVarChar).Value = passenger.SecondName;
                command.Parameters.Add("@patronym", System.Data.SqlDbType.NVarChar).Value = passenger.Patronym;
                command.Parameters.Add("@birth", System.Data.SqlDbType.DateTime).Value = passenger.BirthDate;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
