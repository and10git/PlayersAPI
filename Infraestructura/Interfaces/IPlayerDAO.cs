using DomainLayer.Entities;
using DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructureLayer.Interfaces
{
    public interface IPlayerDAO
    {
        Guid CreatePlayer(DomainLayer.Entities.Player entityPlayer);
        void DeletePlayer(Guid id);
        List<Player> GetAllPlayers();
        Player GetPlayerById(Guid id);
        void UpdatePlayer(Guid id, string nickName);
    }
}
