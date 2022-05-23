using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tally.Bootswatch.Models;

namespace Tally.Bootswatch.UI.Pages;

public class ThemesModel : PageModel
{
    [BindProperty] 
    public ThemeData ThemeData { get; private set; } = null!;
    
    public async Task OnGetAsync()
    {
        var client = new BootswatchClient();
        ThemeData = await client.GetThemesAsync(version: 5);
    }
}
