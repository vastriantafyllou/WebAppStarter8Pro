using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppStarter.DTO;
using WebAppStarter.Models;

namespace WebAppStarter.Pages.Students;

public class Insert : PageModel
{   
    [BindProperty]
    public InsertStudentDTO? InsertStudentDTO { get; set; }
    
    public SelectList Cities { get; set; } = new SelectList(new List<City>
    {
        new() {Id = 1, Name = "Αθήνα"},
        new() {Id = 2, Name = "Πάτρα"},
        new() {Id = 3, Name = "Ηράκλειο"},
        new() {Id = 4, Name = "Ναύπλιο"}
    }.OrderBy(c => c.Name), nameof(City.Id), nameof(City.Name));
    
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        TempData["StudentName"] = $"{InsertStudentDTO?.Firstname} {InsertStudentDTO?.Lastname}";
        TempData["CityId"] = InsertStudentDTO!.SelectedCityId;
        
        // PRG pattern Post-Request-Get
        return RedirectToPage("/Students/Success");
    }
}