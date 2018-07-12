using System;
using Xunit;
using BL;
using MySql.Data.MySqlClient;
using Persistence;
using System.Collections.Generic;


namespace BL.test
{
    public class UserBLTest
    {
        UserBL ubl = new UserBL();
        
        
        [Fact]
        public void GetAllUser_test()
        {
            List<User> listUser = ubl.GetAllUser();
            Assert.NotNull(listUser);
        }
        
    }
}