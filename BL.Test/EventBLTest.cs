using System;
using Xunit;
using BL;
using MySql.Data.MySqlClient;
using Persistence;
using System.Collections.Generic;


namespace BL.test
{
    public class EventBLTest
    {
        EventBL ubl = new EventBL();
        
        
        [Fact]
        public void GetAllEvent_test()
        {
            List<Event> listEvent = ubl.GetAllEvent();
            Assert.NotNull(listEvent);
        }
        
    }
}