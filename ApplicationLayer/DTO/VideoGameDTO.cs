﻿using DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class VideoGameDTO
    {
        public Guid Id { get; set; }        
        public string Name { get; set; }
        public string Genre { get; set; }        
    }
}
