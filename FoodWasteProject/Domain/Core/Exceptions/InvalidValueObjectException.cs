using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Exceptions
{
    public class InvalidValueObjectException : DomainException
    {
        public InvalidValueObjectException(string? message) : base(message)
        {

        }
    }
}
