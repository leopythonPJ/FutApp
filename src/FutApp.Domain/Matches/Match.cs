using FutApp.Players;
using FutApp.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FutApp.Matches
{
    public class Match : AuditedAggregateRoot<Guid>
    {
        public DateTime DateTime { get; set; }
        public string? Location { get; set; }
        public MatchType MatchType { get; set; }
        public Guid LocalId { get; set; }
        public Team? Local { get; set; }
        public Guid VisitorId { get; set; }
        public Team? Visitor { get; set; }
        public int LocalGoals { get; set; }
        public int VisitorGoals { get; set;}
        public List<Player>? PlayersList { get; set; }
        public string? Tactic { get; set; }
        public List<MatchStatics> MatchStaticsList { get; set; } = new List<MatchStatics>();
    }
}
