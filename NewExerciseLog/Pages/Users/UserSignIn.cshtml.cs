using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using NewExerciseLog.UI.Models;
using System.Reflection.Metadata;

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
            //DBHelper.setId(calculateID());
            return RedirectToPage("HomePage");
            
        }

        /*public int calculateID()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
                    string sql = "SELECT UserId FROM User WHERE UserName = @userName";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@authorId", SignInUser.UserName);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int ID = Int32.Parse(reader["UserId"].ToString());
                        return ID;
                    }
                }
            }
            return 0;
        }*/
        
    }
}
