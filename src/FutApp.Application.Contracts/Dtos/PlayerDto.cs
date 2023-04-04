using System;
using System.Collections.Generic;
using System.Text;

namespace FutApp.Dtos
{
    public class PlayerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Number { get; set; }
        public DateTime BirthDate { get; set; }
        public PositionDto Position { get; set; }
    }
}
