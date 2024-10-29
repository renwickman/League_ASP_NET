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

    //private readonly ILogger _logger;

    public PlayerModel(LeagueContext context)
    {
      _context = context;
      //_logger = logger;
    }

    // load a single player based on Id

    public Player Player { get; set; }

    public async Task<IActionResult> OnGetAsync(string Id)
    {
            try
            {
                var temp_player = await _context.Players.FirstOrDefaultAsync(x => x.PlayerId == Id);

                if (temp_player == null)
                {
                    return NotFound();

                }
                Player = temp_player;

                return Page();

            }
            catch (Exception ex)

            {
                return NotFound();
            }
            finally
            {
                Console.WriteLine($"{Player.PlayerId}");

            }
        }


  }
}