using Datalagringinlmnec.Contexts;
using Datalagringinlmnec.Entities;

namespace Datalagringinlmnec.Repositories;

internal class CustomerRepository : Repo<CustomerEntity>
{
    public CustomerRepository(DatabseCotext context) : base(context)
    {
    }
}
