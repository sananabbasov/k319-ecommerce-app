using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Business.Abstract;

public interface IBasketService
{
    void AddItem(string name);
}
