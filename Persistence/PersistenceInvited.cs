using System;

namespace Persistence

{
    public class Invited
    {
        public int? EventDetails_EventID {set;get;}

        public int? EventDetails_UserID {set;get;}
        public string Status {set;get;}

        public Event events{set;get;}
        public User users {set;get;}
    }
}