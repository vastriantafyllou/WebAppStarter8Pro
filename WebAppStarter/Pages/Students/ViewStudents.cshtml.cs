using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using WebAppStarter.DTO;

namespace WebAppStarter.Pages.Students;

public class ViewStudents : PageModel
{
    public List<StudentReadOnlyDTO> StudentsReadOnlyDTOs { get; set; } = [];

    private List<StudentReadOnlyDTO> GetAllStudents()
    {
        return new List<StudentReadOnlyDTO>
        {
            new StudentReadOnlyDTO(1, "Αθανάσιος", "Ανδρούτοσς"),
            new StudentReadOnlyDTO(2, "Γεώργιος", "Οικονόμου"),
            new StudentReadOnlyDTO(3, "Λαμπρινή", "Γεωργίου"),
        };
    }
    public IActionResult OnGet()
    {
        if (Request.Query.TryGetValue("lastname", out var lastname) && !string.IsNullOrEmpty(lastname))
        {
            var allStudents = GetAllStudents();
            StudentsReadOnlyDTOs = [..allStudents.Where(s => s.Lastname == lastname)];
            return Page();
        }
        StudentsReadOnlyDTOs = GetAllStudents();
        return Page();
    }
}