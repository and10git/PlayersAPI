using ApplicationLayer.DTO;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Interfaces.VideoGameInterfaces
{
    public interface IGetAllVideoGamesUC
    {
        List<VideoGameDTO> GetAllVideoGames();
    }
}
