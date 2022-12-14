/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * 
 * - Summary: Implementation of Campaign class' DTO
 *   Stores all the campaign's information for read only access.
 */

/* Project includes */
using Domain.Core.ValueObjects;
using Domain.Products.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Campaigns.DTOs
{
    public class CampaignDTO
    {
        /**  Attributes **/
        public int Id { get; }
        public string? CreatorEmail { get; }
        public string? Name { get; }
        public string? Description { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public int Goal { get; }
        public int Raised { get; }
        public int Delivered { get; }
        public string? Province { get; }
        public string? County { get; }
        public string? District { get; }
        public string? ExactLocation { get; }
        public char? Type { get; }
        public char? Status { get; }

        public IReadOnlyCollection<Product>? Products { get; }

        /**  Methods **/

        // Used to get a campaign with all it's basic attributes
        public CampaignDTO(int id, string email, string name, string description,
            DateTime? endDate, DateTime? startDate, int goal, int raised,
            int delivered, char type, string province, string county,
            string district, string location)
        {
            Id = id;
            CreatorEmail = email;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Goal = goal;
            Raised = raised;
            Delivered = delivered;
            Province = province;
            County = county;
            District = district;
            ExactLocation = location;
            Type = type;
            Status = 'A';
        }
    }
}