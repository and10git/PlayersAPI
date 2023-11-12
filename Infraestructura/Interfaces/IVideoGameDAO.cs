using DomainLayer.Entities;
using DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructureLayer.Interfaces
{
    public interface IVideoGameDAO
    {
        Guid CreateVideoGame(VideoGame entityVideoGame);
        void DeleteVideoGame(Guid id);
        List<VideoGame> GetAllVideoGames();
    }
}
