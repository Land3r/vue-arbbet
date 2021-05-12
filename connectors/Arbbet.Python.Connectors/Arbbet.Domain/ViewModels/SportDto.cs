using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.ViewModels
{
    public class SportDto : AUnifiedViewModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        //public virtual IList<CompetitionDto> Competitions { get; set; }
    }
}
