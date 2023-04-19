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
        public int Golas { get; set; } = 0;
        public Position? Position { get; set; }
        public int YellowCards { get; set; } = 0;
        public int RedCards { get; set; } = 0;
        public List<Team>? Teams { get; set; }


        public int GetAge()
        {
            int age = DateTime.Now.Year - BirthDate.Year;

            if(BirthDate.Date > DateTime.Today.AddYears(-age).Date) { age--; }

            return age;
        }

    }
}
