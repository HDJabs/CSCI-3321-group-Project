using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewExerciseLog.UI.Models;
using System.Reflection.Metadata;

namespace NewExerciseLog.UI.Pages.Users
{
    public class UserSignInModel : PageModel
    {
        [BindProperty]
        public User SignInUser { get; set; } = new User();
        public void OnGet() { 
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("HomePage");
            
        }
    }
}
