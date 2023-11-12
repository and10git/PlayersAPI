using DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class GameDTO
    {
        public Guid Id { get; set; }
        public Guid VideoGameId { get; set; }
        public Guid PlayerId { get; set; }
        public double Points { get; set; }
        public double TimePlayed { get; set; }
        
    }
}
