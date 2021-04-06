using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Bases;
using Arbbet.Domain.Enums;
using Arbbet.Domain.Interfaces;

namespace Arbbet.Domain.Entities
{
  public class Sport : AUnifiedEntity<Sport>, IIdentifiable, ICodeNamed, IUnifiedEntity<Sport>
  {
    public string Name { get; set; }

    public string Code { get; set; }

    public virtual IList<Competition> Competitions { get; set; }
  }
}
