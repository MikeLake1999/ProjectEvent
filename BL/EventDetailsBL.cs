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
    
        public List<Invited> GetAllEvent()
        {
            return edal.GetAllEventDetails();
        }
    }
}