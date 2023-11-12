using DomainLayer.Entities;
using DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructureLayer.Interfaces
{
    public interface IGameDAO
    {
        Guid CreateGame(Game entityGame);
        void DeleteGame(Guid id);
        List<Game> GetAllGames();
    }
}
