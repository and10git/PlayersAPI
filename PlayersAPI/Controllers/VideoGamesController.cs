using ApplicationLayer.UseCases.Interfaces.VideoGameInterfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayersAPI.DTO.VideoGameDTO;

namespace PlayersAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("VideoGames")]
    public class VideoGamesController : ControllerBase
    {        
        private readonly IMapper _mapper;
        private readonly IGetAllVideoGamesUC _getAllVideoGamesUC;
        private readonly IDeleteVideoGameUC _deleteVideoGameUC;
        private readonly ICreateVideoGameUC _createVideoGameUC;

        public VideoGamesController(IMapper mapper, IGetAllVideoGamesUC getAllVideoGamesUC, IDeleteVideoGameUC deleteVideoGameUC, ICreateVideoGameUC createGameUC)
        {
            _mapper = mapper;
            _getAllVideoGamesUC = getAllVideoGamesUC;
            _deleteVideoGameUC = deleteVideoGameUC;
            _createVideoGameUC = createGameUC;
        }

        /// <summary>
        /// Get all the video games.
        /// </summary>
        /// <returns>Return a list of video games.</returns>        
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
                var allVideoGames = _getAllVideoGamesUC.GetAllVideoGames();
                var allVideoGamesResult = _mapper.Map<List<VideoGameResponseDTO>>(allVideoGames);
                return Ok(allVideoGamesResult);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Create a video game
        /// </summary>
        /// <param name="videoGameCreateDTO"></param>
        /// <returns>return a new video game id.</returns>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("Create")]
        public IActionResult Create(VideoGameCreateDTO videoGameCreateDTO)
        {
            try
            {
                var gameGuid = _createVideoGameUC.CreateVideoGame(videoGameCreateDTO.Name, videoGameCreateDTO.Genre);

                return Ok(gameGuid);
            }
            catch (Exception ex)
            {
                return BadRequest($"error: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a video game
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
                _deleteVideoGameUC.DeleteVideoGame(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"error: {ex.Message}");
            }
        }
    }
}