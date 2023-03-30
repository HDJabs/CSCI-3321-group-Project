using System.ComponentModel.DataAnnotations;

namespace NewExerciseLog.UI.Models
{
	public class User
	{
		public int UsrId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

		public string UserName { get; set; }
		[Required(ErrorMessage = "Username is required")]

		public string UserPasswordHash { get; set; }

		public string salt { get; set; }

		public DateTime LastLogIn { get; set; }

		public DateTime DateJoined { get; set;}

    }
}
