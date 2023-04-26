using FutApp.Matches;
using FutApp.Players;
using FutApp.Requests;
using FutApp.Statistics;
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
        private readonly ICurrentUser _currentUser;

        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public IdentityUser President {
            get { return President; } 
            set { President = (IdentityUser) _currentUser; } 
        }
        public DateTime BirthDate { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public Guid StatisticID { get; set; }
        public Statistic Statistic { get; set; } = new Statistic();
        public bool LookingForPlayers { get; set; } = false;
        public List<Request> Requests { get; set; } = new List<Request>();
        public List<Match> Matches { get; set; } = new List<Match>();
        public bool IsActive { get; set; } = true;

    }
}
