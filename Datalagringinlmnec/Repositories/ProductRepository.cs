using Datalagringinlmnec.Contexts;
using Datalagringinlmnec.Entities;

namespace Datalagringinlmnec.Repositories;

internal class ProductRepository : Repo<ProductEntity>
{
    public ProductRepository(DatabseCotext context) : base(context)
    {
    }
}
