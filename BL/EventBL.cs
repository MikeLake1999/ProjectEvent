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
    
        public List<Event> GetAllEvent()
        {
            return edal.GetAllEvent();
        }
    }
}
