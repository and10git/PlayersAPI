using ApplicationLayer.DTO;
using DomainLayer.Entities;
using DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Interfaces.GameInterfaces
{
    public interface IDeleteGameUC
    {
        void DeleteGame(Guid id);
    }
}
