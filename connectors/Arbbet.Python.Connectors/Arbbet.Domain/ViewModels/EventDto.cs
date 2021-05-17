using Arbbet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.ViewModels
{
    public class EventDto : AUnifiedViewModel
    {
        public string Name { get; set; }

        public virtual EventType EventType { get; set; }

        public virtual IList<TeamDto> Participants { get; set; }

        public DateTime? StartDate { get; set; }

        public virtual IList<BetDto> Bets { get; set; }

        public Guid? CompetitionId { get; set; }

        public virtual CompetitionDto Competition { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Url { get; set; }
    }
}