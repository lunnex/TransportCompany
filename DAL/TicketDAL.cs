using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TicketDAL : ITicketDAL
    {
        private readonly string _connectoinString;

        public TicketDAL(string connectoinString)
        {
            _connectoinString = connectoinString;
        }

        public void Add(Ticket ticket)
        {
            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddTicket";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@passenger", System.Data.SqlDbType.NVarChar).Value = ticket.PhonePassenger;
                command.Parameters.Add("@tariff", System.Data.SqlDbType.Int).Value = ticket.IdTariff;
                command.Parameters.Add("@tariffZone", System.Data.SqlDbType.Int).Value = ticket.IdTariffZone;

                if(ticket.Expiration==null)
                {
                    command.Parameters.Add(new SqlParameter("@expiration", SqlInt32.Null));
                }
                else
                {
                    command.Parameters.Add("@expiration", System.Data.SqlDbType.Int).Value = ticket.Expiration;
                }

                if (ticket.TripRemains == null)
                {
                    command.Parameters.Add(new SqlParameter("@tripRemains", SqlInt32.Null));
                }
                else
                {
                    command.Parameters.Add("@tripRemains", System.Data.SqlDbType.Int).Value = ticket.TripRemains;
                }

                command.Parameters.Add("@purchaseTime", System.Data.SqlDbType.DateTime).Value = ticket.PurchaseTime;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Ticket Get(int phonePassenger)
        {
            Ticket ticket = null;

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddTicket";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@passenger", System.Data.SqlDbType.NVarChar).Value = phonePassenger;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if(reader[4] is DBNull)
                    {
                        ticket = new Ticket(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(6), null, reader.GetInt32(5));
                    }
                    else if(reader[5] is DBNull)
                    {
                        ticket = new Ticket(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(6), reader.GetDateTime(4), null);
                    }
                }
            }

            return ticket;
        }
    }
}
