using ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Interfaces
{
    public interface IVideoGameService
    {
        Guid CreateVideoGame(string name, string genre);
        void DeleteVideoGame(Guid id);
        List<VideoGameDTO> GetAllVideoGames();

    }
}
