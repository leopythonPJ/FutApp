using FutApp.Statistics;
using FutApp.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FutApp.Players
{
    public class Player : AuditedAggregateRoot<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Number { get; set; } = 0;
        public DateTime BirthDate { get; set; }
        public Position? Position { get; set; }
        public Guid StatisticID { get; set; }
        public Statistic Statistic { get; set; } = new Statistic();
        public List<Team>? Teams { get; set; }
        public bool IsActive { get; set; } = true;


        public int GetAge()
        {
            int age = DateTime.Now.Year - BirthDate.Year;

            if(BirthDate.Date > DateTime.Today.AddYears(-age).Date) { age--; }

            return age;
        }

    }
}
