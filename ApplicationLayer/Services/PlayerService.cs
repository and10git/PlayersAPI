using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using AutoMapper;
using InfraestructureLayer.Interfaces;
namespace ApplicationLayer.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerDAO _playerDAO;
        private readonly IMapper _mapper;
        public PlayerService(IPlayerDAO playerDAO, IMapper mapper)
        {
            _playerDAO = playerDAO;
            _mapper = mapper;
        }

        public List<PlayerDTO> GetAllPlayers()
        {
            var allPlayers = _playerDAO.GetAllPlayers();
            var allPlayersResult = _mapper.Map<List<PlayerDTO>>(allPlayers);
            return allPlayersResult;
        }

        public PlayerDTO GetPlayerById(Guid id)
        {
            var player = _playerDAO.GetPlayerById(id);
            var playerResult = _mapper.Map<PlayerDTO>(player);
            return playerResult;
        }

        public Guid CreatePlayer(string name, string nickName, string email)
        {
            var entityPlayer = new DomainLayer.Entities.Player(Guid.NewGuid(), name, nickName, email);
            var idNewPlayer = _playerDAO.CreatePlayer(entityPlayer);
            return idNewPlayer;
        }

        public void UpdatePlayer(Guid id, string nickName)
        {
            _playerDAO.UpdatePlayer(id, nickName);
        }

        public void DeletePlayer(Guid id)
        {
            _playerDAO.DeletePlayer(id);
        }
    }
}
