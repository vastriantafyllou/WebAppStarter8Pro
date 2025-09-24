using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppStarter.Pages.Students;

public class Success : PageModel
{
    public string? StudentName { get; set; }
    public string? CityId { get; set; }
    
    public void OnGet()
    {
        StudentName = TempData["StudentName"] as string;
        CityId = TempData["CityId"]?.ToString();
    }
}