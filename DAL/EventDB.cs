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
        public Event GetById(int? eventId)
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

        internal Event GetById(int? eventId, MySqlConnection connection)
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
                cmd.Parameters.AddWithValue("@eventName", c.Name_Event);
                cmd.Parameters["@eventName"].Direction = System.Data.ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@eventAddress", c.Address_Event);
                cmd.Parameters["@eventAddress"].Direction = System.Data.ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@eventDescription", c.Description);
                cmd.Parameters["@eventDescription"].Direction = System.Data.ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@eventTime", c.Time);
                cmd.Parameters["@eventTime"].Direction = System.Data.ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@eventId", MySqlDbType.Int32);
                cmd.Parameters["@eventId"].Direction = System.Data.ParameterDirection.Output;
                
                result = cmd.ExecuteNonQuery();
                result = (int)cmd.Parameters["@eventId"].Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}