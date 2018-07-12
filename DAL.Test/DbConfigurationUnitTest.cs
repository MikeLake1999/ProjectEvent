using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;

namespace DAL.Test
{
    public class DbConfiguratonTest
    {

        [Theory]
        [InlineData("server=localhost;user id=EventUser;password=123456789;port=3306;database=EventDB;SslMode=None")]
        public void OpenConnectionWithStringTest(string connectionString)
        {
            Assert.NotNull(DbConfiguration.OpenConnection(connectionString));
        }

        [Theory]
        [InlineData("server=localhost1;user id=EventUser;password=123456789;port=3306;database=EventDB;SslMode=None")]
        [InlineData("server=localhost;user id=EventUser321;password=123456789;port=3306;database=EventDB;SslMode=None")]
        [InlineData("server=localhost;user id=EventUser;password=123456789123;port=3306;database=EventDB;SslMode=None")]
        [InlineData("server=localhost;user id=EventUser;password=123456789;port=3307;database=EventDB;SslMode=None")]
        [InlineData("server=localhost;user id=EventUser;password=123456789;port=3306;database=EventDB123;SslMode=None")]
        [InlineData("server=localhost;user id=EventUser;password=123456789;port=3306;database=EventDB;SslMode=Non")]
        [InlineData("server=localhost;user id=EventUser;password=123456789;port=3306;database=EventDB")]
        public void OpenConnectionWithStringFailTest(string connectionString)
        {
            Assert.Null(DbConfiguration.OpenConnection(connectionString));
        }

        [Fact]
        public void OpenDefaultConnectionTest()
        {
            Assert.NotNull(DbConfiguration.OpenDefaultConnection());
        }

        [Fact]
        public void OpenConnectionTest()
        {
            Assert.NotNull(DbConfiguration.OpenConnection());
        }
    }
}
