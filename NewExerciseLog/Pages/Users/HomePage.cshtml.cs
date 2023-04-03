using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata;
using Microsoft.Data.SqlClient;
using NewExerciseLog.UI.Models;


namespace NewExerciseLog.UI.Pages.Users
{
    public class HomePageModel : PageModel
    {
        public List<ExerciseGoal> goals { get; set; } = new List<ExerciseGoal>();

        public void OnGet()
        {
            string sql = "SELECT ExerciseName, Goal, Total       " +
               "FROM ExerciseGoal INNER JOIN Exercise ON ExerciseGoal.ExerciseId = Exercise.ExerciseId;";
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ExerciseGoal goal = new ExerciseGoal();
                        goal.Goal = reader["Goal"].ToString();
                        goal.ExerciseName = reader["ExerciseName"].ToString();
                        goal.Total = reader["Total"].ToString();
                        goals.Add(goal);
                    }
                }
            }
        }
    }
}
