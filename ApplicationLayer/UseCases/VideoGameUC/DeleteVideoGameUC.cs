using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.GameInterfaces;
using ApplicationLayer.UseCases.Interfaces.VideoGameInterfaces;

namespace ApplicationLayer.UseCases.VideoGameUC
{
    public class DeleteVideoGameUC : IDeleteVideoGameUC
    {
        private readonly IVideoGameService _videoGameService;
        public DeleteVideoGameUC(IVideoGameService videoGameService)
        {
            _videoGameService = videoGameService;
        }

        public void DeleteVideoGame(Guid id)
        {
            _videoGameService.DeleteVideoGame(id);
        }

    }
}