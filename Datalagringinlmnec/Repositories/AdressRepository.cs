using Datalagringinlmnec.Contexts;
using Datalagringinlmnec.Entities;

namespace Datalagringinlmnec.Repositories;

internal class AdressRepository : Repo<AdressEntity>
{
    public AdressRepository(DatabseCotext context) : base(context)
    {
    }
}