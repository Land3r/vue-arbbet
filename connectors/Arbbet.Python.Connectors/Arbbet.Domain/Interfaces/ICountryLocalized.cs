using Arbbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.Interfaces
{
    public interface ICountryLocalized
    {
        public Guid? CountryId { get; set; }

        public Country Country { get; set; }
    }
}
