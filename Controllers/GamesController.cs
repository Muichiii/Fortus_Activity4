using Microsoft.AspNetCore.Mvc;
using Fortus_Activity4.Models;
using Fortus_Activity4.Data;
using Fortus_Activity4.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fortus_Activity4.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public GamesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGameViewModel viewModel)
        {
            var game = new Game
            {
                Title = viewModel.Title,
                Genre = viewModel.Genre,
                Device = viewModel.Device
            };

            await dbContext.Games.AddAsync(game);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> List()
        {
            var games = await dbContext.Games.ToListAsync();
            return View(games);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
            var game = await dbContext.Games.FindAsync(id);

            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game viewModel)
        {
            var Game = await dbContext.Games.FindAsync(viewModel.Id);

            if (Game != null)
            {
                Game.Title = viewModel.Title;
                Game.Genre = viewModel.Genre;
                Game.Device = viewModel.Device;
                await dbContext.SaveChangesAsync();

            }
            return RedirectToAction("List", "Games");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Game viewModel)
        {
            var game = await dbContext.Games.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (game != null)
            {
                dbContext.Games.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Games");
        }

    }
}
