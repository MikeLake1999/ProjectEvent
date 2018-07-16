using System;
using Xunit;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using DAL;
using Persistence;

namespace DAL.Test
{
    public class EventDetailsTest
    {
        private EventDetails eventDal = new EventDetails();
        
        [Theory]
        [InlineData(1, 1, "Nothing")]
        public void AddEventDetailsTest(int? events_id, int? users_id, string statuss)
        {
            Invited c = new Invited{EventDetails_EventID=events_id, EventDetails_UserID=users_id, Status=statuss};
            int? result = eventDal.AddEventDetails(c);
            Assert.NotNull(result);
            Assert.True((result??0) > 0);
        }


        [Fact]
        public void GetAllEvent_test()
        {
            List<Invited> listEvent = eventDal.GetAllEventDetails();
            Assert.NotNull(listEvent);
        }

    }
}