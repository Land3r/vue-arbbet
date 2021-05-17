using Arbbet.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.ViewModels
{
  [DisplayName("Platform")]
  public class PlatformDto : IIdentifiable
  {
    [DisplayName("Platform.Id")]
    public Guid Id { get; set; }

    [DisplayName("Platform.Code")]
    public string Code { get; set; }

    [DisplayName("Platform.Name")]
    public string Name { get; set; }
  }
}