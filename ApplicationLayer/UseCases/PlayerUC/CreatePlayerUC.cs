using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.PlayerInterfaces;

namespace ApplicationLayer.UseCases.PlayerUC
{
    public class CreatePlayerUC : ICreatePlayerUC
    {
        private readonly IPlayerService _playerService;
        public CreatePlayerUC(IPlayerService playerservice)
        {
            _playerService = playerservice;
        }

        public Guid CreatePlayer(string name, string nickName, string email)
        {
            var id = _playerService.CreatePlayer(name, nickName, email);
            return id;
        }
    }
}