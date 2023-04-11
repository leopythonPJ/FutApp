using System;
using System.Collections.Generic;
using System.Text;

namespace FutApp.Dtos
{
    public class RequestDto
    {
        public PlayerDto Player { get; set; }
        public StatusDto Status { get; set; }
        public string? Text { get; set; }
    }
}
