using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Payloads;

public class PaginationResponse<TEntity>
{
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public List<TEntity> Data { get; set; }
}
