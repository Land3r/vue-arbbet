using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Countries;
using Arbbet.Connectors.Domain.Platforms;

namespace Arbbet.Connectors.Domain.Competitions
{
  public class Competition
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual Country Country { get; set; }

    public virtual Competition UnifiedCompetition { get; set; }

    #region Platform specific fields

    public Platform Platform { get; set; }

    public string Platform_id { get; set; }

    #endregion Platform specific fields
  }
}
