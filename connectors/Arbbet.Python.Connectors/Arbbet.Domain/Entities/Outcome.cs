using Arbbet.Domain.Enums;
using Arbbet.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arbbet.Domain.Entities
{
    public class Outcome : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public decimal Odd { get; set; }

        public OutcomeType OutcomeType { get; set; }

        public Guid BetId { get; set; }
        
        [ForeignKey("BetId")]
        public virtual Bet Bet { get; set; }

        public Guid? TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
    }
}