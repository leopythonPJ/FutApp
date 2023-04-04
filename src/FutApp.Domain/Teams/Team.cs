using FutApp.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace FutApp.Teams
{
    public class Team : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public IdentityUser? President { get; set; };
        public DateTime BirthDate { get; set; }
        public List<Player>? Players { get; set; }
        public int Goals { get; set; } = 0;
        public int YellowCards { get; set; } = 0;
        public int RedCards { get; set; } = 0;
    }
}
