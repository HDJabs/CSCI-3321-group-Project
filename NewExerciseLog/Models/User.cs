using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NewExerciseLog.UI.Models
{
    [BindProperties]
    public class User
	{
        [Key]
		public int UserId { get; set; }
        //[Required(ErrorMessage = "user ID is required")]
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        
        public string UserName { get; set; } = String.Empty;
        

		public string UserPasswordHash { get; set; } = String.Empty;
  

        public string? Salt { get; set; } = String.Empty;

        public DateTime? LastLogIn { get; set; } = new DateTime();

        public DateTime? DateJoined { get; set;} = new DateTime();

    }
}
