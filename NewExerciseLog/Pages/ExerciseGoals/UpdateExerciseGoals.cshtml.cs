using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using NewExerciseLog.UI.Models;
using System.Reflection.Metadata;

namespace NewExerciseLog.UI.Pages.ExerciseGoals
{
    public class UpdateExerciseGoalsModel : PageModel
    {
        [BindProperty]
        public List<ExerciseGoal> Goals { get; set; } = new List<ExerciseGoal>();


        public string runUpdate { get; set; } = "UPDATE ExerciseGoal SET Goal='13:34' WHERE ExerciseId=2 AND UserId=1;";
       
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            //if (ModelState.IsValid && runUpdate.ToString()!="")
            //{ //Goals.Add(runGoal);
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
                    string sql = runUpdate;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    
                }
                return RedirectToPage("/Users/HomePage");
                
            //}
            return Page();
        }
    }
}
