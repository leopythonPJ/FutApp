using FutApp.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FutApp.Statistics
{
    public class Statistic : AuditedAggregateRoot<Guid>
    {
        public int Goals { get; set; } = 0;
        public int Asists { get; set; } = 0;
        public int YellowCards { get; set; } = 0;
        public int RedCards { get; set; } = 0;
    }
}
