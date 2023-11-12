using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.PlayerInterfaces;

namespace ApplicationLayer.UseCases.PlayerUC
{
    public class DeletePlayerUC : IDeletePlayerUC
    {
        private readonly IPlayerService _playerService;
        public DeletePlayerUC(IPlayerService playerservice)
        {
            _playerService = playerservice;
        }

        public void DeletePlayer(Guid id)
        {
            _playerService.DeletePlayer(id);
        }

    }
}