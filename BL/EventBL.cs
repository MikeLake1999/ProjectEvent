using System;
using Persistence;
using DAL;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BL
{
    public class EventBL
    {

        private EventDAL edal = new EventDAL();

        public Event GetById(int eventId)
        {
            return edal.GetById(eventId);
        }

        public int AddEvent(Event e)
        {
            return edal.AddEvent(e) ?? 0;
        }
    
        public List<Event> GetAllEvent()
        {
            return edal.GetAllEvent();
        }
    }
}
