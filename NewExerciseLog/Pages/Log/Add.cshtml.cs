using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewExerciseLog.UI.Models;

namespace NewExerciseLog.UI.Pages.Log
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Entry NewEntry { get; set; } = new Entry();
		public void OnGet()
        {
        }
    }
}
