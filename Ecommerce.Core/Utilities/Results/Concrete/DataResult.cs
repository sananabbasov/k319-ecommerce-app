using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Results.Abstract;

namespace Ecommerce.Core.Utilities.Results.Concrete;

public class DataResult<TData> : Result, IDataResult<TData>
{
    public TData Data { get; }

    public DataResult(bool success) : base(success)
    {
    }

    public DataResult(bool success, string message) : base(success, message)
    {
    }
    public DataResult(bool success, TData data) : base(success)
    {
        Data = data;
    }
    public DataResult(bool success, string message, TData data) : base(success, message)
    {
        Data = data;
    }
}
