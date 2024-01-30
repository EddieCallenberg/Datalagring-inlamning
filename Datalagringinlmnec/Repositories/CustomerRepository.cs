using Datalagringinlmnec.Contexts;
using Datalagringinlmnec.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Datalagringinlmnec.Repositories;

internal class CustomerRepository : Repo<CustomerEntity>
{
    private readonly DatabseCotext _context;
    public CustomerRepository(DatabseCotext context) : base(context)
    {
        _context = context;
    }

    public override CustomerEntity Get(Expression<Func<CustomerEntity, bool>> expression)
    {
        var entity = _context.Customers.Include(x => x.Adress).Include(x => x.Role).FirstOrDefault(expression);
        return entity!;
    }

    public override IEnumerable<CustomerEntity> GetAll()
    {
        return _context.Customers.Include(x => x.Adress).Include(x => x.Role).ToList();
    }
}
