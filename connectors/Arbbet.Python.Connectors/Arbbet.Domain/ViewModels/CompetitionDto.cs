using System;

namespace Arbbet.Domain.ViewModels
{
    public class CompetitionDto : AUnifiedViewModel
    {
        public string Name { get; set; }

        public Guid? SportId { get; set; }

        public SportDto Sport { get; set; }

        public Guid? CountryId { get; set; }

        public CountryDto Country { get; set; }
    }
}