using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerVehicle.DAL
{
    public class Repositorys
    {
        public static List<User> users = new List<User>() {

        new User() {Email="uma.kanth.2912@gmail.com",Roles="Admin,Editor",Password="@Uma123" },
        new User() {Email="umakanth246@gmail.com",Roles="Editor",Password="@Uma123" }

            };
        public static User GetUserDetails(User user)
        {

            return users.Where(u => u.Email.ToLower() == user.Email.ToLower() && u.Password == user.Password).FirstOrDefault();
        }
    }
}