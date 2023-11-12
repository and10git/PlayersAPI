using ApplicationLayer.UseCases.Interfaces.PlayerInterfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayersAPI.DTO.PlayerDTO;

namespace PlayersAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Players")]
    public class PlayersController : ControllerBase
    {

        private readonly IGetAllPlayersUC _getAllPlayersUC;
        private readonly IGetPlayerByIdUC _getPlayerByIdUC;
        private readonly ICreatePlayerUC _createPlayerUC;
        private readonly IUpdatePlayerUC _updatePlayerUC;
        private readonly IDeletePlayerUC _deletePlayerUC;
        private readonly IMapper _mapper;

        public PlayersController(IMapper mapper,
                                 IGetAllPlayersUC getAllPlayersUC,
                                 ICreatePlayerUC createPlayerUC,
                                 IGetPlayerByIdUC getPlayerByIdUC,
                                 IUpdatePlayerUC updatePlayerUC,
                                 IDeletePlayerUC deletePlayerUC)
        {
            _getAllPlayersUC = getAllPlayersUC;
            _getPlayerByIdUC = getPlayerByIdUC;
            _createPlayerUC = createPlayerUC;
            _mapper = mapper;
            _updatePlayerUC = updatePlayerUC;
            _deletePlayerUC = deletePlayerUC;
        }

        /// <summary>
        /// Get all the players.
        /// </summary>
        /// <returns>Return a list of players.</returns>
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
                var allPlayers = _getAllPlayersUC.GetAllPlayers();
                var allPlayersResult = _mapper.Map<List<PlayerResponseDTO>>(allPlayers);
                return Ok(allPlayersResult);
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get a player by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return a player.</returns>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("Get/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var player = _getPlayerByIdUC.GetPlayerById(id);                
                var playerResult = _mapper.Map<PlayerResponseDTO>(player);
                return Ok(playerResult);
            }
            catch (Exception ex)
            {
                return NotFound($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Create a player
        /// </summary>
        /// <param name="playerCreateDTO"></param>
        /// <returns>return a new player id.</returns>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("Create")]
        public IActionResult Create(PlayerCreateDTO playerCreateDTO)
        {
            try
            {
                var playerGuid = _createPlayerUC.CreatePlayer(playerCreateDTO.Name, playerCreateDTO.NickName, playerCreateDTO.Email);
         
                return Ok(playerGuid);
            }
            catch (Exception ex)
            {
                return BadRequest($"error: {ex.Message}");
            }
        }

        /// <summary>
        /// Update a player
        /// </summary>
        /// <param name="playerUpdateDTO"></param>
        /// <returns>Return status code.</returns>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("Update")]
        public IActionResult Update(PlayerUpdateDTO playerUpdateDTO)
        {
            try
            {
                _updatePlayerUC.UpdatePlayer(playerUpdateDTO.Id, playerUpdateDTO.NickName);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"error: {ex.Message}");
            }
        }


        /// <summary>
        /// Delete a player
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
                _deletePlayerUC.DeletePlayer(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"error: {ex.Message}");
            }
        }
    }
}