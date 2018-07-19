using System;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Persistence;
using System.Threading.Tasks;

namespace DAL
{
    public class EventDetails
    {
        //private string query;
        private MySqlConnection connection = DbConfiguration.OpenConnection();
        private MySqlDataReader reader;

        public List<Invited> GetAllEventDetails()
        {
            List<Invited> ev = new List<Invited>();
            Invited c = new Invited();
            
            string query = "select * from EventDetailsDB, UserDB, EventDB Where EventDetailsDB.user_id = UserDB.user_id and EventDetailsDB.event_id = EventDB.event_id;";
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand cmd = new MySqlCommand(query, connection);
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    
                    ev.Add(GetInvited(reader));
                }
                reader.Close();
            }
            connection.Close();
            return ev;
        }

        private Invited GetInvited(MySqlDataReader reader)
        {
            Invited c = new Invited();
            c.EventDetails_EventID = reader.GetInt32("event_id");
            c.EventDetails_UserID = reader.GetInt32("user_id");
            c.Status = reader.GetString("event_status");
            c.events = new Event();
            c.events.Name_Event = reader.GetString("event_name");
            c.events.Address_Event = reader.GetString("address");
            c.events.Description = reader.GetString("description");
            c.events.Time = reader.GetString("event_time");
            c.users = new User();
            c.users.Name = reader.GetString("name_user");
            c.users.Phone = reader.GetString("phone_number");
            c.users.Email = reader.GetString("Email");
            return c;
        }

        

        public int? AddEventDetails(Invited c)
        {
            int? result = null;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand cmd = new MySqlCommand("insert into EventDetailsDB (event_id, user_id, event_status) values (@Event_ID, @User_ID, 'Chua Biet');", connection);
            try
            {
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Event_ID", c.EventDetails_EventID);

                cmd.Parameters.AddWithValue("@User_ID", c.EventDetails_UserID);


                result = cmd.ExecuteNonQuery();

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

        public int? UpdateEventDetails(Invited c)
        {
            int? result = null;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand cmd = new MySqlCommand("update EventDetailsDB set event_status = 'Khong Tham Gia' where event_id = @EventDetails_ID;", connection);
            try
            {
                cmd.Parameters.AddWithValue("@EventDetails_ID", c.EventDetails_EventID);

                result = cmd.ExecuteNonQuery();

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

        public int? UpdateEventDetailss(Invited c)
        {
            int? result = null;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand cmd = new MySqlCommand("update EventDetailsDB set event_status = 'Tham Gia' where event_id = @EventDetails_ID;", connection);
            try
            {
                cmd.Parameters.AddWithValue("@EventDetails_ID", c.EventDetails_EventID);

                result = cmd.ExecuteNonQuery();

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

        public int? UpdateEventDetailsss(Invited c)
        {
            int? result = null;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand cmd = new MySqlCommand("update EventDetailsDB set event_status = 'Se Tham Gia' where event_id = @EventDetails_ID;", connection);
            try
            {
                cmd.Parameters.AddWithValue("@EventDetails_ID", c.EventDetails_EventID);

                result = cmd.ExecuteNonQuery();

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
