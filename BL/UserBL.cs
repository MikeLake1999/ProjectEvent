using System;
using Persistence;
using DAL;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BL
{
    public class UserBL
    {

        private UserDB udal = new UserDB();
        public User Login(string username, string password)
        {
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionUsername = regex.Matches(username);
            MatchCollection matchCollectionPassword = regex.Matches(password);
            if (matchCollectionUsername.Count < username.Length || matchCollectionPassword.Count < password.Length)
            {
                return null;
            }
            return udal.Login(username, password);
        }

        public User GetById(int userId)
        {
            return udal.GetByID(userId);
        }

        public List<User> GetAllUser()
        {
            return udal.GetAllUser();
        }
    }
}
