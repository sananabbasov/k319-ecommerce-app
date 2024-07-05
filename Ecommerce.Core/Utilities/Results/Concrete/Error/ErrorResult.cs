using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Core.Utilities.Results.Concrete.Error;

public class ErrorResult : Result
{
    public ErrorResult() : base(false)
    {
    }

    public ErrorResult(string message) : base(false, message)
    {
    }
}
// return new ErrorRessult();