using Abp.Extensions;
using ApplicationLayer.DTO;
using ApplicationLayer.Services;
using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.LoginUC;
using AutoMapper;
using InfraestructureLayer;
using InfraestructureLayer.Interfaces;
using Moq;

namespace Test
{
    public class GameServiceTest
    {
        private Mock<IGameDAO> _gameDAO;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _gameDAO = new Mock<IGameDAO>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public void GetAllGames()
        {
            var listaGames = new List<DomainLayer.Entities.Game>()
            {
                new DomainLayer.Entities.Game{Id = Guid.NewGuid() },
                new DomainLayer.Entities.Game{Id = Guid.NewGuid() },
                new DomainLayer.Entities.Game{Id = Guid.NewGuid() }
            };

            var listaGamesDTO = new List<GameDTO>()
            {
                new GameDTO{Id = listaGames[1].Id },
                new GameDTO{Id = listaGames[1].Id },
                new GameDTO{Id = listaGames[1].Id },                
            };

            _gameDAO.Setup(s => s.GetAllGames()).Returns(listaGames);
            _mapper.Setup(m => m.Map<List<GameDTO>>(listaGames)).Returns(listaGamesDTO);

            var gameService = new GameService(_gameDAO.Object, _mapper.Object);
            
            var result = gameService.GetAllGames();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));
        }
    }

}
