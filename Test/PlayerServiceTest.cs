using ApplicationLayer.DTO;
using ApplicationLayer.Services;
using AutoMapper;
using InfraestructureLayer.Interfaces;
using Moq;

namespace Test
{
    public class PlayerServiceTest
    {
        private Mock<IPlayerDAO> _playerDAO;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _playerDAO = new Mock<IPlayerDAO>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public void GetAllPlayers()
        {
            var listPlayers = new List<DomainLayer.Entities.Player>();

            var listPlayersDTO = new List<PlayerDTO>()
            {
                new PlayerDTO{Id = Guid.NewGuid() , Name = "Player 1"},
                new PlayerDTO{Id = Guid.NewGuid() , Name = "Player 2"},
                new PlayerDTO{Id = Guid.NewGuid() , Name = "Player 3"},
            }; 

            _playerDAO.Setup(s => s.GetAllPlayers()).Returns(listPlayers);
            _mapper.Setup(m => m.Map<List<PlayerDTO>>(listPlayers)).Returns(listPlayersDTO);

            var playerService = new PlayerService(_playerDAO.Object, _mapper.Object);
            
            var result = playerService.GetAllPlayers();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetById()
        {
            var onePlayer = new DomainLayer.Entities.Player();

            var playerDTO = new PlayerDTO { Id = Guid.NewGuid(), Name = "Player 1" };

            _playerDAO.Setup(s => s.GetPlayerById(playerDTO.Id)).Returns(onePlayer);
            _mapper.Setup(m => m.Map<PlayerDTO>(onePlayer)).Returns(playerDTO);

            var playerService = new PlayerService(_playerDAO.Object, _mapper.Object);

            var result = playerService.GetPlayerById(playerDTO.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(playerDTO.Id));
        }       
    }

}
