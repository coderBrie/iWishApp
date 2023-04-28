using System;
using System.Security.Cryptography.X509Certificates;

namespace iWishApp.Models
{
    public class UserLogin
    { 
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }    
        public string Email { get; set; }

        public List<Affirmations> Favorites { get; set; }

        public UserLogin(string username, string password, string email) 
        { 
            UserName = username;
            Password = password;
            Email = email;
        }
    }
}
