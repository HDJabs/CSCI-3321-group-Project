using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewExerciseLog.UI.Models;

namespace NewExerciseLog.UI.Pages.Entries
{
    public class AddEntryModel : PageModel
    {
        [BindProperty]
        public Entry NewEntry { get; set; } = new Entry();
        public void OnGet()
        {
        }
    }
}
