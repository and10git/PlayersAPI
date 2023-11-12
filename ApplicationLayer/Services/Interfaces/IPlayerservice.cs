using ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Interfaces
{
    public interface IPlayerService
    {
        Guid CreatePlayer(string name, string nickName, string email);
        void DeletePlayer(Guid id);
        List<PlayerDTO> GetAllPlayers();
        PlayerDTO GetPlayerById(Guid id);
        void UpdatePlayer(Guid id, string nickName);
    }
}
