/* Campaign module - Asociación Lista y Valiente & Imborrables
 * Collaborators:
 * - Jimena Gdur
 * - Fabian Gonzales
 * - Maeva Murcia
 * - 
 * 
 * - Summary: Implementation of Receives class
 *   Stores all campaign's associations between the campaign and it's donations
 */

/* Project includes */
using Domain.Core.Entities;
using Domain.Core.Exceptions;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Campaigns.Entities;
using Domain.Donations.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Campaigns.Entities
{
    public class Receives 
    {
        public int? CampaignId { get; set; }
        public int? DonationId { get; set; }
        public Campaign? Campaign { get; set; }
        public Donation? Donation { get; set; }

        public Receives(Campaign campaign, Donation donation)
        {
            CampaignId = campaign.Id;
            DonationId = donation.Id;
            Campaign = campaign;
            Donation = donation;
        }

        public Receives()
        {
            CampaignId = -1;
            DonationId = -1;
            Campaign = null;
            Donation = null;
        }
    }
}
