using System;
using Xunit;
using DAL;
using Persistence;
using System.Collections.Generic;
namespace DAL.Test
{
    public class UserUnitTest
    {
        private UserDB userDAL = new UserDB();


        [Fact]
        public void LoginTest1()
        {
            string username = "manager";
            string password = "123456";
            User user = userDAL.Login(username, password);

            Assert.NotNull(user);
            Assert.Equal(username, user.User_Name);
        }

        [Fact]
        public void LoginTest2()
        {
            string username = "staff";
            string password = "123456";
            User user = userDAL.Login(username, password);

            Assert.NotNull(user);
            Assert.Equal(username, user.User_Name);
        }


        [Fact]
        public void LoginTest4()
        {
            Assert.Null(userDAL.Login("'?^%'", "'.:=='"));
        }

        [Fact]
        public void GetAllUser_test()
        {
            List<User> listUser = userDAL.GetAllUser();
            Assert.NotNull(listUser);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetUserNameTest(int? id)
        {
            User result = userDAL.GetByID(id);
            Assert.NotNull(result);
        }
    }
}