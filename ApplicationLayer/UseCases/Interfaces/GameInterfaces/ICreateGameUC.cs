using DomainLayer.Entities;
using DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Interfaces.GameInterfaces
{
    public interface ICreateGameUC
    {
        Guid CreateGame(Guid videoGameId, Guid playerId, double points, double timePlayed);
    }
}
