using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.PlayerInterfaces;

namespace ApplicationLayer.UseCases.PlayerUC
{
    public class UpdatePlayerUC : IUpdatePlayerUC
    {
        private readonly IPlayerService _playerService;
        public UpdatePlayerUC(IPlayerService playerservice)
        {
            _playerService = playerservice;
        }

        public void UpdatePlayer(Guid id, string nickName)
        {
            _playerService.UpdatePlayer(id, nickName);
        }
    }
}