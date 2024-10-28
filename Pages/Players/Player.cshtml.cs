using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using League.Models;
using League.Data;

namespace League.Pages.Players
{
  public class PlayerModel : PageModel
  {
    // inject the Entity Framework context

    private readonly LeagueContext _context;

    public PlayerModel(LeagueContext context)
    {
      _context = context;
    }

    // load a single player based on Id

    public Player Player { get; set; }

    public async Task<IActionResult> OnGetAsync(string Id)
    {
      Player = await _context.Players.FirstOrDefaultAsync(x => x.PlayerId == Id);
      if (Player == null) {
        return NotFound();
      }
      return Page();
    }


  }
}