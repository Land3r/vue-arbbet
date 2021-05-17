using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.ViewModels
{
  [DisplayName("Sport")]
  public class SportDto : AUnifiedViewModel
  {
    [DisplayName("Sport.Name")]
    public string Name { get; set; }

    [DisplayName("Sport.Code")]
    public string Code { get; set; }
  }
}
