using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Enums;

namespace Arbbet.Domain.ViewModels
{
    public class BetDto : AUnifiedViewModel
    {
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public Guid EventId { get; set; }

        public IList<OutcomeDto> Outcomes { get; set; }

        public virtual EventDto Event { get; set; }

        public virtual BetType BetType { get; set; }
    }
}
