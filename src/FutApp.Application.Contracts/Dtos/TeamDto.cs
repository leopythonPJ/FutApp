using System;
using System.Collections.Generic;
using System.Text;

namespace FutApp.Dtos
{
    public class TeamDto
    {
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
    }
}
