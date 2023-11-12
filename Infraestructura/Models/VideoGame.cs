using System;
using System.Collections.Generic;

namespace InfraestructureLayer.Models;

public partial class VideoGame
{
    public Guid VideoGameId { get; set; }

    public string? VideoGameName { get; set; }

    public string? VideoGameGenre { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
