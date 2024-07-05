using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Results.Abstract;

namespace Ecommerce.Core.Utilities.Results.Concrete;

public class Result : IResult
{

    public bool Success { get; }
    public string Message { get; }


    public Result(bool success)
    {
        Success = success;
    }

    public Result(bool success, string message)
    {
        Success = success;
        Message = message;
    }





}

// new Result(true, "Elave olundu");
// new Result(false, "Xeta bas verdi");