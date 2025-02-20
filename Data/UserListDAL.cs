﻿using Capstone1.Interfaces;
using Capstone1.Models;

namespace Capstone1.Data
{
    public class UserListDAL : UDataAccessLayer
    {
        private AppDBContext db;

        public UserListDAL(AppDBContext indb)
        {
            db = indb;
        }

        public bool AddUser(UserModel u)
        {
            try
            {
                db.Add(u);
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void DeleteUser(int? id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(UserModel u)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserModel u)
        {
            throw new NotImplementedException();
        }
    }
}
