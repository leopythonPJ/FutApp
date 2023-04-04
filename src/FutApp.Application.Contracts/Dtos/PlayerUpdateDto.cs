using System;
using System.Collections.Generic;
using System.Text;

namespace FutApp.Dtos
{
    public class PlayerUpdateDto
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public PositionDto Position { get; set; }
    }
}
