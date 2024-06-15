using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using StackExchange.Redis;

namespace Ecommerce.Business.Concrete;

public class BasketManager : IBasketService
{

    private readonly ConnectionMultiplexer _connectionMultiplexer;

    public BasketManager(ConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public void AddItem(string name)
    {
        throw new NotImplementedException();
    }
}
