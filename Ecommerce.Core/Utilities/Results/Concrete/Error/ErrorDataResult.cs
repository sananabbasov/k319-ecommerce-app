using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Core.Utilities.Results.Concrete.Error;

public class ErrorDataResult<TData> : DataResult<TData>
{
    public ErrorDataResult() : base(false)
    {
    }

    public ErrorDataResult(string message) : base(false, message)
    {
    }

    public ErrorDataResult(TData data) : base(false, data)
    {
    }

    public ErrorDataResult(string message, TData data) : base(false, message, data)
    {
    }
}
