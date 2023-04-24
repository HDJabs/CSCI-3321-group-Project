using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using NewExerciseLog.UI.Models;

namespace NewExerciseLog.UI.Pages.ExerciseGoals
{
    public class NewModel : PageModel
    {
		[BindProperty]
        public static int userId { get; set; }
		[BindProperty]
		public int ID { get; set; }
		[BindProperty]
		public List<Exercise> exercises { get; set; } = new List<Exercise>();

		public void OnGet(int id)
        {
            userId = id;
			ID = id;
			//1. make list of all exercise IDs
			int[] exerciseIds = new int[30];

			string sql = "SELECT ExerciseId FROM Exercise;";
			using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
			{
				SqlCommand cmd = new SqlCommand(sql, conn);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					for(int index = 0; reader.Read(); index++)
					{
						exerciseIds[index] = (int)reader["ExerciseId"];
					}
					
				}
			}


			//2. make list of exercises that the user has a goal for 
			int[] userExerciseIds = new int[30];
			
			sql = "SELECT ExerciseId FROM ExerciseGoal " +
				"WHERE UserId=@userId;";
			using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
			{
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@userId", id);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					for (int index = 0; reader.Read(); index++)
					{
						userExerciseIds[index] = (int)reader["ExerciseId"];
					}

				}
			}

			//3 exerciseIds should be the difference. the exercises that the user doesnt have a goal for

			for(int i = 0; i < userExerciseIds.Length; i++)
			{
				for(int j = 0; j< exerciseIds.Length; j++) {
					if (exerciseIds[j]  == userExerciseIds[i])
					{
						exerciseIds[j] = 0;
					}
				}
			}
			for( int i = 0;i < exerciseIds.Length; i++)
			{
				sql = "SELECT ExerciseId, ExerciseName FROM Exercise " +
				"WHERE ExerciseId=@exerciseId;";
				using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
				{
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.AddWithValue("@exerciseId", exerciseIds[i]);
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader();
					if (reader.HasRows)
					{
						Exercise exercise = new Exercise();
						while(reader.Read())
						{
							exercise.ExerciseId = (int)reader["ExerciseId"];
							exercise.ExerciseName = reader["ExerciseName"].ToString();
						}
						exercises.Add(exercise);
					}
				}
			}
		}//end OnGet

		public IActionResult OnPost(int id, int exerciseId)
		{

			//updating the data base. adding a goal
			String sql = "INSERT INTO [ExerciseGoal] (ExerciseId, UserId, Goal, Total) " +
				"VALUES (@exerciseId, @userId, '00:00', '00:00');";
			using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
			{
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@exerciseId", exerciseId);
				cmd.Parameters.AddWithValue("@userId", id);
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
			}

			//searching for that goal to get the id
			sql = "Select ExerciseGoalId FROM [ExerciseGoal] WHERE UserId=" + id + " AND ExerciseId=" + exerciseId + ";";
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
				reader.Read();
				int exerciseGoalId = Int32.Parse(reader["ExerciseGoalId"].ToString());
                conn.Close();
                return RedirectToPage("/ExerciseGoals/UpdateExerciseGoals", new { id = id, exerciseGoalId = exerciseGoalId });
            }

            
		}

	}
}
