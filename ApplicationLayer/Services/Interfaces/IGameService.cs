using ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Interfaces
{
    public interface IGameService
    {
        Guid CreateGame(Guid videoGameId, Guid playerId, double points, double timePlayed);
        void DeleteGame(Guid id);
        List<GameDTO> GetAllGames();

    }
}
