using System;
using Xunit;
using BL;
using MySql.Data.MySqlClient;
using Persistence;
using System.Collections.Generic;


namespace BL.test
{
    public class EventDetailsBLTest
    {
        EventDetailsBL ubl = new EventDetailsBL();
        
        
        [Fact]
        public void GetAllEventDetail_test()
        {
            List<Invited> listEvent = ubl.GetAllEvent();
            Assert.NotNull(listEvent);
        }
        
    }
}