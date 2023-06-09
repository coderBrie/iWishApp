using System;
using System.ComponentModel.DataAnnotations;

namespace iWishApp.Models
{
    public class Users
    {
        [Required(ErrorMessage = "UserName is Required")]
        [StringLength(50, MinimumLength = 3)]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "A Password is Required")]
        [StringLength(50, MinimumLength = 8)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [StringLength(50, MinimumLength = 8)]
        public string? Email { get; set; }
        public int Id { get; set; }
        public Users(string username, string password, string email) 
        { 
            UserName = username;
            Password = password;
            Email = email;
        }
        public Users()
        {

        }
    }
}
