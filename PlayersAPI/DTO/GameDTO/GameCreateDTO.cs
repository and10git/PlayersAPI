namespace PlayersAPI.DTO.GameDTO
{ 
    public class GameCreateDTO
    {
        public Guid VideoGameId { get; set; }
        public Guid PlayerId { get; set; }
        public double Points { get; set; }
        public double TimePlayed { get; set; }
    }
}