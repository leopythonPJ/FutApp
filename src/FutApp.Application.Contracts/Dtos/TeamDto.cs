using System;
using System.Collections.Generic;
using System.Text;

namespace FutApp.Dtos
{
    public class TeamDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Img { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
    }
}
