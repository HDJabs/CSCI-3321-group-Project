using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.Data.SqlClient;
using NewExerciseLog.UI.Models;
using NewExerciseLog.UI.Pages.Users;
using System.Collections.Generic;

//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewExerciseLog.UI.Pages.Entries
{
    public class AddEntryModel : PageModel
    {
        [BindProperty]
        public Entry NewEntry { get; set; } = new Entry();


        public User currentUser { get; set; } = new User();
        [BindProperty]
        public List<SelectListItem> exercises { get; set; } = new List<SelectListItem>();

        public static User copyUser;

        [BindProperty]
        public int exeId { get; set; }
        public void OnGet(int id)
        {
            //find the user using the id
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString())) {
                string sql = "SELECT UserFirstName, UserName, UserId FROM [User] WHERE UserId = @userId;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows && reader.Read())
                { 
                    currentUser.FirstName = reader["UserFirstName"].ToString();
                    currentUser.UserName = reader["UserName"].ToString();
                    currentUser.UserId = (int)reader["UserId"];
                    copyUser = currentUser;
                }
            }

            //populate list of exercises 
            // i need the name and id for the <select>

            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "SELECT ExerciseName, Exercise.ExerciseId FROM ExerciseGoal " +
                    "INNER JOIN Exercise ON ExerciseGoal.ExerciseId = Exercise.ExerciseId " +
                    "WHERE UserId = @userId;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read()) {
                        SelectListItem item = new SelectListItem();
                        item.Text= reader["ExerciseName"].ToString();
                        item.Value = reader["ExerciseId"].ToString();
                        exercises.Add(item);
                    }
                }
            }

        }

        public IActionResult OnPost(int id, int exerciseId)
        {

            NewEntry.ExerciseId = Int32.Parse(Request.Form["exercise"]);

            

            //find exercise goalID for NewEntry using exercise id and user id
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                
                
                string sql = "SELECT ExerciseGoalId FROM ExerciseGoal " +
                    "WHERE UserId = @userId AND ExerciseId = @exerciseId;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", id);
                cmd.Parameters.AddWithValue("@ExerciseId", NewEntry.ExerciseId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NewEntry.ExerciseGoalId = (int)reader["ExerciseGoalId"];
                    }
                }
            }



            //insert
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                // step 1
                // step 2
                string sql = "INSERT INTO Entry (ExerciseGoalId, EntryDate, HoursExercised, MinutesExercised) " +
                    "VALUES (@exerciseGoalId, @entryDate, @hoursExercised, @minutesExercised);";
                // step 3
                SqlCommand cmd = new SqlCommand(sql, conn);
                DateTime date = DateTime.Now;
                cmd.Parameters.AddWithValue("@exerciseGoalId", NewEntry.ExerciseGoalId);
                cmd.Parameters.AddWithValue("@entryDate", NewEntry.EntryDate);
                cmd.Parameters.AddWithValue("@hoursExercised", NewEntry.HoursExercised);
                cmd.Parameters.AddWithValue("@minutesExercised", NewEntry.MinutesExercised);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            //update goals
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                //get old total
                string sql1 = "SELECT Total FROM ExerciseGoal WHERE USERID = @userId AND ExerciseId = @exerciseId;";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@userId", id);
                cmd1.Parameters.AddWithValue("@ExerciseId", NewEntry.ExerciseId);

                //update total
                string sql2 = "UPDATE ExerciseGoal SET Total = @newTotal WHERE USERID = @userId AND ExerciseId = @exerciseId;";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@userId", id);
                cmd2.Parameters.AddWithValue("@ExerciseId", NewEntry.ExerciseId);


                conn.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                String[] hourMinute = (reader.HasRows && reader.Read() ? ((String)reader["Total"]).Split(":") :new String[2]{ "0", "0" });
                conn.Close();
                
                int[] intHoutMinute = { int.Parse(hourMinute[0]), int.Parse(hourMinute[1])};
                intHoutMinute[1] += NewEntry.MinutesExercised;
                intHoutMinute[0] += NewEntry.HoursExercised + (int)Math.Floor(intHoutMinute[1] / 60.0);
                intHoutMinute[1] = intHoutMinute[1] % 60;
                intHoutMinute[0] = intHoutMinute[0] % 100;

                cmd2.Parameters.AddWithValue("@newTotal", (intHoutMinute[0] < 10 ? "0" + intHoutMinute[0] : intHoutMinute[0]) + ":" + (intHoutMinute[1] < 10 ? "0" + intHoutMinute[1] : intHoutMinute[1]));

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
            }


                //if (!ModelState.IsValid){
                return RedirectToPage("/Users/HomePage", new { id = id });
            //}
            //return RedirectToPage("/Users/HomePageModel", new {id = copyUser.UserId});
        }
    }
}
                                     
                
        