using System;

namespace Persistence

{
    public class Event
    {
        public int? ID_Event { set; get; }
        public string Name_Event { set; get; }
        public string Description { set; get; }
        public string Address_Event { set; get; }

        public string Time { set; get; }

        public Event() { }

        public override bool Equals(object obj)
        {
            if (obj is Event)
            {
                return ((Event)obj).ID_Event.Equals(ID_Event);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ID_Event.GetHashCode();
        }
    }
}