using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewExerciseLog.UI.Models;

namespace NewExerciseLog.UI.Pages.ExerciseGoals
{
    public class NewExerciseGoalModel : PageModel
    {
		[BindProperty]
		public ExerciseGoal NewExerciseGoal{ get; set; } = new ExerciseGoal();
		public void OnGet()
        {
        }
    }
}
