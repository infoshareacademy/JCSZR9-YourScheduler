using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using YourScheduler.BusinessLogic.Models;

namespace YourScheduler.WebApplication.Models
{
    public class UserModel
    {
        // public virtual DbSet<UserModel> Users { get; set; }
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Displayname { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

       
    }
}
