using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewExerciseLog.UI.Models;

namespace NewExerciseLog.UI.Pages.Users
{
    public class NewUserModel : PageModel
    {
        [BindProperty]
        public User NewUser { get; set; } = new User();
        public void OnGet()
        {
        }
    }
}


