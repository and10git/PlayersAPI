using ApplicationLayer.DTO;
using ApplicationLayer.Services.Interfaces;
using AutoMapper;
using InfraestructureLayer;
using InfraestructureLayer.Interfaces;
namespace ApplicationLayer.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly IVideoGameDAO _videoGameDAO;
        private readonly IMapper _mapper;
        public VideoGameService(IVideoGameDAO videoGameDAO, IMapper mapper)
        {
            _videoGameDAO = videoGameDAO;
            _mapper = mapper;
        }

        public List<VideoGameDTO> GetAllVideoGames()
        {
            var allVideoGames = _videoGameDAO.GetAllVideoGames();
            var allVideoGamesResult = _mapper.Map<List<VideoGameDTO>>(allVideoGames);
            return allVideoGamesResult;
        }

        public Guid CreateVideoGame(string name, string genre)
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name field is required");

            var entityVideoGame = new DomainLayer.Entities.VideoGame(Guid.NewGuid(), name, genre);
            var idNewVideoGame = _videoGameDAO.CreateVideoGame(entityVideoGame);
            return idNewVideoGame;
        }

        public void DeleteVideoGame(Guid id)
        {
            _videoGameDAO.DeleteVideoGame(id);
        }
    }
}
