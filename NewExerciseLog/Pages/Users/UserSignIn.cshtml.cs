using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using NewExerciseLog.UI.Models;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewExerciseLog.UI.Pages.Users
{
    public class UserSignInModel : PageModel
    {
        [BindProperty]
        public User SignInUser { get; set; } = new User();
        public void OnGet() { 
        }
        public IActionResult OnPost()
        {
            //1. validate
            //if (!ModelState.IsValid){return Page();}
			//2. find the user using the username
			using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
			{
				string sql = "SELECT UserId FROM [User] WHERE UserName = @userName;";
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@userName", SignInUser.UserName);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					reader.Read();
					SignInUser.UserId = Int32.Parse(reader["UserId"].ToString());
					
				}
                //2.5 if no user is found, return to page
                else { return Page(); }
			}
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "SELECT UserId FROM [User] WHERE UserName = @userName;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userName", SignInUser.UserName);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
               Function verifyPassword()
                {
                    var pw = SignInUser.UserId("pswd").value;
                }
                if (pw.length < 8)
                {
                    SignInUser.UserId("message") = "password length must be at least 8 characters";


                }
                //2.5 if no user is found, return to page
                else { return Page(); }
            }

            //this is were i write my code
            // this is my code 
            // anything with names(username or sign in user) subject to change. functions names that we did not write stays the same
            //select user password 
            //3. redirect using user id that was just found

            return RedirectToPage("HomePage", new { id = SignInUser.UserId });

		}

		

	}
}
