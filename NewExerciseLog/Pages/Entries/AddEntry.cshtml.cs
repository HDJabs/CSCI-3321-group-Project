using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using NewExerciseLog.UI.Models;

//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewExerciseLog.UI.Pages.Entries
{
    public class AddEntryModel : PageModel
    {
        [BindProperty]
        public Entry NewEntry { get; set; } = new Entry();
       /* public void OnGet()
        {
        }
       */
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                /*  
                 * 1. Create a SQL connection object
                 * 2. Construct a SQL statement
                 * 3. Create a SQL command object
                 * 4. Open the SQL connection
                 * 5. Execute the SQL command
                 * 6. Close the SQL connection
                 */

                // step 1
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
                   
                   // step 2
                   string sql = "INSERT INTO [User] (Date, Exercise, Durrationhours, Durrationminutes) " +
                        "VALUES (@date, @exercise, @durrationhours, @durrationminutes);";
                    
                    // step 3
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    DateTime date = DateTime.Now;
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@exercise", NewEntry.ExerciseGoal.Exercise);
                    cmd.Parameters.AddWithValue("@durrationhours", NewEntry.HoursExercised);
                    cmd.Parameters.AddWithValue("@durrationminutes", NewEntry.MinutesExercised);

                    // step 4
                    conn.Open();

                    // step 5
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewEntries");
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
                                     
                
        