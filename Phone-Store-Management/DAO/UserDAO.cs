using Phone_Store_Management.Entities;
using Phone_Store_Management.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.DAO
{
    public class UserDAO : IDao<User>
    {
        public void Add(User t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    db.Users.Add(t);
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Add() is error" + "\n" + e.Message);
                log.Show();
            }
        }

        public void Delete(User t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    var del = (from p in db.Users
                               where p.Id == t.Id
                               select p).Single();
                    if (del != null)
                    {
                        db.Users.Remove(del);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Delete() is error" + "\n" + e.Message);
                log.Show();
            }
        }

        public User Get(int id)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    return db.Users.Find(id);
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Get() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;
        }

        public List<User> GetAll()
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    return db.Users.ToList();
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " GetAll() is error" + "\n" + e.Message);
                log.Show();
            }
            return null;
        }

        public void Update(User t)
        {
            try
            {
                using (var db = new DBStoreManagementEntities())
                {
                    var user = db.Users.Find(t.Id);
                    user.DisplayName = t.DisplayName;
                    user.RoleId = t.RoleId;
                    user.UserName = t.UserName;
                    user.Password = t.Password;
                    user.IdentityCard = t.IdentityCard;
                    user.Birthdate = t.Birthdate;
                    user.Address = t.Address;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " Update() is error" + "\n" + e.Message);
                log.Show();
            }
        }


        /// <summary>
        /// Return user RoleId.
        /// If not found, return -1
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns>RoleId</returns>
        public int GetUserRole(string UserName, string Password)
        {
            try
            {
                var db = new DBStoreManagementEntities();
                foreach (var user in db.Users)
                {

                    if (UserName.Equals(user.UserName.Replace(" ", string.Empty))
                        && Password.Equals(user.Password.Replace(" ", string.Empty)))
                    {
                        return user.Role.RoleId;
                    }
                }

            }
            catch (Exception e)
            {
                var log = new LogError(GetType().Name + " GetAll() is error" + "\n" + e.Message);
                log.Show();
            }

            return -1;
        }
    }
}
