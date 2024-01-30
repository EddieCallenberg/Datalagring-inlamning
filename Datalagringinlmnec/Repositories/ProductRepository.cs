using Datalagringinlmnec.Contexts;
using Datalagringinlmnec.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Datalagringinlmnec.Repositories;

internal class ProductRepository : Repo<ProductEntity>
{
    private readonly DatabseCotext _context;
    public ProductRepository(DatabseCotext context) : base(context)
    {
        _context = context;
    }

    public override ProductEntity Get(Expression<Func<ProductEntity, bool>> expression)
    {
        var entity = _context.Products.Include(x => x.Category).FirstOrDefault(expression);
        return entity!;
    }

    public override IEnumerable<ProductEntity> GetAll()
    {
        return _context.Products
            .Include(x => x.Category)
            .ToList();
    }
}
