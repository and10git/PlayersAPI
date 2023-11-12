using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.VideoGameInterfaces;
using DomainLayer.Entities;

namespace ApplicationLayer.UseCases.VideoGameUC
{
    public class GetAllVideoGamesUC : IGetAllVideoGamesUC
    {
        private readonly IVideoGameService _videoGameService;
        public GetAllVideoGamesUC(IVideoGameService videGameService)
        {
            _videoGameService = videGameService;
        }

        public List<VideoGameDTO> GetAllVideoGames()
        {
            var allVideoGames = _videoGameService.GetAllVideoGames();
            return allVideoGames;
        }
    }
}