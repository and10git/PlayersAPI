using DomainLayer.ValueObjects;

namespace DomainLayer.Entities
{
    public class Game
    {
        public Guid Id { get; init; }
        public Guid VideoGameId { get; private set; }
        public Guid PlayerId { get; private set; }
        public double Points { get; private set; }
        public double TimePlayed{ get; private set; }
        public Game()
        {

        }
        public Game(Guid id, Guid videoGameId, Guid playerId, double points, double timePlayed)
        {
            this.Id = id;
            this.VideoGameId = videoGameId; 
            this.PlayerId = playerId;
            this.Points = points;
            this.TimePlayed = timePlayed;
        }
    }
}