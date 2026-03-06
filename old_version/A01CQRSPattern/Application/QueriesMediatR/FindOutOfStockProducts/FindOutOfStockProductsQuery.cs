using Application.Common;
using MediatR;
using System.Collections.Generic;


namespace Application.QueriesMediatR
{
    public class FindOutOfStockProductsQuery : IRequest<List<ProductInventory>>
    {
    }
}
