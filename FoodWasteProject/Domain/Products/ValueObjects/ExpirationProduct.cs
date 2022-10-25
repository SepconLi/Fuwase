/* Project includes */
//using Domain.Core.ValueObjects;
/* System includes */
//using LanguageExt;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Domain.Products.ValueObjects {
//    public class ExpirationProduct : ValueObject
//    {
//        public DateTime today  = DateTime.Today;

//        public DateTime ExpirationDate { get; }

//        private ExpirationProduct(DateTime expiration)
//        {
//            ExpirationDate = expiration;
//        }

//        public static Validation<ValidationError, ExpirationDate> TryCreate
//            DateTime expiration)
//        {
//            if (code is null)
//                return new CodeIsNull();
//            if (code < MinNumber)
//                return new CodeTooSmall(MinNumber);
//            if (code > MaxNumber)
//                return new CodeTooBig(MaxNumber);

//            return new CodeProduct(code.Value);

//        }

//        protected override IEnumerable<object> GetEqualityComponents()
//        {
//            yield return Code;
//        }

//        public override string ToString()
//        {
//            return Code.ToString();
//        }

//        public abstract record ValidationError;
//        public record CodeIsNull : ValidationError;
//        public record CodeTooSmall(int MinNumber) : ValidationError;
//        public record CodeTooBig(int MaxNumber) : ValidationError;
//    }
//    */
//}
