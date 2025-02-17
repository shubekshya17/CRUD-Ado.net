using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetLab6.Pages
{
    public class CalculateModel : PageModel
    {
        public string title;
        [BindProperty]
        public int num1 {  get; set; }
        [BindProperty]
        public int num2 { get; set; }
        public int sum;
        public void OnGet()
        {
            title = "Hello Its me.";
        }
        public void OnPost()
        {
            sum = num1 + num2;
        }
    }
}
