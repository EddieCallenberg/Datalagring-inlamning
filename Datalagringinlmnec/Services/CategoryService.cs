using Datalagringinlmnec.Entities;
using Datalagringinlmnec.Repositories;

namespace Datalagringinlmnec.Services;

internal class CategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public CategoryEntity CreateCategory(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
            if (categoryEntity == null)
            {
                categoryEntity = _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });
            }
            return categoryEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }           
    }

    public CategoryEntity GetCategoryByCategoryName(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
                return categoryEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public CategoryEntity GetCategoryById(int Id)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.Id == Id);
            return categoryEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public IEnumerable<CategoryEntity> GetAllCategories()
    {
        try
        {
            var categories = _categoryRepository.GetAll();
            return categories;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        var updatedEntity = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return updatedEntity;
    }

    public bool DeletCategory(int id)
    {
        try
        {
            _categoryRepository.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); return false;}
    }
}
