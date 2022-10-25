using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Campaigns.Models {
    public class CampaignModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Goal { get; set; }
        public int Raised { get; set; }
        public string? Province { get; set; }
        public string? County { get; set; }
        public string? District { get; set; }
        public string? ExactLocation { get; set; }

        public CampaignModel(int id, string name, string description,
            DateTime? endDate, DateTime? startDate, int goal, int raised,
            string province, string county, string district, string location)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Goal = goal;
            Raised = raised;
            Province = province;
            County = county;
            District = district;
            ExactLocation = location;
        }

        public CampaignModel()
        {
            Id = 0;
            Name = "";
            Description = "";
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            Goal = 0;
            Raised = 0;
            Province = "";
            County = "";
            District = "";
            ExactLocation = "";
        }
    }
}
