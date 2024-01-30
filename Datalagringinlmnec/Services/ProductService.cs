using Datalagringinlmnec.Entities;
using Datalagringinlmnec.Repositories;

namespace Datalagringinlmnec.Services;

internal class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryService _categoryService;

    public ProductService(ProductRepository productRepository, CategoryService categoryService)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
    }

    public ProductEntity CreateProduct(string productName, decimal productPrice, string categoryName)
    {
        try
        {
            var categoryEntity = _categoryService.CreateCategory(categoryName);

            var productEntity = new ProductEntity
            {
                ProductName = productName,
                ProductPrice = productPrice,
                CategoryId = categoryEntity.Id,
            };

            productEntity = _productRepository.Create(productEntity);
            return productEntity;
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public ProductEntity GetProductById(int Id)
    {
        try
        {
            var ProductEntity = _productRepository.Get(x => x.Id == Id);
            return ProductEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public IEnumerable<ProductEntity> GetAllProduct()
    {
        try
        {
            var Products = _productRepository.GetAll();
            return Products;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public ProductEntity UpdateProduct(ProductEntity productEntity)
    {
        var updatedEntity = _productRepository.Update(x => x.Id == productEntity.Id, productEntity);
        return updatedEntity;
    }

    public bool DeletProduct(int id)
    {
        try
        {
            _productRepository.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
    }
}
