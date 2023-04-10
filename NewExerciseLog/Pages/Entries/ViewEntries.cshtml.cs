using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using NewExerciseLog.UI.Models;

namespace NewExerciseLog.UI.Pages.Entries
{
    public class ViewEntriesModel : PageModel
    {
        [BindProperty]
        public List<Entry> Entries { get; set; } = new List<Entry>();

		public int ID { get; set; }

		public void OnGet(int id)
        {
			ID = id;
			//search database and populate the list with ExGoalId, EntDate, Hrs, Min.
			// also add to ExerciseName
			string sql = "SELECT * FROM [Entry] " +
				"INNER JOIN ExerciseGoal ON Entry.ExerciseGoalId = ExerciseGoal.ExerciseGoalId " +
				"INNER JOIN Exercise ON ExerciseGoal.ExerciseId = Exercise.ExerciseId " +
			   "WHERE ExerciseGoal.UserId=@userId;";

			using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
			{
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@userId", id);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						Entry entry = new Entry();

						entry.ExerciseGoalId = (int)reader["ExerciseGoalId"];
						entry.EntryDate = (DateTime)reader["EntryDate"];
						entry.HoursExercised = (int)reader["HoursExercised"];
						entry.MinutesExercised = (int)reader["MinutesExercised"];
						entry.ExerciseName = reader["ExerciseName"].ToString();
						Entries.Add(entry);
					}
				}
			}




		}
    }
}
