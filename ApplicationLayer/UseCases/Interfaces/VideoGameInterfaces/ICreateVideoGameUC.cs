using DomainLayer.Entities;
using DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Interfaces.VideoGameInterfaces
{
    public interface ICreateVideoGameUC
    {
        Guid CreateVideoGame(string name, string genre);
    }
}
