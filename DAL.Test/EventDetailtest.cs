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
        
        // [Theory]
        // [InlineData(1, 1)]
        // public void AddEventDetailsTest(int? events_id, int? users_id)
        // {
        //     Invited c = new Invited{EventDetails_EventID=events_id, EventDetails_UserID=users_id};
        //     int? result = eventDal.AddEventDetails(c);
        //     Assert.NotNull(result);
        //     Assert.True((result??0) > 0);
        // }

        // [Theory]
        // [InlineData(1)]
        // public void UpdateEventDetailsTest(int? events_id)
        // {
        //     Invited c = new Invited{EventDetails_EventID= events_id};
        //     int? result = eventDal.UpdateEventDetails(c);
        //     Assert.NotNull(result);
        //     Assert.True((result??0) > 0);
        // }


        [Fact]
        public void GetAllEvent_test()
        {
            List<Invited> listEvent = eventDal.GetAllEventDetails();
            Assert.NotNull(listEvent);
        }

    }
}