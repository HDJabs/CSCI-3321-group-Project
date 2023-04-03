using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewExerciseLog.UI.Pages.ExerciseGoals
{
    public class UpdateExerciseGoalModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Users/HomePage");
            return Page();
        }
    }
}
