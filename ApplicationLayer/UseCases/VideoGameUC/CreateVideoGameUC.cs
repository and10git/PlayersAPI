using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.GameInterfaces;
using ApplicationLayer.UseCases.Interfaces.VideoGameInterfaces;
using DomainLayer.ValueObjects;

namespace ApplicationLayer.UseCases.VideoGameUC
{
    public class CreateVideoGameUC : ICreateVideoGameUC
    {
        private readonly IVideoGameService _videoGameService;
        public CreateVideoGameUC(IVideoGameService videoGameService)
        {
            _videoGameService = videoGameService;
        }

        public Guid CreateVideoGame(string name, string genre)
        {
            var id = _videoGameService.CreateVideoGame(name, genre);
            return id;
        }
    }
}