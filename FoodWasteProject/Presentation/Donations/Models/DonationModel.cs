using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Donations.Models {
    public class DonationModel {
        public string? Status { get; set; }
        public string? Province { get; set; }
        public string? County { get; set; }
        public string? District { get; set; }
        public string? ExactLocation { get; set; }

        public DonationModel(string province, string county, string district,
            string exactLocation) {
                Province = province;
                County = county;
                District = district;
                ExactLocation = exactLocation;
        }

}
}
