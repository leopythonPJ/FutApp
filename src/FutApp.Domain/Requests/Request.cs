using FutApp.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FutApp.Requests
{
    public class Request : AuditedAggregateRoot<Guid>
    {
        public Player Player { get; set; }
        public Status Status { get; set; }
        public string? Text { get; set; }

    }
}
