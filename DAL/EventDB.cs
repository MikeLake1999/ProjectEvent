using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class EventDAL
    {
        private string query;
        private MySqlConnection connection = DbConfiguration.OpenConnection();
        private MySqlDataReader reader;

         public List<Event> GetAllEvent()
        {
            List<Event> ev = new List<Event>();
            string  query = "Select event_id, event_name, address, description, event_time from EventDB;";
            if(connection.State == System.Data.ConnectionState.Closed){
                connection.Open();
            }
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using(reader = cmd.ExecuteReader())
                {
                
                    while(reader.Read())
                    {
                        ev.Add(GetEvent(reader));
                    }
                    reader.Close();
                }
            connection.Close();
            return ev;
        }
        public Event GetById(int eventId)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select event_id, event_name, description, event_time, address
                        from EventDB where event_id=" + eventId + ";";
            reader = (new MySqlCommand(query, connection)).ExecuteReader();
            Event c = null;
            if (reader.Read())
            {
                c = GetEvent(reader);
            }
            reader.Close();
            connection.Close();
            return c;
        }

        internal Event GetById(int eventId, MySqlConnection connection)
        {
            query = @"select event_id, event_name, description, event_time, address
                        from EventDB where event_id=" + eventId + ";";
            Event c = null;
            reader = (new MySqlCommand(query, connection)).ExecuteReader();
            if (reader.Read())
            {
                c = GetEvent(reader);
            }
            reader.Close();
            connection.Close();
            return c;
        }
        private Event GetEvent(MySqlDataReader reader)
        {
            Event c = new Event();
            c.ID_Event = reader.GetInt32("event_id");
            c.Name_Event = reader.GetString("event_name");
            c.Address_Event = reader.GetString("address");
            c.Description = reader.GetString("description");
            c.Time = reader.GetString("event_time");
            return c;
        }

        public int? AddEvent(Event c)
        {
            int? result = null;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand cmd = new MySqlCommand("sp_createEvent", connection);
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@event_Name", c.Name_Event);
                cmd.Parameters["@event_Name"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@Address", c.Address_Event);
                cmd.Parameters["@Address"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@Description", c.Description);
                cmd.Parameters["@Description"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@Event_Time", c.Time);
                cmd.Parameters["@Event_Time"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@event_Id", MySqlDbType.Int32);
                cmd.Parameters["@event_Id"].Direction = System.Data.ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = (int)cmd.Parameters["@event_Id"].Value;
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}