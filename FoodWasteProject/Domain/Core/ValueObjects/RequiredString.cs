using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.ValueObjects
{
    public class RequiredString : ValueObject
    {

        public const int MaxLength = 1000;

        public string Value { get; }

        private RequiredString(string value)
        {
            Value = value;
        }

        // for EFCore
        private RequiredString()
        {
            Value = null!;
        }

        public static Validation<ValidationError, string> TryCreate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new IsNullOrWhitespace();
            if (value.Length > MaxLength)
                return new TooLong(MaxLength);
            return new string(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public override string ToString()
        {
            return Value;
        }
            
        public abstract record ValidationError;
        public record IsNullOrWhitespace : ValidationError;
        public record TooLong(int MaxLength) : ValidationError;

    }
}
