using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tally.Web.Data;
using Tally.Web.Models;

namespace Tally.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ThemeController : ControllerBase
{
    private TallyContext _context;
    private readonly UserManager<User> _manager;

    public ThemeController(TallyContext context, UserManager<User> manager) => (_context, _manager) = (context, manager);

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] ThemeRequest request,
        [FromHeader(Name = "X-Tally-User-Id")] string userId
    )
    {
        if (request.User != userId) return BadRequest();

        var user = await _manager.FindByIdAsync(userId);
        if (user is null) return NotFound();
        
        // Stop here to ensure settings are loaded
        await _context.Entry(user).Reference(u => u.Settings).LoadAsync();

        var settings = user.Settings ??= new();
        settings.ThemeName = request.Name;
        settings.ThemeCdn = request.Cdn;
        await _manager.UpdateAsync(user);
        return Ok();
    }
}