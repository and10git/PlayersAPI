using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.GameInterfaces;
using DomainLayer.ValueObjects;

namespace ApplicationLayer.UseCases.GameUC
{
    public class CreateGameUC : ICreateGameUC
    {
        private readonly IGameService _gameService;
        public CreateGameUC(IGameService gameService)
        {
            _gameService = gameService;
        }

        public Guid CreateGame(Guid videoGameId, Guid playerId, double points, double timePlayed)
        {
            var id = _gameService.CreateGame(videoGameId, playerId, points, timePlayed);
            return id;
        }
    }
}