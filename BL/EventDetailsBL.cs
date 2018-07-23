using System;
using Persistence;
using DAL;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BL
{
    public class EventDetailsBL
    {

        private EventDetails edal = new EventDetails();



        public int AddEventDetails(Invited e)
        {
            return edal.AddEventDetails(e) ?? 0;
        }

         public int AddEventDetailss(Invited e)
        {
            return edal.AddEventDetailss(e) ?? 0;
        }

        public int UpdateEventDetails(Invited e)
        {
            return edal.UpdateEventDetails(e) ?? 0;
        }

        public int UpdateEventDetailss(Invited e)
        {
            return edal.UpdateEventDetailss(e) ?? 0;
        }

        public int UpdateEventDetailsss(Invited e)
        {
            return edal.UpdateEventDetailsss(e) ?? 0;
        }

        public List<Invited> GetAllEvent()
        {
            return edal.GetAllEventDetails();
        }
    }
}