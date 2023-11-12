using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.PlayerInterfaces;

namespace ApplicationLayer.UseCases.PlayerUC
{
    public class GetPlayerByIdUC : IGetPlayerByIdUC
    {
        private readonly IPlayerService _playerService;
        public GetPlayerByIdUC(IPlayerService playerservice)
        {
            _playerService = playerservice;
        }

        public PlayerDTO GetPlayerById(Guid id)
        {
            var player = _playerService.GetPlayerById(id);
            return player;
        }
    }
}