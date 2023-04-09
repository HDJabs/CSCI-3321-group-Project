using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using NewExerciseLog.UI.Models;
using System.Reflection.Metadata;

namespace NewExerciseLog.UI.Pages.ExerciseGoals
{
    public class UpdateExerciseGoalsModel : PageModel
    {
		
        public static ExerciseGoal Goal { get; set; } = new ExerciseGoal();

		public List<ExerciseGoal> Goals { get; set; } = new List<ExerciseGoal>();
		[BindProperty]
		public int Hours { get; set; } 
		[BindProperty]
		public int Minutes { get; set; }
      
        public void OnGet(int id, int exerciseGoalId)
        {
			LoadGoal(id, exerciseGoalId);
			Hours = Int32.Parse(Goal.Goal.Substring(0, 2));
			Minutes = Int32.Parse(Goal.Goal.Substring(3, 2));




		}

		public void LoadGoal(int id, int exerciseGoalId)
		{
			Goal.ExerciseGoalId = exerciseGoalId;
			Goal.UserId = id;
			using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
			{
				string sql = "SELECT * FROM ExerciseGoal " +
				"INNER JOIN Exercise ON ExerciseGoal.ExerciseId = Exercise.ExerciseId " +
			   "WHERE ExerciseGoalId=@exerciseGoalId ;";
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@exerciseGoalId", exerciseGoalId);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					reader.Read();
					Goal.ExerciseName = reader["ExerciseName"].ToString();
					Goal.ExerciseId = (int)reader["ExerciseId"];
					Goal.UserId = (int)reader["UserId"];
					Goal.Goal = reader["Goal"].ToString();
					Goals.Add(Goal);
				}

			}
		}

		public String GoalString()
		{
			var goalstring = "";
			if (Hours < 10)
			{
				goalstring += "0";
			}
			goalstring += Hours + ":";

			if (Minutes < 10)
			{
				goalstring += "0";
			}
			goalstring += Minutes;
			return goalstring;
		}

		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
				{
					// step 1
					// step 2
					string sql = "UPDATE ExerciseGoal " +
						"SET Goal=@goal " +
						"WHERE ExerciseGoalId=@exerciseGoalId;";
					// step 3
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.AddWithValue("@goal", GoalString());
					cmd.Parameters.AddWithValue("@exerciseGoalId", Goal.ExerciseGoalId );
					
					conn.Open();
					cmd.ExecuteNonQuery();
				}



				return RedirectToPage("/Users/HomePage", new { id = Goal.UserId.ToString() });
			}
			return RedirectToPage("UpdateExerciseGoals", new {id = Goal.UserId.ToString(), exerciseGoalId = Goal.ExerciseGoalId.ToString() });
			//return Redirect("UpdateExerciseGoals?id=" + ID );

		}

       
    }
}
