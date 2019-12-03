using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevGames.Models;
using DevGames.Services;

namespace DevGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameService _gameService;

        public GamesController(GameService gameService)
        {
            _gameService = gameService;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<List<Games>>> Get()
        {
            return await _gameService.Get();
        }

        // GET: api/Games/5
        [HttpGet("{id}", Name = "GetGame")]
        public async Task<ActionResult<Games>> GetById(string id)
        {
            return await _gameService.GetById(id);
        }

        // POST: api/Games
        [HttpPost]
        public async Task<ActionResult<Games>> Create(Games game)
        {
            if (ModelState.IsValid)
            {
                await _gameService.Create(game);
                return CreatedAtRoute("GetGame", new { id = game.Id.ToString() }, game);
            }

            return BadRequest();
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
