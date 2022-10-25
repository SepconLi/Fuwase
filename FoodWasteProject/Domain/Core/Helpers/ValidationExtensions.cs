using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Exceptions;
using LanguageExt;

namespace Domain.Core.Helpers
{
    public static class ValidationExtensions
    {
        public static TSuccess Success<TFail, TSuccess>(this Validation<TFail, TSuccess> result)
            where TFail : notnull
            where TSuccess : notnull
        {
            if (result.IsFail)
                throw new InvalidOperationException("Not a success");
            return result.SuccessToList().First();
        }

        public static TFail Fail<TFail, TSuccess>(this Validation<TFail, TSuccess> result)
            where TFail : notnull
            where TSuccess : notnull
        {
            if (result.IsSuccess)
                throw new InvalidOperationException("Not a failure");
            return result.FailToList().First();
        }

        public static TSuccess Validate<TFail, TSuccess>(this Validation<TFail, TSuccess> result)
            where TFail : notnull
            where TSuccess : notnull
        {
            if (result.IsFail)
                throw new InvalidValueObjectException(result.Fail().ToString());
            return result.Success();
        }

        public static TFail? FailOrDefault<TFail, TSuccess>(this Validation<TFail, TSuccess> result)
            where TFail : notnull
            where TSuccess : notnull
        {
            return result.IsFail
            ? result.Fail()
            : default;
        }
    }
}
