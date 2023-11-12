using ApplicationLayer.UseCases.Interfaces.GameInterfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayersAPI.DTO.GameDTO;

namespace PlayersAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Games")]
    public class GamesController : ControllerBase
    {        
        private readonly IMapper _mapper;
        private readonly IGetAllGamesUC _getAllGamesUC;
        private readonly IDeleteGameUC _deleteGameUC;
        private readonly ICreateGameUC _createGameUC;

        public GamesController(IMapper mapper, IGetAllGamesUC getAllGamesUC, IDeleteGameUC deleteGameUC, ICreateGameUC createGameUC)
        {
            _mapper = mapper;
            _getAllGamesUC = getAllGamesUC;
            _deleteGameUC = deleteGameUC;
            _createGameUC = createGameUC;
        }

        /// <summary>
        /// Get all the games with the relationship between player and video game.
        /// </summary>
        /// <returns>Return a list of games.</returns>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("Get")]
        public IActionResult Get()
        {
            try
            {
                var allGames = _getAllGamesUC.GetAllGames();
                var allGamesResult = _mapper.Map<List<GameResponseDTO>>(allGames);
                return Ok(allGamesResult);
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Create game with player and video game
        /// </summary>
        /// <param name="gameCreateDTO"></param>
        /// <returns>return a new game id.</returns>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("Create")]
        public IActionResult Create(GameCreateDTO gameCreateDTO)
        {
            try
            {
                var gameGuid = _createGameUC.CreateGame(gameCreateDTO.VideoGameId, gameCreateDTO.PlayerId, gameCreateDTO.Points, gameCreateDTO.TimePlayed);

                return Ok(gameGuid);
            }
            catch (Exception ex)
            {
                return BadRequest($"error: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a game
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return status code.</returns>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _deleteGameUC.DeleteGame(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"error: {ex.Message}");
            }
        }
    }
}