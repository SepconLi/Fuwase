/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Donation class' DTO
 *   Stores all the donation's information for read only access.
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

namespace Domain.Donations.DTOs
{
    public class DonationDTO
    {
        /**  Attributes **/
        public int Id { get; }
        public string DonorId { get; }
        public DateTime CreationDate { get; }
        public string Status { get; }
        public string Province { get; }
        public string County { get; }
        public string District { get; }
        public string ExactLocation { get; }
        public string Description { get; }
        public IReadOnlyCollection<Product> Products { get; }

        /**  Methods **/

        // Used to get a donation with all it's basic attributes
        public DonationDTO(int id, string donorId, string status,
            string province,string county, string district,
            string exactLocation, DateTime creationDate, string description)
        {
            Id = id;
            DonorId = donorId;
            Status = status;
            Province = province;
            County = county;
            District = district;
            ExactLocation = exactLocation;
            CreationDate = creationDate;
            Description = description;
        }

        // Used to get a Donation with its Products
        public DonationDTO(int id, string donorId,
            IReadOnlyCollection<Product> products)
        {
            Id = id;
            DonorId = donorId;
            Products = products;
        }

        // Used to get a Donation it's UserId
        public DonationDTO(int Id, string donorId, string status, 
            DateTime creationDate, List<Product> products, string description) 
        {
            this.Id = Id;
            DonorId = donorId;
            Status = status;
            CreationDate = creationDate;
            Products = products;
            Description = description;
        }
    }
}
