using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.GameInterfaces;

namespace ApplicationLayer.UseCases.GameUC
{
    public class DeleteGameUC : IDeleteGameUC
    {
        private readonly IGameService _gameService;
        public DeleteGameUC(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void DeleteGame(Guid id)
        {
            _gameService.DeleteGame(id);
        }

    }
}