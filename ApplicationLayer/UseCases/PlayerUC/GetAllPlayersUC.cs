using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.PlayerInterfaces;
using DomainLayer.Entities;

namespace ApplicationLayer.UseCases.PlayerUC
{
    public class GetAllPlayersUC : IGetAllPlayersUC
    {
        private readonly IPlayerService _playerService;
        public GetAllPlayersUC(IPlayerService playerservice)
        {
            _playerService = playerservice;
        }

        public List<PlayerDTO> GetAllPlayers()
        {
            var allPlayers = _playerService.GetAllPlayers();
            return allPlayers;
        }
    }
}