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
    public class VideoGameServiceTest
    {
        private Mock<IVideoGameDAO> _videoGameDAO;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _videoGameDAO = new Mock<IVideoGameDAO>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public void GetAllVideoGames()
        {
            var listaVG = new List<DomainLayer.Entities.VideoGame>()
            {
                new DomainLayer.Entities.VideoGame{Id = Guid.NewGuid() },
                new DomainLayer.Entities.VideoGame{Id = Guid.NewGuid() },
                new DomainLayer.Entities.VideoGame{Id = Guid.NewGuid() }
            };

            var listaVGDTO = new List<VideoGameDTO>()
            {
                new VideoGameDTO{Id = listaVG[1].Id },
                new VideoGameDTO{Id = listaVG[1].Id },
                new VideoGameDTO{Id = listaVG[1].Id },                
            };

            _videoGameDAO.Setup(s => s.GetAllVideoGames()).Returns(listaVG);
            _mapper.Setup(m => m.Map<List<VideoGameDTO>>(listaVG)).Returns(listaVGDTO);

            var VGService = new VideoGameService(_videoGameDAO.Object, _mapper.Object);
            
            var result = VGService.GetAllVideoGames();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));
        }
    }

}
