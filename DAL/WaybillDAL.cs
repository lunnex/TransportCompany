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
    public class WaybillDAL : IWaybillDAL
    {
        private readonly string _connectoinString;

        public WaybillDAL(string connectoinString)
        {
            _connectoinString = connectoinString;
        }

        public List<Waybill> GetWaybills()
        {
            List<Waybill> waybills = new List<Waybill>();

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetWaybills";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    waybills.Add(new Waybill(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4)));
                }

            }
            return waybills;
        }
    }
}
