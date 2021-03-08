using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Models.Platform
{
    public class PlatformViewModel
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int NbOfSports { get; set; }

        public int NbOfCompetitions { get; set; }

        public int NbOfEvents { get; set; }

        public int NbOfBets { get; set; }

        public int NbOfOutcomes { get; set; }

        public IList<SportViewModel> Sports { get; set; }
    }
}
