using System;
using System.Collections.Generic;

namespace InfraestructureLayer.Models;

public partial class User
{
    public Guid UserId { get; set; }
    public string? UserName{ get; set; }
    public string? UserPassword { get; set; }
}
