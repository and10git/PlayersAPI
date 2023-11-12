using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using AutoMapper;
using InfraestructureLayer;
using InfraestructureLayer.Interfaces;
namespace ApplicationLayer.Services
{
    public class GameService : IGameService
    {
        private readonly IGameDAO _gameDAO;
        private readonly IMapper _mapper;
        public GameService(IGameDAO gameDAO, IMapper mapper)
        {
            _gameDAO = gameDAO;
            _mapper = mapper;
        }

        public List<GameDTO> GetAllGames()
        {
            var allGames = _gameDAO.GetAllGames();
            var allGamesResult = _mapper.Map<List<GameDTO>>(allGames);
            return allGamesResult;
        }

        public Guid CreateGame(Guid videoGameId, Guid playerId, double points, double timePlayed)
        {
            var entityGame = new DomainLayer.Entities.Game(Guid.NewGuid(), videoGameId, playerId, points, timePlayed);
            var idNewGame = _gameDAO.CreateGame(entityGame);
            return idNewGame;
        }

        public void DeleteGame(Guid id)
        {
            _gameDAO.DeleteGame(id);
        }
    }
}
