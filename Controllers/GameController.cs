using AutoMapper;
using CRUDApplication.Domain.Contracts;
using CRUDApplication.Domain.Entities;
using CRUDApplication.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CRUDApplication.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GameController : ControllerBase
    {
        private readonly IBaseRepository<Game> _context;
        private readonly IBaseRepository<Company> _Companycontext;
        private readonly IMapper _mapper;

        public GameController(IBaseRepository<Game> context, IMapper mapper, IBaseRepository<Company> companycontext)
        {
            _context = context;
            _mapper = mapper;
            _Companycontext = companycontext;
        }

        [HttpGet("game")]
        public async Task<IActionResult> GetGames()
        {
            try
            {
                var games = await _context.GetAll(record => record.Company);
                var gamesDto = _mapper.Map<List<GameDto>>(games);
                return Ok(gamesDto);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error occured: " + e.Message);
                Console.Error.WriteLine("Call stack: " + e.StackTrace);
                return StatusCode(500, "An Internal Server error occured");
            }
        }

        [HttpGet("game/{id}")]
        public async Task<IActionResult> GetGame(Guid id)
        {
            try
            {
                var game = await _context.Get(id);
                var gameDto = _mapper.Map<GameDto>(game);
                return Ok(gameDto);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error occured: " + e.Message);
                Console.Error.WriteLine("Call stack: " + e.StackTrace);
                return StatusCode(500, "An Internal Server error occured");
            }
        }

        [HttpPost("game")]
        public async Task<IActionResult> CreateGame([FromBody] CreateGame createGame)
        {
            try
            {
                if (await _Companycontext.Get(createGame.CompanyId) == null)
                    return NotFound("Company ID Doesn't exist");
                var game = _mapper.Map<Game>(createGame);
                var createdGame= await _context.Add(game);
                var gameDto = _mapper.Map<GameDto>(createdGame);
                return CreatedAtAction(nameof(GetGame), new { id = gameDto.Id }, gameDto);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error occured: " + e.Message);
                Console.Error.WriteLine("Call stack: " + e.StackTrace);
                return StatusCode(500, "An Internal Server error occured");
            }
        }

        [HttpPut("game")]
        public async Task<IActionResult> UpdateGame(Guid id, [FromBody] UpdateGame updateGame)
        {
            try
            {
                var game = await _context.Get(id);
                if (game == null)
                    return NotFound();
                _mapper.Map(updateGame, game);
                var updatedGame = await _context.Update(game);
                var gameDto = _mapper.Map<GameDto>(updatedGame);
                return Ok(gameDto);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error occured: " + e.Message);
                Console.Error.WriteLine("Call stack: " + e.StackTrace);
                return StatusCode(500, "An Internal Server error occured");
            }
        }

        [HttpDelete("game")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            try
            {
                var game = await _context.Delete(id);
                if (game == null)
                    return NotFound();
                var gameDto = _mapper.Map<GameDto>(game);
                return Ok(gameDto);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error occured: " + e.Message);
                Console.Error.WriteLine("Call stack: " + e.StackTrace);
                return StatusCode(500, "An Internal Server error occured");
            }
        }
    }
}
