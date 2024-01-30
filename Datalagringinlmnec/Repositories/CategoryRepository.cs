using Datalagringinlmnec.Contexts;
using Datalagringinlmnec.Entities;

namespace Datalagringinlmnec.Repositories;

internal class CategoryRepository : Repo<CategoryEntity>
{
    public CategoryRepository(DatabseCotext context) : base(context)
    {
    }
}
