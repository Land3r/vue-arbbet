using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Competitions;
using Arbbet.Connectors.Domain.Platforms;
using Arbbet.Connectors.Domain.Teams;

namespace Arbbet.Connectors.Domain.Bets
{
  public class Bet
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public virtual Team Team_A { get; set; }

    public virtual Team Team_B { get; set; }

    public BetType BetType { get; set; }

    public decimal Odd_Win_A { get; set; }

    public decimal Odd_Draw_A { get; set; }

    public decimal Odd_Lose_A { get; set; }

    public virtual Platform Platform { get; set; }

    public string IdPlatform { get; set; }

    public string Url { get; set; }
  }
}
