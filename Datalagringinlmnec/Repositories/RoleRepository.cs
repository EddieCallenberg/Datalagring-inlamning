using Datalagringinlmnec.Contexts;
using Datalagringinlmnec.Entities;

namespace Datalagringinlmnec.Repositories;

internal class RoleRepository : Repo<RoleEntity>
{
    public RoleRepository(DatabseCotext context) : base(context)
    {
    }
}