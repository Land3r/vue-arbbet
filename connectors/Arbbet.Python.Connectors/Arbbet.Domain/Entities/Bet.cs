using Arbbet.Domain.Enums;
using Arbbet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arbbet.Domain.Entities
{
    public class Bet : IIdentifiable, INamed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual IList<Outcome> Outcomes { get; set; }

        public Guid EventId { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        public virtual BetType BetType { get; set; }
    }
}