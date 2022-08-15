using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameManager.Models;
using Game = GameManager.Models.Game;

namespace GameManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly EFTodoDBContext _context;

        public GameController(EFTodoDBContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Game>>> GetGame(int id)
        {
            try
            {
                var dbGame = await _context.Games.FindAsync(id);
                if (dbGame == null)
                    return BadRequest("Task not found.");
                return Ok(await _context.Games.ToListAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            try
            {
                return Ok(await _context.Games.ToListAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Game>>> CreateTask(Game game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _context.Games.Add(game);
                await _context.SaveChangesAsync();
                return Ok(await _context.Games.ToListAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<List<Game>>> UpdateTask(Game game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var dbGame = await _context.Games.FindAsync(game.Id);
                if (dbGame == null)
                    return BadRequest("Task not found.");

                dbGame.Name = game.Name;
                dbGame.Developer = game.Developer;
                dbGame.ReleaseDate = game.ReleaseDate;
                dbGame.Platform = game.Platform;

                await _context.SaveChangesAsync();

                return Ok(await _context.Games.ToListAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Game>>> DeleteGame(int id)
        {
            try
            {
                var dbGame = await _context.Games.FindAsync(id);
                if (dbGame == null)
                    return BadRequest("Task not found.");

                _context.Games.Remove(dbGame);
                await _context.SaveChangesAsync();
                return Ok(await _context.Games.ToListAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}