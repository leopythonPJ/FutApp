using FutApp.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FutApp.Matches
{
    public class MatchStatics : AuditedAggregateRoot<Guid>
    {
        Player? Player { get; set; }
        public int Goals { get; set; } = 0;
        public int YellowCards { get; set; } = 0;
        public int redCards { get; set; } = 0;
    }
}
