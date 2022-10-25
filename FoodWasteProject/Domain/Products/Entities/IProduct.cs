using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Donations.Entities;
using Domain.Orders.Entities;

namespace Domain.Products.Entities
{
    public interface IProduct
    {
        public void AssignDonation(Donation? donation);
        public void AddOrderProductToProduct(OrderProduct orderProduct);
        public void ClearRestrictions();
        public void AddRestrictionToProduct(Restriction restriction);
        public void RemoveRestrictionFromProduct(Restriction restriction);
    }
}
