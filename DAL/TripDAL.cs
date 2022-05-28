using Entities;
using Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class TripDAL : ITripDAL
    {
        private readonly string _connectoinString;

        public TripDAL(string connectoinString)
        {
            _connectoinString = connectoinString;
        }

        public Trip Get(int idTrip)
        {
            Trip trip = null;

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetTrip";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@idTrip", System.Data.SqlDbType.Int).Value = idTrip;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    trip = new Trip(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.IsDBNull(4) ? null : reader.GetInt32(4));
                }
            }

            return trip;
        }

        public List<Trip> GetAll(string idPassenger)
        {
            List<Trip> trips = new List<Trip>();

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetAllTrip";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@idPassenger", System.Data.SqlDbType.Int).Value = idPassenger;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    trips.Add(new Trip(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.IsDBNull(4) ? null : reader.GetInt32(5)));
                }
            }

            return trips;
        }

        public List<TripViewModel> GetAllView(string idPassenger)
        {
            List<TripViewModel> trips = new List<TripViewModel>();

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetTripsView";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@idPassenger", System.Data.SqlDbType.NVarChar).Value = idPassenger;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    trips.Add(new TripViewModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.IsDBNull(8) ? null : reader.GetInt32(8)));
                }
            }

            return trips;
        }
    }
}
