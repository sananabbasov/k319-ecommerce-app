using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Core.Utilities.Results.Concrete.Success;

public class SuccessDataResult<TData> : DataResult<TData>
{
    

    public SuccessDataResult(string message) : base(true, message)
    {
    }

    public SuccessDataResult(TData data) : base(true, data)
    {
    }

    public SuccessDataResult(string message, TData data) : base(true, message, data)
    {
    }
}
