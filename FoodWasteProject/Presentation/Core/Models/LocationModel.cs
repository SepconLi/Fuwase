using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Core.Models
{
    public class LocationModel
    {
        public string? Province { get; set; }
        public string? County { get; set; }
        public string? District { get; set; }

        public LocationModel(string province, string county, string district)
        {
            Province = province;
            County = county;
            District = district;
        }
    }
}
