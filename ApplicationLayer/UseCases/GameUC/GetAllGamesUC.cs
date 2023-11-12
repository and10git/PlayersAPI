using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.GameInterfaces;
using DomainLayer.Entities;

namespace ApplicationLayer.UseCases.GameUC
{
    public class GetAllGamesUC : IGetAllGamesUC
    {
        private readonly IGameService _gameService;
        public GetAllGamesUC(IGameService gameService)
        {
            _gameService = gameService;
        }

        public List<GameDTO> GetAllGames()
        {
            var allGames = _gameService.GetAllGames();
            return allGames;
        }
    }
}