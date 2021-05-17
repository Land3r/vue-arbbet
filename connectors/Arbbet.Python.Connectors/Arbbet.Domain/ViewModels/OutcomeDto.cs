using Arbbet.Domain.Enums;
using Arbbet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.ViewModels
{
    public class OutcomeDto : IIdentifiable
    {
        public Guid Id { get; set; }

        public decimal Odd { get; set; }

        public OutcomeType OutcomeType { get; set; }

        public Guid BetId { get; set; }

        public virtual BetDto Bet { get; set; }

        public Guid? TeamId { get; set; }

        public virtual TeamDto Team { get; set; }

    }
}