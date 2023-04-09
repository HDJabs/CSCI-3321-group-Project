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
        public int ID { get; set; }

        private static int userId;

        public string UserName { get; set; }

        public void OnGet(int id)
        {
            userId = id;
            ID = id;
            string sql = "SELECT * FROM ExerciseGoal " +
                "INNER JOIN Exercise ON ExerciseGoal.ExerciseId = Exercise.ExerciseId " +
               "WHERE UserId=@UserId";
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@UserId", id);
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
                        goal.ExerciseId = (int)reader["ExerciseId"];
                        goal.ExerciseGoalId = (int)reader["ExerciseGoalId"];
                        goals.Add(goal);
                    }
                }
            }

			//find the name
			sql = "SELECT UserFirstName FROM [User] " +
			   "WHERE UserId=@UserId ;";
			using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
			{
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@UserId", id);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
                    reader.Read();
                    UserName = reader["UserFirstName"].ToString();
					
				}
			}
		}

        public IActionResult OnPost(int id, int exerciseGoalId)
        {
			using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
			{
				// step 1
				// step 2
				string sql = "DELETE FROM ExerciseGoal WHERE ExerciseGoalId=@exerciseGoalId;";
				// step 3
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@exerciseGoalId", exerciseGoalId);

				conn.Open();
				cmd.ExecuteNonQuery();
			}
			return RedirectToPage("HomePage", new { id = userId});
		}
       
    }
}
